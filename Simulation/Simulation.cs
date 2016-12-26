using Simulation.Interface;
using Simulation.Logging;
using Simulation.Models;
using Simulation.World;
using Simulation.World.Specimen;
using System;
using System.Collections.Generic;
using System.Composition;
using System.Linq;
using System.Threading.Tasks;

namespace Simulation
{
    public class Simulation
    {
        private object _runningLock;
        private Task _runningTask;
        private readonly SimulationSettings _settings;
        private readonly SpecimenManager _specimenManager;
        private bool _stopRequested;
        private readonly SimulationWorld _world;

        public ISimulationWorld World => _world;

        public event EventHandler Updated;

        [ImportMany]
        public IEnumerable<ISimulationMetadata> SimulationMetadata { get; set; }

        public Simulation(SimulationSettings settings)
        {
            CompositionContainer.Resolve(this);

            _settings = settings;
            _world = new SimulationWorld();
            _specimenManager = SetupSpecimenManager();

            _runningLock = new object();
        }

        private SpecimenManager SetupSpecimenManager()
        {
            var specimenFactories = SimulationMetadata.Select(
                s => s.CreateSpecimenFactory(LogManager.GetLogger(s.SpecieName)));

            return new SpecimenManager(specimenFactories);
        }

        public Task RunAsync()
        {
            lock (_runningLock)
            {
                if (_runningTask?.IsCompleted == false)
                {
                    throw new InvalidOperationException("Simulation is already running");
                }

                _runningTask = Task.Run(async () =>
                {
                    try
                    {
                        while (!_stopRequested)
                        {
                            _specimenManager.PopulateWorld(_world, _settings.MaximumWorldPopulation);

                            DateTime lastUpdateTimestamp = DateTime.Now;
                            while (!GenerationEndCriteriaMet())
                            {
                                await Task.Delay(10);

                                var currentTimestamp = DateTime.Now;
                                var updateDuration = currentTimestamp - lastUpdateTimestamp;
                                lastUpdateTimestamp = currentTimestamp;

                                foreach (var worldObjects in _world.UpdateableObjects)
                                {
                                    worldObjects.Update(updateDuration);
                                }

                                Updated?.Invoke(this, EventArgs.Empty);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                });

                return _runningTask;
            }
        }

        private bool GenerationEndCriteriaMet()
        {
            return _stopRequested
                || _world.Population.All(s => s.HealthPoints <= 0);
        }

        public async void StopAsync()
        {
            _stopRequested = true;
            await _runningTask;
        }
    }
}

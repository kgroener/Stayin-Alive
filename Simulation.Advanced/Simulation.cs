using Simulation.World;
using Simulation.World.Specimen;
using System;
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

        internal SimulationWorld World => _world;

        public event EventHandler Updated;

        public Simulation(SimulationSettings settings)
        {
            _settings = settings;
            _world = new SimulationWorld();
            _specimenManager = new SpecimenManager();
            _runningLock = new object();
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
                    while (!_stopRequested)
                    {
                        _specimenManager.PopulateWorld(_world, _settings.MaximumWorldPopulation);

                        DateTime lastUpdateTimestamp = DateTime.Now;
                        while (!GenerationEndCriteriaMet())
                        {
                            var currentTimestamp = DateTime.Now;
                            var updateDuration = lastUpdateTimestamp - currentTimestamp;
                            lastUpdateTimestamp = currentTimestamp;

                            foreach (var worldObjects in _world.Objects)
                            {
                                worldObjects.Update(updateDuration);
                            }

                            Updated?.Invoke(this, EventArgs.Empty);
                            await Task.Delay(10);
                        }
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

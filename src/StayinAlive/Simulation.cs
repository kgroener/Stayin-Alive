using StayinAlive.Interface;
using StayinAlive.Logging;
using StayinAlive.Models;
using StayinAlive.World;
using StayinAlive.World.Physics;
using StayinAlive.World.Spawners;
using StayinAlive.World.Specimen;
using System;
using System.Collections.Generic;
using System.Composition;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace StayinAlive
{
    public class Simulation
    {
        private object _runningLock;
        private Task _runningTask;
        private readonly SimulationSettings _settings;
        private readonly SpecimenManager _specimenManager;
        private bool _stopRequested;
        private readonly SimulationWorld _world;
        private readonly IEnumerable<IObjectSpawner> _spawners;

        public ISimulationWorld World => _world;

        public event EventHandler Updated;

        [ImportMany]
        public IEnumerable<ISimulationMetadata> SimulationMetadata { get; set; }

        public Simulation(SimulationSettings settings)
        {
            CompositionContainer.Resolve(this);

            _settings = settings;
            _world = new SimulationWorld(settings.WorldBoundary);
            _specimenManager = SetupSpecimenManager();
            _spawners = settings.Spawners;

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
                                Debug.WriteLine($"FPS: {1 / updateDuration.TotalSeconds}");

                                foreach (var worldObject in _world.UpdateableObjects)
                                {
                                    worldObject.Update(updateDuration);

                                    foreach (var objB in _world.Objects.ToArray())
                                    {
                                        if (worldObject == objB) { continue; }

                                        var colliding = CollisionDetector.AreColliding(worldObject, objB);
                                        if (colliding)
                                        {
                                            worldObject.OnCollision(objB);
                                        }
                                    }
                                }

                                foreach (var spawner in _spawners)
                                {
                                    foreach (var obj in spawner.GetNewObjectsToSpawn(_world))
                                    {
                                        _world.SpawnObject(obj);
                                    }
                                }

                                _world.RemoveMarkedObjects();

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

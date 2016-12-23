using Simulation.World;
using Simulation.WPF.MVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Simulation.WPF.ViewModels
{
    internal class WorldViewModel : ViewModelBase
    {
        private readonly Simulation _simulation;
        private readonly ISimulationWorld _world;

        public WorldViewModel()
        {
            _simulation = SimulationManager.Simulation.Value;
            _world = _simulation.World;

            _simulation.Updated += HandleSimulationUpdate;
        }

        public IEnumerable<Polygon> Objects
        {
            get
            {
                return _world.Objects.Select(ConvertSimulationObjectToPolygonShape);
            }
        }

        private Polygon ConvertSimulationObjectToPolygonShape(IWorldObject worldObject)
        {
            Polygon polygon = null;

            UIHelper.UISafeInvoke(() =>
            {
                try
                {
                    polygon = new Polygon();

                    foreach (var point in worldObject.PolygonPoints)
                    {
                        polygon.Points.Add(new System.Windows.Point(point.X, point.Y));
                    }

                    polygon.Fill = new SolidColorBrush(worldObject.Color);

                    var centerX = (worldObject.PolygonPoints.Max((p) => p.X) - worldObject.PolygonPoints.Min((p) => p.X)) / 2;
                    var centerY = (worldObject.PolygonPoints.Max((p) => p.Y) - worldObject.PolygonPoints.Min((p) => p.Y)) / 2;
                    polygon.LayoutTransform = new RotateTransform(worldObject.RotationRadians * 180 / Math.PI, centerX, centerY);

                    Canvas.SetBottom(polygon, worldObject.Position.Y);
                    Canvas.SetLeft(polygon, worldObject.Position.X);
                }catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            });

            return polygon;
        }

        private void HandleSimulationUpdate(object sender, EventArgs e)
        {
            RaisePropertyChanged(() => Objects);
        }
    }
}

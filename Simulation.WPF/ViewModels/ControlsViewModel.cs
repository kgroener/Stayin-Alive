using System;
using Simulation.WPF.MVVM;

namespace Simulation.WPF.ViewModels
{


    class ControlsViewModel
    {
        public ControlsViewModel()
        {
            StartSimulationCommand = new RelayCommand(HandleStartSimulationCommand);

        }

        private void HandleStartSimulationCommand()
        {
            SimulationManager.Simulation.Value.RunAsync();
        }

        public RelayCommand StartSimulationCommand { get; set; }
    }
}

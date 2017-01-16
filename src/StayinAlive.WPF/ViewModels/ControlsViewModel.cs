using System;
using StayinAlive.WPF.MVVM;

namespace StayinAlive.WPF.ViewModels
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PingPongGame.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private ViewModelBase currentChildView;

        public ViewModelBase CurrentChildView
        {
            get
            {
                return currentChildView;
            }
            set
            {
                currentChildView = value;
                OnPropertyChanged(nameof(CurrentChildView));
            }
        }
        public ICommand ShowHomeViewCommand { get; }
        public ICommand ShowGameViewCommand { get; }
        public ICommand ShowSettingsViewCommand { get; }
        public ICommand ShowInfoViewCommand { get; }
        public MainViewModel()
        {
            //Initilizate commands
            ShowHomeViewCommand = new ViewModelCommand(ExecuteShowHomeViewCommand);
            ShowGameViewCommand = new ViewModelCommand(ExecuteShowGameViewCommand);
            ShowSettingsViewCommand =new ViewModelCommand(ExecuteShowSettingsViewCommand);
            ShowInfoViewCommand = new ViewModelCommand(ExecuteShowInfoViewCommand);

            //Default view
            ExecuteShowHomeViewCommand(null);

        }

        private void ExecuteShowInfoViewCommand(object obj)
        {
            CurrentChildView = new InfoViewModel();
        }

        private void ExecuteShowSettingsViewCommand(object obj)
        {
            CurrentChildView = new SettingsViewModel();
        }

        private void ExecuteShowGameViewCommand(object obj)
        {
            CurrentChildView = new GameViewModel();
        }

        private void ExecuteShowHomeViewCommand(object obj)
        {
            CurrentChildView = new HomeViewModel();
        }

        
    }
}

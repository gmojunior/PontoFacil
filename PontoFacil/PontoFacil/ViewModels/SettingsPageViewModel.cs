using PontoFacil.Models;
using PontoFacil.Services;
using Prism.Commands;
using Prism.Windows.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;
using Windows.UI.Popups;

namespace PontoFacil.ViewModels
{
    public class SettingsPageViewModel : ViewModelBase
    {

        private List<int> time;
        public List<int> Time
        {
            get { return this.time; }
            set { SetProperty(ref time, value); }
        }

        private Profile _profile;
        public Profile Profile
        {
            get { return _profile; }
            set { SetProperty(ref _profile, value); }
        }

        public DelegateCommand SaveCommand { get; private set; }
        public DelegateCommand NotifyCommand { get; private set; }

        public SettingsPageViewModel()
        {
            Profile = new Profile();
            Time = new List<int> { 1, 2 };
            Profile.Notify = false;
            InicializeCommands();
        }

        private void InicializeCommands()
        {
            SaveCommand = new DelegateCommand(ActionSave);
        }

        private void ActionSave()
        {
        }
    }
}

using PontoFacil.Models;
using PontoFacil.Services;
using Prism.Commands;
using Prism.Windows.Mvvm;
using System.Collections.Generic;
using Windows.Foundation;
using Windows.UI.ViewManagement;

namespace PontoFacil.ViewModels
{
    public class SettingsPageViewModel : ViewModelBase
    {
        #region Properties
        private List<int> intervalTime;
        public List<int> IntervalTime
        {
            get { return this.intervalTime; }
            set { SetProperty(ref intervalTime, value); }
        }

        private Profile _profile;
        public Profile Profile
        {
            get { return _profile; }
            set { SetProperty(ref _profile, value); }
        }

        public DelegateCommand SaveCommand { get; private set; }
        #endregion

        private ISettingsService settingsService;

        public SettingsPageViewModel(ISettingsService settingsService)
        {
            this.settingsService = settingsService;

            ApplicationView.GetForCurrentView().SetPreferredMinSize(new Size(500, 1000));

            //Set options in Lunch Interval ComboBox
            IntervalTime = new List<int> { 1, 2 };
            //Profile.Notify = false;

            InicializeCommands();
        }

        private void InicializeCommands()
        {
            SaveCommand = new DelegateCommand(ActionSave);
        }

        private void ActionSave()
        {
            settingsService.Save(Profile);
        }
    }
}
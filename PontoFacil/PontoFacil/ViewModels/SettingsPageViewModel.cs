using PontoFacil.Models;
using PontoFacil.Services;
using Prism.Commands;
using Prism.Windows.Mvvm;
using System;
using Windows.Foundation;
using Windows.UI.ViewManagement;

namespace PontoFacil.ViewModels
{
    public class SettingsPageViewModel : ViewModelBase
    {
        #region Properties
        private bool _lunchTime;
        public bool LunchTime
        {
            get { return this._lunchTime; }
            set { SetProperty(ref _lunchTime, value); }
        }

        private Profile _profile;
        public Profile Profile
        {
            get { return _profile; }
            set { SetProperty(ref _profile, value); }
        }

        public DelegateCommand SaveCommand { get; private set; }
        #endregion

        private ISettingsService _settingsService;

        public SettingsPageViewModel(ISettingsService settingsService)
        {
            _settingsService = settingsService;

            Profile = _settingsService.GetProfile();
            LunchTime = true;
            if (Profile.LunchTime.Equals(2))
                LunchTime = false;

            ApplicationView.GetForCurrentView().SetPreferredMinSize(new Size(500, 1000));

            InicializeCommands();
        }

        private void InicializeCommands()
        {
            SaveCommand = new DelegateCommand(ActionSave);
        }

        private void ActionSave()
        {
            var localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
            localSettings.Values["SettingsOk"] = true;

            Profile.LunchTime = (byte)(LunchTime ? 1 : 2);
            _settingsService.Save(Profile);
        }
    }
}
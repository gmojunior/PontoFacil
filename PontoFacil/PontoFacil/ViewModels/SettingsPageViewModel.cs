using PontoFacil.Models;
using PontoFacil.Services;
using Prism.Commands;
using Prism.Windows.Mvvm;
using System;
using System.Text;
using System.Text.RegularExpressions;
using Windows.ApplicationModel.Resources;
using Windows.Foundation;
using Windows.UI.Popups;
using Windows.UI.ViewManagement;

namespace PontoFacil.ViewModels
{
    public class SettingsPageViewModel : ViewModelBase
    {
        #region Properties
        private bool _lunchTimeOneHour;
        public bool LunchTimeOneHour
        {
            get { return this._lunchTimeOneHour; }
            set { SetProperty(ref _lunchTimeOneHour, value); }
        }

        private bool _lunchTimeTwoHour;
        public bool LunchTimeTwoHour
        {
            get { return this._lunchTimeTwoHour; }
            set { SetProperty(ref _lunchTimeTwoHour, value); }
        }

        private Profile _profile;
        public Profile Profile
        {
            get { return _profile; }
            set { SetProperty(ref _profile, value); }
        }

        public DelegateCommand SaveCommand { get; private set; }

        private ISettingsService _settingsService;

        private ResourceLoader resourceLoader;

        private StringBuilder sbValidationMessages;
        #endregion

        #region Constructor
        public SettingsPageViewModel(ISettingsService settingsService)
        {
            _settingsService = settingsService;

            resourceLoader = new ResourceLoader();

            Profile = _settingsService.GetProfile();

            LunchTimeOneHour = Profile.LunchTime == 1;
            LunchTimeTwoHour = !LunchTimeOneHour;

            ApplicationView.GetForCurrentView().SetPreferredMinSize(new Size(500, 1000));

            InicializeCommands();
        }
        #endregion

        #region Commands
        private void InicializeCommands()
        {
            SaveCommand = new DelegateCommand(ActionSave);
        }

        private async void ActionSave()
        {
            string message;

            if (ValidateFields())
            {
                SetFirstAccess();

                Profile.LunchTime = (byte)(LunchTimeOneHour ? 1 : 2);
                _settingsService.Save(Profile);

                message = resourceLoader.GetString("SaveSuccess");
            }
            else
                message = sbValidationMessages.ToString();

            var dialog = new MessageDialog(message);
            await dialog.ShowAsync();
        }
        #endregion

        #region Methods
        private bool ValidateFields()
        {
            sbValidationMessages = new StringBuilder();
            string message;

            if (!FormatHourIsValid(Profile.AccumuletedHours))
            {
                message = resourceLoader.GetString("FormatInvalidFieldAccumuletedHours");
                sbValidationMessages.AppendLine(message);
            }

            return sbValidationMessages.Length == 0;
        }

        private bool FormatHourIsValid(string hour)
        {
            return Regex.IsMatch(hour, @"\d{1,4}:\d{2}");
        }

        private void SetFirstAccess()
        {
            var localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
            localSettings.Values["SettingsOk"] = true;
        }
        #endregion
    }
}
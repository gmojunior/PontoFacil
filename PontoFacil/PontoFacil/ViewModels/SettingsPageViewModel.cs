using PontoFacil.Models;
using PontoFacil.Services.Interfaces;
using Prism.Commands;
using Prism.Windows.Mvvm;
using System;
using System.Text;
using System.Text.RegularExpressions;
using Windows.ApplicationModel.Resources;
using Windows.UI.Popups;

namespace PontoFacil.ViewModels
{
    public class SettingsPageViewModel : ViewModelBase
    {
        #region Properties
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

        #region Constants
            private const string PATTERN_HOUR_FORMAT = @"\d{1,4}:\d{2}";
            private const string MESSAGE_SAVE_SUCCESS = "SaveSuccess";
            private const string MESSAGE_INVALID_FORMAT_ACCUMULATED_HOURS = "FormatInvalidFieldAccumulatedHours";
        #endregion

        #region Constructor
        public SettingsPageViewModel(ISettingsService settingsService)
        {
            _settingsService = settingsService;

            resourceLoader = new ResourceLoader();

            Profile = _settingsService.GetProfile();

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

                _settingsService.Save(Profile);

                message = resourceLoader.GetString(MESSAGE_SAVE_SUCCESS);
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
                message = resourceLoader.GetString(MESSAGE_INVALID_FORMAT_ACCUMULATED_HOURS);
                sbValidationMessages.AppendLine(message);
            }

            return sbValidationMessages.Length == 0;
        }

        private bool FormatHourIsValid(string hour)
        {
            return Regex.IsMatch(hour, PATTERN_HOUR_FORMAT);
        }

        private void SetFirstAccess()
        {
            var localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
            localSettings.Values["SettingsOk"] = true;
        }
        #endregion
    }
}
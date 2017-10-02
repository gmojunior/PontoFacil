﻿using PontoFacil.Models;
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
        private bool _lunchTimeOne;
        public bool LunchTimeOne
        {
            get { return this._lunchTimeOne; }
            set { SetProperty(ref _lunchTimeOne, value); }
        }

        private bool _lunchTimeTwo;
        public bool LunchTimeTwo
        {
            get { return this._lunchTimeTwo; }
            set { SetProperty(ref _lunchTimeTwo, value); }
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

            LunchTimeOne = Profile.LunchTime == 1;
            LunchTimeTwo = !LunchTimeOne;

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

                Profile.LunchTime = (byte)(LunchTimeOne ? 1 : 2);
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

            if (!FormatHourIsValidd(Profile.AccumuletedHours))
            {
                message = resourceLoader.GetString("FormatInvalidFieldAccumuletedHours");
                sbValidationMessages.AppendLine(message);
            }

            return sbValidationMessages.Length == 0;
        }

        private bool FormatHourIsValidd(string hour)
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
using PontoFacil.Models;
using PontoFacil.Services.Interfaces;
using Prism.Commands;
using Prism.Windows.Mvvm;
using System;
using System.Text;
using Windows.ApplicationModel.Resources;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls;

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
        private const string MESSAGE_SAVE_SUCCESS = "SaveSuccess";
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

            if (Profile.IsValid())
            {
                SetFirstAccess();
                _settingsService.Save(Profile);
                message = resourceLoader.GetString(MESSAGE_SAVE_SUCCESS);
            }
            else
                message = Profile.MessagesValidator.ToString();

            var dialog = new MessageDialog(message);
            await dialog.ShowAsync();
        }
        #endregion

        #region Methods
        private void SetFirstAccess()
        {
            var localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
            localSettings.Values["SettingsOk"] = true;
        }

        public void TextBox_TextChanging(TextBox sender, TextBoxTextChangingEventArgs args)
        {
            if (!IsANumber(sender.Text) && sender.Text != "")
                RemoveLastAddedChar(sender, sender.SelectionStart - 1);
        }

        private static void RemoveLastAddedChar(TextBox sender, int position)
        {
            sender.Text = sender.Text.Remove(position, 1);
            sender.SelectionStart = position + 1;
        }

        private static bool IsANumber(string text)
        {
            return !string.IsNullOrWhiteSpace(text) && double.TryParse(text, out double dtemp);
        }
        #endregion
    }
}
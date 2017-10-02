using PontoFacil.Models;
using PontoFacil.Services;
using Prism.Commands;
using Prism.Windows.Mvvm;
using System;
using System.Text;
using System.Text.RegularExpressions;
using Windows.Foundation;
using Windows.UI.Popups;
using Windows.UI.ViewManagement;

namespace PontoFacil.ViewModels
{
    public class SettingsPageViewModel : ViewModelBase
    {
        #region Properties
        private StringBuilder sbMessages;

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
        #endregion

        #region Constructor
        public SettingsPageViewModel(ISettingsService settingsService)
        {
            _settingsService = settingsService;

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
            MessageDialog dialog;

            if (IsValid())
            {
                var localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
                localSettings.Values["SettingsOk"] = true;

                Profile.LunchTime = (byte)(LunchTimeOne ? 1 : 2);
                _settingsService.Save(Profile);

                dialog = new MessageDialog("Configurações salvas com sucesso!");
            }
            else
                dialog = new MessageDialog(sbMessages.ToString());
           
            await dialog.ShowAsync();
        }
        #endregion

        #region Methods
        private bool IsValid()
        {
            sbMessages = new StringBuilder();
            if (!Regex.IsMatch(Profile.AccumuletedHours, @"\d{1,4}:\d{2}"))
                sbMessages.AppendLine("Campo \"Horas acumuladas\" com formato inválido");

            return sbMessages.Length == 0;
        }
        #endregion
    }
}
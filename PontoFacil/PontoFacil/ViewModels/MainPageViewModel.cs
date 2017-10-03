using Prism.Commands;
using Prism.Windows.Mvvm;
using Prism.Windows.Navigation;
using System;
using Windows.UI.Xaml;

namespace PontoFacil.ViewModels
{
    class MainPageViewModel : ViewModelBase
    {
        private bool isMenuOpen;
        public bool IsMenuOpen
        {
            get { return isMenuOpen; }
            set { SetProperty(ref isMenuOpen, value); }
        }

        private Visibility _isMenuVisible;
        public Visibility IsMenuVisible
        {
            get { return _isMenuVisible; }
            set { SetProperty(ref _isMenuVisible, value); }
        }

        private INavigationService navigationService;

        public DelegateCommand HamburguerCommand { get; private set; }
        public DelegateCommand HomeNavigateCommand { get; private set; }
        public DelegateCommand PlanningNavigateCommand { get; private set; }
        public DelegateCommand HistoryNavigateCommand { get; private set; }
        public DelegateCommand SettingsNavigateCommand { get; private set; }

        public MainPageViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;

            CollapseMenuIfSettingsIsNotOK();

            isMenuOpen = false;

            InitializeCommands();
        }

        private void CollapseMenuIfSettingsIsNotOK()
        {
            var localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
            Object settingsOk = localSettings.Values["SettingsOk"];
            if (settingsOk == null)
                IsMenuVisible = Visibility.Collapsed;
            else
                IsMenuVisible = Visibility.Visible;
        }

        private void InitializeCommands()
        {
            this.HamburguerCommand = new DelegateCommand(HamburguerCommandAction);
            this.HomeNavigateCommand = new DelegateCommand(HomeCommand);
            this.PlanningNavigateCommand = new DelegateCommand(PlanningCommand);
            this.HistoryNavigateCommand = new DelegateCommand(HistoryCommand);
            this.SettingsNavigateCommand = new DelegateCommand(SettingsCommand);
        }

        private void HamburguerCommandAction()
        {
            IsMenuOpen = !IsMenuOpen;
        }

        private void HomeCommand()
        {
            navigationService.Navigate(PageTokens.CurrentDate, null);
        }

        private void PlanningCommand()
        {
            navigationService.Navigate(PageTokens.Planning, null);
        }

        private void HistoryCommand()
        {
            navigationService.Navigate(PageTokens.History, null);
        }

        private void SettingsCommand()
        {
            navigationService.Navigate(PageTokens.Settings, null);
        }
    }
}
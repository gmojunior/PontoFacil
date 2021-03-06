﻿using PontoFacil.Models;
using PontoFacil.Services.Interfaces;
using Prism.Commands;
using Prism.Windows.Mvvm;
using Windows.UI.Xaml.Controls;

namespace PontoFacil.ViewModels
{
    public class PlanningPageViewModel : ViewModelBase
    {
        #region Properties
        private Planning _planning;
        public Planning Planning
        {
            get { return _planning; }
            set { SetProperty(ref _planning, value); }
        }

        private Profile _profile;
        public Profile Profile
        {
            get { return _profile; }
            set { SetProperty(ref _profile, value); }
        }

        private IPlanningService _planningService;
        private ISettingsService _settingsService;

        public DelegateCommand SaveCommand { get; private set; }
        #endregion
        
        #region Construcutor
        public PlanningPageViewModel(IPlanningService planningService, ISettingsService settingsService)
        {
            _planningService = planningService;
            _settingsService = settingsService;

            InicializeCommands();

            Planning = _planningService.GetPlanning();
            Profile = _settingsService.GetProfile();
        }

        private void InicializeCommands()
        {
            SaveCommand = new DelegateCommand(ActionSave);
        }

        private void ActionSave()
        {
            _planningService.Save(Planning);
        }
        #endregion

        #region Methods
        public void TextBox_TextChanging(TextBox sender, TextBoxTextChangingEventArgs args)
        {
            if (!IsANumber(sender.Text))
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

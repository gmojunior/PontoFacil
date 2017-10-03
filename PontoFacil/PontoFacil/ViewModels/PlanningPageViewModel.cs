using PontoFacil.Models;
using PontoFacil.Services;
using Prism.Commands;
using Prism.Windows.Mvvm;
using System;

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

        private IPlanningService _planningService;

        public DelegateCommand SaveCommand { get; private set; }
        #endregion

        #region Construcutor
        public PlanningPageViewModel(IPlanningService planningService)
        {
            _planningService = planningService;

            InicializeCommands();

            Planning = _planningService.GetPlanning();
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
    }
}

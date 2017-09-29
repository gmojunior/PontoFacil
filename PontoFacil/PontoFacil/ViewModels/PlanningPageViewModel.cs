using PontoFacil.Models;
using PontoFacil.Services;
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
        #endregion

        #region Construcutor
        public PlanningPageViewModel(IPlanningService planningService)
        {
            _planningService = planningService;

            Planning = _planningService.GetPlanning();
        }

        private void ActionSave()
        {
            _planningService.Save(Planning);
        }
        #endregion
    }
}

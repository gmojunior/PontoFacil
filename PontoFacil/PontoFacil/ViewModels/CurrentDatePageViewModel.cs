using PontoFacil.Services;
using Prism.Commands;
using Prism.Windows.Mvvm;
using System;

namespace PontoFacil.ViewModels
{
    public class CurrentDatePageViewModel : ViewModelBase
    {
        #region Properties
        private IClockInService _clockInService;
        #endregion

        public CurrentDatePageViewModel(IClockInService clockInService)
        {
            _clockInService = clockInService;
            InitializeCommands();
        }

        private void InitializeCommands()
        {
            RegisterTimeCommand = new DelegateCommand(RegisterTime);
        }

        private void RegisterTime()
        {
            _clockInService.Register(DateTime.Now);
        }

        public DelegateCommand RegisterTimeCommand { get; private set; }
    }
}

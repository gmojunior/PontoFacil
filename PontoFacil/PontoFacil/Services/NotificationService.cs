using PontoFacil.Models;
using PontoFacil.Services.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;
using Windows.ApplicationModel.Background;
using Windows.UI.Xaml;

namespace PontoFacil.Services
{
    public class NotificationService : INotificationService
    {
        #region Properties
        private IPersistencyService _persistencyService;
        #endregion

        #region Constructor
        public NotificationService(IPersistencyService persistencyService)
        {
            _persistencyService = persistencyService;
        }
        #endregion

        #region Methods
        public void createNotificationTask(ClockIn clockIn)
        {
            // TODO Get RegularHours + LunchTime - NotificationTime (in minutes)
            TimeSpan timeToLeave = new TimeSpan(0, 1, 0);
            UpdateProgressBarAsync(new Progress<ClockIn>(UpdateClockInNotificationFlag), clockIn, timeToLeave);
        }

        private void UpdateClockInNotificationFlag(ClockIn obj)
        {
            obj.ShowNotification = true;
        }

        private async void UpdateProgressBarAsync(IProgress<ClockIn> progress, ClockIn clockIn, TimeSpan timeToLeave)
        {
            await Task.Run(async () =>
            {
                try
                {
                    await Task.Delay(Int32.Parse(timeToLeave.TotalMilliseconds.ToString()));
                    progress.Report(clockIn);
                }
                catch (Exception e)
                {
                    //TODO
                }
            });
        }
        #endregion
    }
}
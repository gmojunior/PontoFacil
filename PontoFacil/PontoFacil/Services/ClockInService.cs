using PontoFacil.Models;
using PontoFacil.Services.Interfaces;
using System;
using Windows.ApplicationModel.Resources;


#if !WINRT_NOT_PRESENT
# endif

namespace PontoFacil.Services
{
    public class ClockInService : IClockInService
    {
        #region Properties
        private ClockIn _clockIn;

        private IPersistencyService _persistencyService;

        private INotificationService _notificationService;

        private ResourceLoader resourceLoader;
        #endregion

        #region Constants
        private const string MESSAGE_CLOCKIN_REMINDER = "ClockInReminder";
        #endregion

        #region Constructor
        public ClockInService(IPersistencyService persistencyService, INotificationService notificationService)
        {
            _persistencyService = persistencyService;
            _notificationService = notificationService;

            resourceLoader = new ResourceLoader();

            _clockIn = _persistencyService.getClockInById(DateTime.Now.Date);
        }
        #endregion

        #region Methods
        public ClockIn Register(DateTime date)
        {
            if (_clockIn != null && _clockIn.IsOpen())
                EndCurrentDay(date);
            else
            {
                StartNewDay(date);
                _notificationService.CreateNotificationTask(GetTimeToLeave(), resourceLoader.GetString(MESSAGE_CLOCKIN_REMINDER));
            }

            return _clockIn;
        }

        private TimeSpan GetTimeToLeave()
        {
            TimeSpan regular = _clockIn.RegularHours;
            TimeSpan lunch = _clockIn.GetLunchTime();
            int notification = _persistencyService.getProfile().NotifyTime;

            return new TimeSpan(regular.Hours + lunch.Hours, regular.Minutes + lunch.Minutes - notification, 0);
        }

        private void StartNewDay(DateTime dt)
        {
            _clockIn = new ClockIn();

            _clockIn.Open(dt, _persistencyService.getProfile().LunchTime);
            _clockIn = _persistencyService.SaveClockIn(_clockIn);
        }

        private void EndCurrentDay(DateTime dt)
        {
            _clockIn.Close(dt);
            _persistencyService.SaveClockIn(_clockIn);
        }

        public ClockIn getClockInById(DateTime datetime)
        {
            return _persistencyService.getClockInById(datetime);
        }

        public TimeSpan getEstimatedTimeToLeave()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}

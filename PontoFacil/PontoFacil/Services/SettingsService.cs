using PontoFacil.Models;
using PontoFacil.Services.Interfaces;
using System;

namespace PontoFacil.Services
{
    public class SettingsService : ISettingsService
    {
        #region Properties
        private IPersistencyService _persistencyService;
        private readonly int HOURS_OF_A_DAY = 24;
        private readonly string HOURS_SEPARATOR = @":";
        #endregion

        #region Constructor
        public SettingsService(IPersistencyService persistencyService)
        {
            _persistencyService = persistencyService;
        }
        #endregion

        #region Methods
        public Profile GetProfile()
        {
            return _persistencyService.getProfile();
        }

        public void Save(Profile profile)
        {
            _persistencyService.SaveProfile(profile);
        }

        public void UpdateProfileAcumulatedHours(TimeSpan overtimeHours)
        {
            Profile profile = _persistencyService.getProfile();

            profile.AccumuletedHours = CalculateAccumulatedHours(profile.AccumuletedHours, overtimeHours);
            
            _persistencyService.SaveProfile(profile);
        }

        private string CalculateAccumulatedHours(string accumuletedHours, TimeSpan overtimeHours)
        {
            int hours = 0;
            Int32.TryParse(accumuletedHours.Split(':')[0], out hours);

            int minutes = 0;
            Int32.TryParse(accumuletedHours.Split(':')[1], out minutes);

            int seconds = 0;

            TimeSpan totalHours = new TimeSpan(hours, minutes, seconds);
            
            totalHours = totalHours + overtimeHours;
            
            string totalHoursText = GetTimeSpanFormatedToString(totalHours);
            if (totalHours < TimeSpan.Zero)
            {
                totalHoursText = "-" + totalHoursText;
            }

            return totalHoursText;
        }

        private string GetTimeSpanFormatedToString(TimeSpan totalTime)
        {
            string timeFormated;
            int hoursOfTheDays = totalTime.Days * HOURS_OF_A_DAY;
            string totalHours = (hoursOfTheDays + totalTime.Hours).ToString();
            string totalMinutes = totalTime.Minutes.ToString();

            timeFormated = totalHours + HOURS_SEPARATOR + totalMinutes;
            
            return timeFormated;
        }

        public string GetProfileAccumulatedHours()
        {
            Profile profile = _persistencyService.getProfile();
            
            return profile.AccumuletedHours;
        }
        #endregion
    }
}

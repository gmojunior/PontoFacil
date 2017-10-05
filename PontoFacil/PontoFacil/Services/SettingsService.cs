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

            profile.AccumulatedHours = CalculateAccumulatedHours(profile.AccumulatedHours, overtimeHours);
            
            _persistencyService.SaveProfile(profile);
        }

        private string CalculateAccumulatedHours(string accumuletedHours, TimeSpan overtimeHours)
        {
            int hours = 0;
            Int32.TryParse(accumuletedHours?.Split(':')[0], out hours);

            int minutes = 0;
            Int32.TryParse(accumuletedHours?.Split(':')[1], out minutes);

            int seconds = 0;

            TimeSpan totalHours = new TimeSpan(hours, minutes, seconds);
            
            totalHours = totalHours + overtimeHours;
            
            string totalHoursText = GetTimeSpanFormatedToString(totalHours);

            return totalHoursText;
        }

        private string GetTimeSpanFormatedToString(TimeSpan totalTime)
        {
            string timeFormated;
            int hoursOfTheDays = totalTime.Days * HOURS_OF_A_DAY;
            string totalHours = (hoursOfTheDays + totalTime.Hours).ToString("D2");
            int totalMinutes = totalTime.Minutes < 0 ? totalTime.Negate().Minutes : totalTime.Minutes;
            string totalMinutesText = totalMinutes.ToString("D2");

            timeFormated = totalHours + HOURS_SEPARATOR + totalMinutesText;
            
            return timeFormated;
        }

        public string GetProfileAccumulatedHours()
        {
            Profile profile = _persistencyService.getProfile();
            
            return profile.AccumulatedHours;
        }
        #endregion
    }
}

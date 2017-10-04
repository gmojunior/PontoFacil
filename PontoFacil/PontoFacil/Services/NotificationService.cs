using PontoFacil.Models;
using PontoFacil.Services.Interfaces;
using System;
using Windows.ApplicationModel.Resources;
using Windows.Data.Xml.Dom;
using Windows.UI.Notifications;

namespace PontoFacil.Services
{
    public class NotificationService : INotificationService
    {
        #region Properties
        private IPersistencyService _persistencyService;
        
        private ResourceLoader resourceLoader;
        #endregion
        
        #region Constants
        private const string MESSAGE_REMINDER = "Reminder";
        
        private const string MESSAGE_STRUCTURE = "<toast><visual><binding template=\"ToastGeneric\"><text>{0}</text><text>{1}</text></binding></visual></toast>";
        #endregion

        #region Constructor
        public NotificationService(IPersistencyService persistencyService)
        {
            _persistencyService = persistencyService;

            resourceLoader = new ResourceLoader();
        }
        #endregion

        #region Methods
        public void CreateNotificationTask(TimeSpan timeToLeave, string message)
        {
            DateTime alarmTime = DateTime.Now + timeToLeave;
            var scheduledNotif = new ScheduledToastNotification(CreateStructuredMessage(message), alarmTime);

            ToastNotificationManager.CreateToastNotifier().AddToSchedule(scheduledNotif);
        }

        private XmlDocument CreateStructuredMessage(string message)
        {
            XmlDocument doc = new XmlDocument();

            doc.LoadXml(GetMessage(message));

            return doc;
        }

        private string GetMessage(string message)
        {
            return String.Format(MESSAGE_STRUCTURE, resourceLoader.GetString(MESSAGE_REMINDER), message);
        }
        #endregion
    }
}
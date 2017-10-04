using System;

namespace PontoFacil.Services.Interfaces
{
    public interface INotificationService
    {
        void CreateNotificationTask(TimeSpan timeToLeave, string message);
    }
}
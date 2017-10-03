using PontoFacil.Models;

namespace PontoFacil.Services.Interfaces
{
    public interface INotificationService
    {
        void createNotificationTask(ClockIn clockIn);
    }
}
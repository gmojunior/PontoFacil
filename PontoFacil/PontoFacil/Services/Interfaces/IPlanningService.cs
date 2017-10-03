using PontoFacil.Models;

namespace PontoFacil.Services.Interfaces
{
    public interface IPlanningService
    {
        Planning GetPlanning();
        void Save(Planning planning);
        Planning GetPlanningByDate();
    }
}
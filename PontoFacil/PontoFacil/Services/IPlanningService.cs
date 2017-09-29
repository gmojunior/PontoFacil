using PontoFacil.Models;

namespace PontoFacil.Services
{
    public interface IPlanningService
    {
        Planning GetPlanning();

        void Save(Planning planning);
    }
}
using PontoFacil.Models;

namespace PontoFacil.Services.Interfaces
{
    public interface ISettingsService
    {
        void Save(Profile profile);
        Profile GetProfile();
    }
}
using PontoFacil.Models;

namespace PontoFacil.Services
{
    public interface ISettingsService
    {
        string GetName();
        void Save(Profile profile);
        Profile GetProfile();
    }
}
using PontoFacil.Models;

namespace PontoFacil.Services
{
    public interface ISettingsService
    {
        void Save(Profile profile);
        Profile GetProfile();
    }
}
using PontoFacil.Models;
using System;

namespace PontoFacil.Services.Interfaces
{
    public interface ISettingsService
    {
        bool Save(Profile profile, out string messageValidator);
        Profile GetProfile();
        void UpdateProfileAcumulatedHours(TimeSpan overtimeHours);
        string GetProfileAccumulatedHours();
    }
}
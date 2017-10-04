using PontoFacil.Models;
using System;

namespace PontoFacil.Services.Interfaces
{
    public interface ISettingsService
    {
        void Save(Profile profile);
        Profile GetProfile();
        void UpdateProfileAcumulatedHours(TimeSpan overtimeHours);
        string GetProfileAccumulatedHours();
    }
}
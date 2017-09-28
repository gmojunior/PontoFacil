using System;

namespace PontoFacil.Services
{
    interface IClockInService
    {
        void Register(DateTime date);

        void StartNewDay(DateTime datetime);

        void EndCurrentDay(DateTime datetime);
    }
}
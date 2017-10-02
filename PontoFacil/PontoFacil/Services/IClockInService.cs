using PontoFacil.Models;
using System;

namespace PontoFacil.Services
{
    public interface IClockInService
    {
        void Register(DateTime date);

        ClockIn getClockInById(DateTime datetime);
    }
}
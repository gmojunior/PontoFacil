using PontoFacil.Models;
using System;

namespace PontoFacil.Services.Interfaces
{
    public interface IClockInService
    {
        ClockIn Register(DateTime date);
        ClockIn getClockInById(DateTime datetime);
        TimeSpan getEstimatedTimeToLeave();
    }
}
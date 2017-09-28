using System.Collections.Generic;
using PontoFacil.Models;

namespace PontoFacil.Repositories
{
    public interface IRepository
    {
        List<ClockIn> ClockInList { get; set; }
        Planning MyPlanning { get; set; }
        Profile MyProfile { get; set; }
    }
}
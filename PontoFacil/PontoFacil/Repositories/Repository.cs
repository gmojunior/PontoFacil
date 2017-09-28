using PontoFacil.Models;
using System.Collections.Generic;

namespace PontoFacil.Repositories
{
    public class Repository : IRepository
    {
        private List<ClockIn> clockInList;
        public List<ClockIn> ClockInList
        {
            get { return clockInList; }
            set { clockInList = value; }
        }

        private Planning myPlanning;
        public Planning MyPlanning
        {
            get { return myPlanning; }
            set { myPlanning = value; }
        }

        private Profile myProfile;
        public Profile MyProfile
        {
            get { return myProfile; }
            set { myProfile = value; }
        }

        public Repository()
        {
            this.ClockInList = new List<ClockIn>();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontoFacil.Models
{
    public class Profile
    {
        #region Properties
        private string name;

        public string Name
        {
            get { return this.name; }
            set { name = value; }
        }

        private DateTime defaultBegin;

        public DateTime DefaultBegin
        {
            get { return this.defaultBegin; }
            set { defaultBegin = value; }
        }

        private DateTime lunchPeriod;

        public DateTime LunchPeriod {
            get { return lunchPeriod; }
            set { lunchPeriod = value;  }
        }
        
        private DateTime defaultFinish;

        public DateTime DefaultFinish
        {
            get { return this.defaultFinish; }
            set { defaultFinish = value; }
        }
        
        private DateTime accumulatedHours;

        public DateTime AccumulatedHours
        {
            get { return this.accumulatedHours; }
            set { accumulatedHours = value; }
        }
        #endregion
    }
}
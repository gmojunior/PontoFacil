using Newtonsoft.Json;
using PontoFacil.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Windows.Storage;

namespace PontoFacil.Services
{
    public class PersistencyService : IPersistencyService
    {
        #region Properties
        private readonly string DATA_FILE_NAME = "PontoFacilData.txt";
        private readonly string PATH_SEPARATOR = @"\";
        private readonly string DATABASE_FOLDER = ApplicationData.Current.LocalFolder.Path;
        private string DATABASE_PATH;

        private object lockFileWriter;

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

        private IPersistencyService _persistencyService;

        #endregion

        #region Construcutor
        public PersistencyService(IPersistencyService persistencyService)
        {
            this._persistencyService = persistencyService;

            DATABASE_PATH = DATABASE_FOLDER + PATH_SEPARATOR + DATA_FILE_NAME;

            this.clockInList = new List<ClockIn>();

            this.lockFileWriter = new object();
        }
        #endregion

        #region Methods
        public void Persist()
        {
            Task.Run(() =>
            {
                lock (lockFileWriter)
                {
                    File.WriteAllText(DATABASE_PATH, JsonConvert.SerializeObject(_persistencyService));
                }
            });

        }

        public void Restore()
        {
            try
            {
                if (File.Exists(DATABASE_PATH))
                {
                    string result = File.ReadAllText(DATABASE_PATH);
                    _persistencyService = JsonConvert.DeserializeObject<PersistencyService>(result);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public ClockIn SaveClockIn(ClockIn clockIn)
        {
            if (clockIn.Id == null)
            {
                clockIn.Id = DateTime.Now.Date;
                _persistencyService.ClockInList.Add(clockIn);
            }
            else
            {
                int index = _persistencyService.ClockInList.FindIndex(ci => ci.Id == clockIn.Id);
                _persistencyService.ClockInList.Insert(index, clockIn);
            }
            this.Persist();

            return clockIn;
        }

        public Planning SavePlanning(Planning planning)
        {
            _persistencyService.MyPlanning = planning;
            this.Persist();

            return planning;
        }

        public Profile SaveProfile(Profile profile)
        {
            _persistencyService.MyProfile = profile;
            this.Persist();

            return profile;
        }

        public ClockIn getClockInById(DateTime datetime)
        {
            return _persistencyService.ClockInList.Find(ci => ci.Id == datetime);
        }

        public Planning getPlanning()
        {
            return _persistencyService.MyPlanning;
        }

        public Profile getProfile()
        {
            return _persistencyService.MyProfile;
        }
        #endregion
    }
}

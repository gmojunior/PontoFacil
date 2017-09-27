using Newtonsoft.Json;
using PontoFacil.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Windows.Storage;

namespace PontoFacil.Services
{
    class PersistencyService : IPersistencyService
    {
        #region Properties
        private readonly string DATA_FILE_NAME = "PontoFacilData.txt";
        private readonly string PATH_SEPARATOR = @"\";
        private readonly string DATABASE_FOLDER = ApplicationData.Current.LocalFolder.Path;
        private string DATABASE_PATH;

        private object lockFileWriter;

        private static PersistencyService persistencyService;

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

        #endregion

        #region Construcutor
        private PersistencyService()
        {
            DATABASE_PATH = DATABASE_FOLDER + PATH_SEPARATOR + DATA_FILE_NAME;

            this.clockInList = new List<ClockIn>();

            this.lockFileWriter = new object();
        }

        public static PersistencyService getInstance()
        {
            if (persistencyService == null)
                persistencyService = new PersistencyService();
            return persistencyService;
        }
        #endregion

        #region Methods
        public void Persist()
        {

            Task.Run(() =>
            {
                lock (lockFileWriter)
                {
                    File.WriteAllText(DATABASE_PATH, JsonConvert.SerializeObject(persistencyService));
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
                    persistencyService = JsonConvert.DeserializeObject<PersistencyService>(result);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void SaveClockIn(ClockIn clockIn)
        {
            persistencyService.clockInList.Add(clockIn);
            this.Persist();
        }

        public void SavePlanning(Planning planning)
        {
            persistencyService.MyPlanning = planning;
            this.Persist();
        }

        public void SaveProfile(Profile profile)
        {
            persistencyService.MyProfile = profile;
            this.Persist();
        }

        public ClockIn getClockInById(DateTime datetime)
        {
            ClockIn result = null;
            return result;
        }

        public Profile getProfile()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}

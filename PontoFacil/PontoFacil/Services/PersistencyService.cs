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
        private readonly string PATH_SEPARTOR = @"\";
        private readonly string DATABASE_FOLDER = ApplicationData.Current.LocalFolder.Path;
        private string DATABASE_PATH;

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
            DATABASE_PATH = DATABASE_FOLDER + PATH_SEPARTOR + DATA_FILE_NAME;

            this.clockInList = new List<ClockIn>();
        }

        public static PersistencyService getInstance()
        {
            if (persistencyService == null)
                persistencyService = new PersistencyService();
            return persistencyService;
        }
        #endregion

        #region Methods
        public async Task persist()
        {
            await Task.Run(() =>
                File.WriteAllText(DATABASE_PATH, JsonConvert.SerializeObject(persistencyService))
            );
        }

        public void restore()
        {
            try
            {
                string result = File.ReadAllText(DATABASE_PATH);
                persistencyService = JsonConvert.DeserializeObject<PersistencyService>(result);
            }
            catch (FileNotFoundException fileNotFoundException)
            {
                Console.WriteLine(fileNotFoundException.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void saveClockIn(ClockIn clockIn)
        {
            persistencyService.clockInList.Add(clockIn);
        }

        public void savePlanning(Planning planning)
        {
            persistencyService.MyPlanning = planning;
        }

        public void saveProfile(Profile profile)
        {
            persistencyService.MyProfile = profile;
        }
        #endregion
    }
}

using Newtonsoft.Json;
using PontoFacil.Models;
using PontoFacil.Repositories;
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
        private IRepository _repository;

        private readonly string DATA_FILE_NAME = "PontoFacilData.txt";
        private readonly string PATH_SEPARATOR = @"\";
        private readonly string DATABASE_FOLDER = ApplicationData.Current.LocalFolder.Path;
        private readonly string DATABASE_PATH;
        private readonly DateTime FIRST_DAY_OF_THE_MONTH;
        private readonly DateTime TODAY;

        private object lockFileWriter;

        #endregion

        #region Construcutor
        public PersistencyService(IRepository repository)
        {
            _repository = repository;
            FIRST_DAY_OF_THE_MONTH = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            TODAY = DateTime.Now.Date;

            DATABASE_PATH = DATABASE_FOLDER + PATH_SEPARATOR + DATA_FILE_NAME;
            
            Restore();

            lockFileWriter = new object();
        }
        #endregion

        #region Methods
        public void Persist()
        {
            Task.Run(() =>
            {
                lock (lockFileWriter)
                {
                    File.WriteAllText(DATABASE_PATH, JsonConvert.SerializeObject(_repository));
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
                    _repository = JsonConvert.DeserializeObject<Repository>(result);
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
                _repository.ClockInList.Add(clockIn);
            }
            else
            {
                int index = _repository.ClockInList.FindIndex(0, _repository.ClockInList.Count, ci => ci.Id.Equals(clockIn.Id));
                _repository.ClockInList[index] = clockIn;
            }

            Persist();

            return clockIn;
        }

        private bool ae()
        {
            return true;
        }
        public Planning SavePlanning(Planning planning)
        {
            _repository.MyPlanning = planning;
            Persist();

            return planning;
        }

        public Profile SaveProfile(Profile profile)
        {
            _repository.MyProfile = profile;
            Persist();

            return profile;
        }

        public ClockIn getClockInById(DateTime datetime)
        {
            return _repository.ClockInList.Find(ci => ci.Id.Equals(datetime));
        }

        public Planning getPlanning()
        {
            Planning p = _repository.MyPlanning;

            return p ?? new Planning();
        }

        public Profile getProfile()
        {
            Profile p = _repository.MyProfile;

            return p ?? new Profile();
        }

        public List<ClockIn> GetMonthlyHistory()
        {
            return _repository.ClockInList.FindAll(ci => CheckIsBetweenDates(ci, FIRST_DAY_OF_THE_MONTH, TODAY));
        }

        private bool CheckIsBetweenDates(ClockIn ci, DateTime start, DateTime end)
        {
            return ci.Id >= start && ci.Id <= end;
        }

        public List<ClockIn> GetFreeHistory(DateTimeOffset startDate, DateTimeOffset endDate)
        {
            DateTime start = startDate.Date;
            DateTime end = endDate.Date;

            return _repository.ClockInList.FindAll(ci => CheckIsBetweenDates(ci, start, end));
        }

        #endregion
    }
}

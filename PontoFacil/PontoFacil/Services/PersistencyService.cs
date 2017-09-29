using Newtonsoft.Json;
using PontoFacil.Models;
using System;
using System.IO;
using System.Threading.Tasks;
using Windows.Storage;
using PontoFacil.Repositories;
using System.Collections;
using System.Collections.Generic;

namespace PontoFacil.Services
{
    public class PersistencyService : IPersistencyService
    {
        #region Properties
        private IRepository _repository;

        private readonly string DATA_FILE_NAME = "PontoFacilData.txt";
        private readonly string PATH_SEPARATOR = @"\";
        private readonly string DATABASE_FOLDER = ApplicationData.Current.LocalFolder.Path;
        private string DATABASE_PATH;

        private object lockFileWriter;

        #endregion

        #region Construcutor
        public PersistencyService()
        {
            DATABASE_PATH = DATABASE_FOLDER + PATH_SEPARATOR + DATA_FILE_NAME;
            
            this.Restore();

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
                else
                {
                    _repository = new Repository();
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
            this.Persist();

            return clockIn;
        }

        public Planning SavePlanning(Planning planning)
        {
            _repository.MyPlanning = planning;
            this.Persist();

            return planning;
        }

        public Profile SaveProfile(Profile profile)
        {
            _repository.MyProfile = profile;
            this.Persist();

            return profile;
        }

        public ClockIn getClockInById(DateTime datetime)
        {
            
            return _repository.ClockInList.Find(ci => ci.Id.Equals(datetime));
        }

        public Planning getPlanning()
        {
            Planning p = _repository.MyPlanning;
            return p != null ? p : new Planning();
        }

        public Profile getProfile()
        {
            Profile p = this._repository.MyProfile;
            return p != null ? p : new Profile();
        }

        public List<ClockIn> GetMonthlyHistory()
        {
            return _repository.ClockInList.FindAll(ci => ci.Id >= new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1) && ci.Id <= DateTime.Now.Date);
        }

        public List<ClockIn> GetFreeHistory(DateTimeOffset startDate, DateTimeOffset endDate)
        {
            return _repository.ClockInList.FindAll(ci => ci.Id >= startDate.Date && ci.Id <= endDate.Date);
        }
        #endregion
    }
}

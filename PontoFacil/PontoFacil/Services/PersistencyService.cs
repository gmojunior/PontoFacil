using Newtonsoft.Json;
using PontoFacil.Models;
using System;
using System.IO;
using System.Threading.Tasks;
using Windows.Storage;
using PontoFacil.Repositories;
using System.Collections;

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
        public PersistencyService(IRepository repository)
        {
            this._repository = repository;

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
                    File.WriteAllText(DATABASE_PATH, JsonConvert.SerializeObject(this._repository));
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
                    this._repository = JsonConvert.DeserializeObject<Repository>(result);
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
                this._repository.ClockInList.Add(clockIn);
            }
            else
            {
                int index = this._repository.ClockInList.FindIndex(0, this._repository.ClockInList.Count, ci => ci.Id.Equals(clockIn.Id));
                this._repository.ClockInList[index] = clockIn;
            }
            this.Persist();

            return clockIn;
        }

        public Planning SavePlanning(Planning planning)
        {
            this._repository.MyPlanning = planning;
            this.Persist();

            return planning;
        }

        public Profile SaveProfile(Profile profile)
        {
            this._repository.MyProfile = profile;
            this.Persist();

            return profile;
        }

        public ClockIn getClockInById(DateTime datetime)
        {
            
            return this._repository.ClockInList.Find(ci => ci.Id.Equals(datetime));
        }

        public Planning getPlanning()
        {
            Planning p = this._repository.MyPlanning;
            return p != null ? p : new Planning();
        }

        public Profile getProfile()
        {
            Profile p = this._repository.MyProfile;
            return p != null ? p : new Profile();
        }
        #endregion
    }
}

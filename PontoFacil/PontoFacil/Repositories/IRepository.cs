using PontoFacil.Models;

namespace PontoFacil.Repositories
{
    public interface IRepository<T>
    {
        void SaveClockIn(T clockIn);
    }
}

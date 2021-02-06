using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataLibrary.DataAccess
{
    public interface ISqlDataAccess
    {
        Task DeleteData<T>(string storedProcedure, T parameters, string connectionStringName);
        string GetConnectionString(string connectionStringName);
        Task<List<T>> LoadData<T, U>(string storedProcedure, U parameters, string connectionStringName);
        Task SaveData<T>(string storedProcedure, T parameters, string connectionStringName);
    }
}
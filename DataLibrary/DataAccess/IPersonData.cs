using DataLibrary.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataLibrary.DataAccess
{
    public interface IPersonData
    {
        Task DeletePerson(int id);
        Task<Person> GetPerson(int id);
        Task<List<Person>> GetPersonAll();
        Task InsertPerson(Person person);
        Task UpdatePerson(Person person);
    }
}
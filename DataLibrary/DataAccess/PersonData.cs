using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.DataAccess
{
    public class PersonData : IPersonData
    {
        private readonly string connectionStringName = "default";
        private readonly ISqlDataAccess _sql;

        public PersonData(ISqlDataAccess sql)
        {
            _sql = sql;
        }


        public async Task InsertPerson(Person person)
        {
            await _sql.SaveData("spPerson_Insert", person, connectionStringName);
        }


        public async Task<List<Person>> GetPersonAll()
        {
            var results = await _sql.LoadData<Person, dynamic>("spPerson_GetAll", new { }, connectionStringName);

            return results;
        }


        public async Task<Person> GetPerson(int id)
        {
            var results = await _sql.LoadData<Person, dynamic>("spPerson_Get", new { id }, connectionStringName);

            return results.FirstOrDefault();
        }


        public async Task UpdatePerson(Person person)
        {
            await _sql.SaveData("spPerson_Update", person, connectionStringName);
        }


        public async Task DeletePerson(int id)
        {
            await _sql.DeleteData("spPerson_Delete", new { id }, connectionStringName);
        }
    }
}

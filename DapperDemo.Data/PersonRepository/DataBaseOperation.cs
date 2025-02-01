using System.Data;
using Dapper;
using DapperDemo.Data.DataAccess;
using DapperDemo.Data.Models;

namespace DapperDemo.Data.PersonRepository
{
    public class DataBaseOperation : IDataBaseOperation
    {
        private readonly ISqlDataAccess _sqlDataAccess;

        public DataBaseOperation(ISqlDataAccess sqlDataAccess)
        {
            _sqlDataAccess = sqlDataAccess;
        }

        public async Task<IEnumerable<PersonModel>> GetAllUser()
        {
            return await _sqlDataAccess.LoadData<PersonModel, dynamic>("dbo.SP_GET_ALL_USERS", new { });
        }

        public async Task<PersonModel> GetPerson(int personID)
        {
            return (await _sqlDataAccess.LoadData<PersonModel, dynamic>("dbo.SP_GET_USER", new { PersonID = personID })).FirstOrDefault()!;
        }

        public async Task<bool> InsertPerson(PersonModel person)
        {
            try
            {
                if (person == null)
                {
                    throw new ArgumentNullException(nameof(person));
                }
                await _sqlDataAccess.SaveData("dbo.SP_CREATE_USER", new { person.FirstName, person.LastName, person.Address, person.City });
                return true;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task UpdatePerson(PersonModel person)
        {
            try
            {
                if (person == null)
                {
                    throw new ArgumentNullException(nameof(person));
                }
                await _sqlDataAccess.SaveData("dbo.SP_UPDATE_USER", new { person.PersonID, person.FirstName, person.LastName, person.Address, person.City });
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task DeletePerson(int personID)
        {
            try
            {
                if (personID <= 0)
                {
                    throw new ArgumentNullException(nameof(personID));
                }
                await _sqlDataAccess.SaveData("dbo.SP_DELETE_USER", new { PersonID = personID });
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<int> GetTotalUser(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@user_id",id, DbType.Int32, ParameterDirection.Input);
            parameters.Add("TotalCount", dbType: DbType.Int32, direction: ParameterDirection.Output);
            return (await _sqlDataAccess.LoadData<int, dynamic>("dbo.SP_GET_TOTALCOUNT", new { })).FirstOrDefault();
        }
    }
}
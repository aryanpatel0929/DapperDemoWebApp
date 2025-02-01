using DapperDemo.Data.Models;

namespace DapperDemo.Data.PersonRepository
{
    public interface IDataBaseOperation
    {
        Task<IEnumerable<PersonModel>> GetAllUser();
        Task<PersonModel> GetPerson(int personID);
        Task<bool> InsertPerson(PersonModel person);
        Task UpdatePerson(PersonModel person);
        Task DeletePerson(int personID);
    }
}
using HallOfFame.Models;

namespace HallOfFame.Interfaces
{
    public interface IHallOfFameService
    {
        Task<List<PersonModel>> GetPersons();
        Task<PersonModel> GetPersonById(int id);
        Task CreatePerson(PersonModel newPerson);
        Task UpdatePerson(PersonModel person);
        Task DeletePerson(int id);
    }
}
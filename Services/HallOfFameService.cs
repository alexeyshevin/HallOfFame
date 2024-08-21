using HallOfFame.Models;
using HallOfFame.Interfaces;
using HallOfFame.Data;
using System.Data.Entity;

namespace HallOfFameServices
{
    public class HallOfFameService : IHallOfFameService
    {
        private readonly HallOfFameDbContext _dbContext;

        // constructor calling
        public HallOfFameService(HallOfFameDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<PersonModel>> GetPersons()
        {
            return await _dbContext.Persons.ToListAsync();
        }

        public async Task<PersonModel> GetPersonById(int id)
        {
            return await _dbContext.Persons.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task CreatePerson(PersonModel newPerson)
        {
            await _dbContext.Persons.AddAsync(newPerson);
            _dbContext.SaveChanges();
        }

        public async Task UpdatePerson(PersonModel person)
        {
            _dbContext.Persons.Update(person);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeletePerson(int id)
        {
            PersonModel entity = _dbContext.Persons.FirstOrDefault(v => v.Id == id);
            if (entity == null)
            {
                return;
            }
            _dbContext.Persons.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
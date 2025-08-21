

using Api.DotNet.Domain.Entities;
using Api.DotNet.Domain.FiltersDb;
using Api.DotNet.Domain.Repositories;
using Api.DotNet.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Api.DotNet.Infra.Data.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly ApplicationDbContext _db;

        public PersonRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<Person> CreateAsync(Person person)
        {
            _db.Add(person);
            await _db.SaveChangesAsync();
            return person;
        }

        public async Task DeleteAsync(Person person)
        {
            _db?.Remove(person);
            await _db.SaveChangesAsync();

        }

        public async Task EditAsync(Person person)
        {
            _db.Update(person);
            await _db.SaveChangesAsync();
        }

        public async Task<Person> GetByIdAsync(int id)
        {
            return await _db.People.FirstOrDefaultAsync(x => x.Id == id);
        }
        

        //public async Task<int> GetIdByDocumentAsync(string document)
        //{
        //    return (await _db.People.FirstOrDefaultAsync(x => x.Document == document))?.Id ?? 0;
        //}

        public async Task<int> GetIdByDocumentAsync(string document)
        {
            var person = await _db.People
                                  .FirstOrDefaultAsync(x => x.Document == document);

            if (person != null)
            {
                return person.Id;
            }
            else
            {
                return 0;
            }
        }

        public async Task<PagedBaseResponse<Person>> GetPagedAsync(PersonFilterDb request)
        {
            var people = _db.People.AsQueryable();
            if (!string.IsNullOrEmpty(request.Name))
                people = people.Where(x => x.Name.Contains(request.Name));

            return  await PagedBaseResponseHelper
                .GetResponseAsync<PagedBaseResponse<Person>, Person>(people, request);
        }

        public async Task<ICollection<Person>> GetPeopleAsync()
        {
            return await _db.People.ToListAsync();
        }
    }
}

using LaibraryForAll.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryForAll.Api.Models
{
    public class PersonRepository : IPersonRepository
    {
        private readonly AppDbContext appDbContext;

        public PersonRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<Person> AddPerson(Person person)
        {
            var personnew = await appDbContext.People.AddAsync(person);
            await appDbContext.SaveChangesAsync();
            return personnew.Entity;
            
        }

        public async Task<IEnumerable<Person>> GetPeople()
        {
            return await appDbContext.People.ToListAsync();
        }

        public async Task<Person> GetPerson(int personId)
        {
            return await appDbContext.People.FirstOrDefaultAsync(p=>p.Id==personId);
        }
    }
}

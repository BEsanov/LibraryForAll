using LaibraryForAll.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryForAll.Api.Models
{
   public interface IPersonRepository
    {
        Task<IEnumerable<Person>> GetPeople();

        Task<Person> GetPerson(int personId);

        Task<Person> AddPerson(Person person);
    }
}

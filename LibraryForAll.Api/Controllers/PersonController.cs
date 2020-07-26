using LaibraryForAll.Models;
using LibraryForAll.Api.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LibraryForAll.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController: ControllerBase
    {
        private readonly IPersonRepository personRepository;

        public PersonController(IPersonRepository personRepository)
        {
            this.personRepository = personRepository;
        }

        [HttpGet]
      public async Task<ActionResult<Person>> GetPersons()
        {
            return Ok(await personRepository.GetPeople());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Person>> GetPerson(int id)
        {
            var result= await personRepository.GetPerson(id);
            return result;
        }

        [HttpPost]
        public async Task<ActionResult> AddPerson(Person person)
        {
            var newperson = await personRepository.AddPerson(person);
            return CreatedAtAction(nameof(GetPerson), new { id = newperson.Id }, newperson);
           
        }
    }
}

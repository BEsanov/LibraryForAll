using LaibraryForAll.Models;
using LibraryForAll.Api.Models;
using Microsoft.AspNetCore.Http;
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
    public class PersonController : ControllerBase
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
            var result = await personRepository.GetPerson(id);
            return result;
        }

        [HttpPost]
        public async Task<ActionResult> AddPerson(Person person)
        {
            var newperson = await personRepository.AddPerson(person);
            return CreatedAtAction(nameof(GetPerson), new { id = newperson.Id }, newperson);

        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Person>> UpdatePersonh(int id, Person person)
        {
            
            try
            {
                var requestedPerson = await personRepository.GetPerson(id);

                return await personRepository.UpdatePerson(person);
              
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from database");
            }



            

            //return  personRepository.UpdatePerson(person);
            //try
            //{
            //   await personRepository.UpdatePerson(person);

            //}
            //catch (Exception)
            //{

            //    throw;
            //}


        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Person>> DeleteThePerson(int id)
        {
            var requestedId = await personRepository.GetPerson(id);

            if (requestedId != null)
            {
                await personRepository.DeletePerson(requestedId);
            }

            return null;
        }
    }
}

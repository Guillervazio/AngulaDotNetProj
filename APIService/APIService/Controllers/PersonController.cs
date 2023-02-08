using APIService.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly DataContext _context;
        public PersonController(DataContext ctx)
        {
            _context = ctx;
        }
        [HttpGet]
        public async Task<ActionResult<List<Person>>> GetPersons()
        {
            return Ok(await _context.Persons.ToListAsync());
        }
        [HttpPost]
        public async Task<ActionResult<List<Person>>> CreatePerson(Person newPerson)
        {
           _context.Persons.Add(newPerson);
            await _context.SaveChangesAsync();

            return Ok(await _context.Persons.ToListAsync());
        }
        [HttpPut]
        public async Task<ActionResult<List<Person>>> UpdatePerson(Person newPerson)
        {
            var dbPerson = await _context.Persons.FindAsync(newPerson.Id);
            if(dbPerson == null)
            {
                return NotFound();
            }
            dbPerson.FirstName= newPerson.FirstName;
            dbPerson.LastName= newPerson.LastName;
            dbPerson.Address = newPerson.Address;
            await _context.SaveChangesAsync();

            return Ok(await _context.Persons.ToListAsync());
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Person>>> DeletePerson(int id)
        {
            var dbPerson = await _context.Persons.FindAsync(id);

            if (dbPerson == null)
            {
                return NotFound();
            }

            _context.Remove(dbPerson); 
            await _context.SaveChangesAsync();
            return Ok(await _context.Persons.ToListAsync());

        }
    }
}

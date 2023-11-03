using AstroCurio.Api.Data;
using AstroCurio.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AstroCurio.Api.Controllers
{
    [ApiController]
    [Route("/api/People")]
    public class PeopleController : ControllerBase
    {
        private readonly DataContext _context;

        public PeopleController(DataContext context)
        {
            _context = context;
        }

        //Get con lista
        //Select * From  Users

        [HttpGet]
        public async Task<ActionResult> Get()
        {

            return Ok(await _context.People.ToListAsync());


        }

        // Get por parámetro
        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {

            //200 Ok

            var person = await _context.People.FirstOrDefaultAsync(x => x.Id == id);

            if (person == null)
            {


                return NotFound();
            }

            return Ok(person);


        }

        // Crear un nuevo registro
        [HttpPost]
        public async Task<ActionResult> Post(Person person)
        {
            _context.Add(person);
            await _context.SaveChangesAsync();
            return Ok(person);
        }

        // Actualizar o cambiar registro

        [HttpPut]
        public async Task<ActionResult> Put(Person person)
        {
            _context.Update(person);
            await _context.SaveChangesAsync();
            return Ok(person);
        }

        // ELiminar registros

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {


            var FilaAfectada = await _context.People
                .Where(x => x.Id == id)//5
                .ExecuteDeleteAsync();

            if (FilaAfectada == 0)
            {


                return NotFound();//404
            }

            return NoContent();//204


        }
    }
}

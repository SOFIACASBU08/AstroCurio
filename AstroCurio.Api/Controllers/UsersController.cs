using AstroCurio.Api.Data;
using AstroCurio.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AstroCurio.Api.Controllers
{
    [ApiController]
    [Route("/api/Users")]
    public class UsersController : ControllerBase
    {
        private readonly DataContext _context;

        public UsersController(DataContext context)
        {
            _context = context;
        }

        //Get con lista
        //Select * From  Users

        [HttpGet]
        public async Task<ActionResult> Get()
        {

            return Ok(await _context.Users.ToListAsync());


        }

        // Get por parámetro
        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(string id)
        {

            //200 Ok

            var User = await _context.Users.FirstOrDefaultAsync(x => x.UserId == id);

            if (User == null)
            {


                return NotFound();
            }

            return Ok(User);


        }

        // Crear un nuevo registro
        [HttpPost]
        public async Task<ActionResult> Post(User User)
        {
            _context.Add(User);
            await _context.SaveChangesAsync();
            return Ok(User);
        }

        // Actualizar o cambiar registro

        [HttpPut]
        public async Task<ActionResult> Put(User User)
        {
            _context.Update(User);
            await _context.SaveChangesAsync();
            return Ok(User);
        }

        // ELiminar registros

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(string id)
        {


            var FilaAfectada = await _context.Users
                .Where(x => x.UserId == id)//5
                .ExecuteDeleteAsync();

            if (FilaAfectada == 0)
            {


                return NotFound();//404
            }

            return NoContent();//204


        }
    }
}

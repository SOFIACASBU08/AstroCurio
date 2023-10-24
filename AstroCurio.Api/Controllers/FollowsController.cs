using AstroCurio.Api.Data;
using AstroCurio.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AstroCurio.Api.Controllers
{

    [ApiController]
    [Route("/api/Follows")]
    public class FollowsController : ControllerBase
    {
        private readonly DataContext _context;

        public FollowsController(DataContext context)
        {
            _context = context;
        }

        //Get con lista
        //Select * From  Follows

        [HttpGet]
        public async Task<ActionResult> Get()
        {

            return Ok(await _context.Follows.ToListAsync());


        }

        // Get por parámetro
        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {

            //200 Ok

            var Follow = await _context.Follows.FirstOrDefaultAsync(x => x.Id == id);

            if (Follow == null)
            {


                return NotFound();
            }

            return Ok(Follow);


        }

        // Crear un nuevo registro
        [HttpPost]
        public async Task<ActionResult> Post(Follow Follow)
        {
            _context.Add(Follow);
            await _context.SaveChangesAsync();
            return Ok(Follow);
        }

        // Actualizar o cambiar registro

        [HttpPut]
        public async Task<ActionResult> Put(Follow Follow)
        {
            _context.Update(Follow);
            await _context.SaveChangesAsync();
            return Ok(Follow);
        }

        // ELiminar registros

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {


            var FilaAfectada = await _context.Follows
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

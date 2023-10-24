using AstroCurio.Api.Data;
using AstroCurio.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AstroCurio.Api.Controllers
{
    [ApiController]
    [Route("/api/Links")]
    public class LinkesController : ControllerBase
    {
        private readonly DataContext _context;

        public LinkesController(DataContext context)
        {
            _context = context;
        }
        //Get con lista
        //Select * From likes

        [HttpGet]
        public async Task<ActionResult> Get()
        {

            return Ok(await _context.Links.ToListAsync());


        }

        // Get por parámetro
        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {

            //200 Ok

            var Link = await _context.Links.FirstOrDefaultAsync(x => x.Id == id);

            if (Link == null)
            {


                return NotFound();
            }

            return Ok(Link);


        }

        // Crear un nuevo registro
        [HttpPost]
        public async Task<ActionResult> Post(Link Link)
        {
            _context.Add(Link);
            await _context.SaveChangesAsync();
            return Ok(Link);
        }

        // Actualizar o cambiar registro

        [HttpPut]
        public async Task<ActionResult> Put(Link Link)
        {
            _context.Update(Link);
            await _context.SaveChangesAsync();
            return Ok(Link);
        }

        // ELiminar registros

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {


            var FilaAfectada = await _context.Links
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

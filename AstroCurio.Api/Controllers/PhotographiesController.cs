using AstroCurio.Api.Data;
using AstroCurio.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AstroCurio.Api.Controllers
{
    [ApiController]
    [Route("/api/Photographies")]
    public class PhotographiesController : ControllerBase
    {
        private readonly DataContext _context;

        public PhotographiesController(DataContext context)
        {
            _context = context;
        }

        //Get con lista
        //Select * From photographies

        [HttpGet]
        public async Task<ActionResult> Get()
        {

            return Ok(await _context.Photographies.ToListAsync());


        }

        // Get por parámetro
        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {

            //200 Ok

            var Photography = await _context.Photographies.FirstOrDefaultAsync(x => x.Id == id);

            if (Photography == null)
            {


                return NotFound();
            }

            return Ok(Photography);


        }

        // Crear un nuevo registro
        [HttpPost]
        public async Task<ActionResult> Post(Photography Photography)
        {
            _context.Add(Photography);
            await _context.SaveChangesAsync();
            return Ok(Photography);
        }

        // Actualizar o cambiar registro

        [HttpPut]
        public async Task<ActionResult> Put(Photography Photography)
        {
            _context.Update(Photography);
            await _context.SaveChangesAsync();
            return Ok(Photography);
        }

        // ELiminar registros

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {


            var FilaAfectada = await _context.Photographies
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

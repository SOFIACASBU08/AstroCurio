using AstroCurio.Api.Data;
using AstroCurio.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AstroCurio.Api.Controllers
{

    [ApiController]
    [Route("/api/Categories")]
    public class CategoriesController : ControllerBase
    {
        private readonly DataContext _context;

        public CategoriesController(DataContext context)
        {
            _context = context;
        }

        //Get con lista
        //Select * From  Categories

        [HttpGet]
        public async Task<ActionResult> Get()
        {

            return Ok(await _context.Categories.ToListAsync());


        }

        // Get por parámetro
        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {

            //200 Ok

            var Category = await _context.Categories.FirstOrDefaultAsync(x => x.Id == id);

            if (Category == null)
            {


                return NotFound();
            }

            return Ok(Category);


        }

        // Crear un nuevo registro
        [HttpPost]
        public async Task<ActionResult> Post(Category Category)
        {
            _context.Add(Category);
            await _context.SaveChangesAsync();
            return Ok(Category);
        }

        // Actualizar o cambiar registro

        [HttpPut]
        public async Task<ActionResult> Put(Category Category)
        {
            _context.Update(Category);
            await _context.SaveChangesAsync();
            return Ok(Category);
        }

        // ELiminar registros

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {


            var FilaAfectada = await _context.Categories
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

using AstroCurio.Api.Data;
using AstroCurio.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AstroCurio.Api.Controllers
{

    [ApiController]
    [Route("/api/Articles")]
    public class ArticlesController:ControllerBase
    {
        private readonly DataContext _context;

        public ArticlesController(DataContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult> Get()
        {

            return Ok(await _context.Articles.ToListAsync());


        }

        // Get por parámetro
        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {

            //200 Ok

            var Article = await _context.Articles.FirstOrDefaultAsync(x => x.Id == id);

            if (Article == null)
            {


                return NotFound();
            }

            return Ok(Article);


        }

        // Crear un nuevo registro
        [HttpPost]
        public async Task<ActionResult> Post(Article Article)
        {
            try
            {
                // Asignar el usuario y la categoría relacionados
                Article.User = _context.Users.Find(Article.UserId);
                Article.Category = _context.Categories.Find(Article.CategoryId);

                _context.Articles.Add(Article);
                await _context.SaveChangesAsync();
                return Ok(Article);
            }
            catch (Exception ex)
            {
                // Manejar excepciones, por ejemplo, si el usuario o la categoría no se encuentran
                return BadRequest("Error al crear el artículo: " + ex.Message);
            }
        }

        // Actualizar o cambiar registro

        [HttpPut]
        public async Task<ActionResult> Put(Article Article)
        {
            _context.Update(Article);
            await _context.SaveChangesAsync();
            return Ok(Article);
        }

        // ELiminar registros

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {


            var FilaAfectada = await _context.Articles
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

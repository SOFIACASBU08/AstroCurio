﻿using AstroCurio.Api.Data;
using AstroCurio.Shared.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AstroCurio.Api.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

    [ApiController]
    [Route("/api/Articles")]
    public class ArticlesController : ControllerBase
    {
        private readonly DataContext _context;

        public ArticlesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            // Incluye las propiedades de navegación para User y Category
            var articles = await _context.Articles
                .Include(a => a.Person)
                .Include(a => a.Category)
                .ToListAsync();

            return Ok(articles);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {
            var article = await _context.Articles
                .Include(a => a.Person)
                .Include(a => a.Category)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (article == null)
            {
                return NotFound();
            }

            return Ok(article);
        }

        [HttpPost]
        public async Task<ActionResult> Post(Article article)
        {
            try
            {
                // Asignar el usuario y la categoría relacionados utilizando sus IDs
                article.Person = await _context.People.FindAsync(article.Id);
                article.Category = await _context.Categories.FindAsync(article.CategoryId);

                _context.Articles.Add(article);
                 _context.SaveChanges();
                return Ok(article);
            }
            catch (Exception ex)
            {
                return BadRequest("Error al crear el artículo: " + ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> Put(Article article)
        {
            _context.Update(article);
            _context.SaveChanges();
            return Ok(article);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var affectedRows = await _context.Articles
                .Where(x => x.Id == id)
                .ExecuteDeleteAsync();

            if (affectedRows == 0)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}

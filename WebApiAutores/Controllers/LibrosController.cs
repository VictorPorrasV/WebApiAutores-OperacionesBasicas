using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiAutores.Entidades;

namespace WebApiAutores.Controllers
{
    [ApiController]
    [Route("api/libros")]
    public class LibrosControllers:ControllerBase
    {
        private readonly ApplicationDbContext context;        
        
        public LibrosControllers(ApplicationDbContext context){
        
            this.context = context;
        }
        
        
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Libro>>Get(int id)
        {
            return await context.Libros.Include(x=>x.Autor).FirstOrDefaultAsync(x => x.Id == id);

        }

        [HttpPost]
        public async Task<ActionResult>Post(Libro libro)
        {
            var existeAutor = await context.Autores.AnyAsync(x => x.id == libro.AutorId);

            if (!existeAutor)
            {
                return BadRequest($"El autor del id:{libro.AutorId}");
            }

            context.Add(libro);
            await context.SaveChangesAsync();
            return Ok();
        }

    }
}

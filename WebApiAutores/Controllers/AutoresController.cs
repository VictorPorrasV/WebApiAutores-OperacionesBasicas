using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiAutores.Entidades;

namespace WebApiAutores.Controllers
{

    //agrega validaciones del daa
    [ApiController]
    //ruta para los controlladores  
    [Route("api/autores")]
    public class AutoresController:ControllerBase
    {
        public ApplicationDbContext Context { get; }
        public AutoresController(ApplicationDbContext context)
        {
            Context = context;
        }

    

        [HttpGet]
        public async Task<ActionResult<List<Autor>>> Get()
        {
          return await Context.Autores.Include(x => x.Libros).ToListAsync();   
        }
        [HttpPost]
        public async Task<ActionResult> Post(Autor autor)
        {

            Context.Add(autor);
            await Context.SaveChangesAsync();
            return Ok();   
        }


        [HttpPut("{id:int}")]//api/autores/id  
        public async Task<ActionResult>Put(Autor autor,int id)
        {
            if (autor.id != id)
            { 
                return BadRequest("El id del autor no concide con el id de la url");
            }
            var existe = await Context.Autores.AnyAsync(x => x.id == id);
            if (!existe)
            {
                //retornar un 404
                return NotFound();
            }

            Context.Update(autor);
            await Context.SaveChangesAsync();
            return Ok();    

        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await Context.Autores.AnyAsync(x => x.id == id);
            if (!existe)
            {

                return NotFound();
            }

            Context.Remove(new Autor { id = id});
            await Context.SaveChangesAsync();
            return Ok();    
    }   }
}

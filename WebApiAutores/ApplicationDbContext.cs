using Microsoft.EntityFrameworkCore;
using WebApiAutores.Entidades;

namespace WebApiAutores
{
    //using.microsoft.entityfram.....
    public class ApplicationDbContext : DbContext

    {   ///generar un constructor
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        //creaer una tabla apartir del esquema de las propiedades de autores
        public DbSet<Autor> Autores{ get; set; }
    }
}

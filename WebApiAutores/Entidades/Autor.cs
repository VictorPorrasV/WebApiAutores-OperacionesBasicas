namespace WebApiAutores.Entidades
{
    public class Autor
    {
        public int id { get; set; }
        public string Nombre { get; set;}
        public List<Libro> Libros { get; set; }

    }
}

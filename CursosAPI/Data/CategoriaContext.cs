using CursosAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CursosAPI.Data
{
    public class CategoriaContext : DbContext
    {
        public CategoriaContext(DbContextOptions<CategoriaContext> opt) : base(opt)
        {

        }

        public DbSet<Categoria> Categorias { get; set; }
    }
}

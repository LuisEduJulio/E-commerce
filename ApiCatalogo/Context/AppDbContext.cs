using ApiCatalogo.Models;
using APICatalogo.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiCatalogo.Context
{
    public class IUnitOfWork : DbContext
    {
        public IUnitOfWork(DbContextOptions<IUnitOfWork> options) : base(options)
        {

        }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Produto> Produtos { get; set; }
    }
}

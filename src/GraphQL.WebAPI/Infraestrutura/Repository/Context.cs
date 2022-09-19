using GraphQL.WebAPI.Dominio;
using Microsoft.EntityFrameworkCore;

namespace GraphQL.WebAPI.Infraestrutura.Repository
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>().HasData(
                new Cliente
                {
                    Id = 1,
                    Nome = "Marcio"
                },
                new Cliente
                {
                    Id = 2,
                    Nome = "Maria"
                },
                new Cliente
                {
                    Id = 3,
                    Nome = "Bruno"
                },
                new Cliente
                {
                    Id = 4,
                    Nome = "Icaro"
                }
            );
        }
    }
}

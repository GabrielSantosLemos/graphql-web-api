using GraphQL.WebAPI.Dominio;
using Microsoft.EntityFrameworkCore;

namespace GraphQL.WebAPI.Infraestrutura.Repository
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        public DbSet<Author> Authors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>().HasData(
                new Author
                {
                    Id = 1,
                    FirstName = "Joydip",
                    LastName = "Kanjilal"
                },
                new Author
                {
                    Id = 2,
                    FirstName = "Steve",
                    LastName = "Smith"
                },
                new Author
                {
                    Id = 3,
                    FirstName = "Anand",
                    LastName = "Narayanaswamy"
                }
            );

            //modelBuilder.Entity<Cliente>().HasData(
            //    new Cliente
            //    {
            //        Id = 1,
            //        Nome = "Marcio"
            //    },
            //    new Cliente
            //    {
            //        Id = 1,
            //        Nome = "Maria"
            //    },
            //    new Cliente
            //    {
            //        Id = 1,
            //        Nome = "Bruno"
            //    },
            //    new Cliente
            //    {
            //        Id = 1,
            //        Nome = "Icaro"
            //    }
            //);
        }
    }
}

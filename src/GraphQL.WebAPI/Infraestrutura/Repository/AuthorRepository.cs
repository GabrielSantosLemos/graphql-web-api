using GraphQL.WebAPI.Dominio;
using Microsoft.EntityFrameworkCore;

namespace GraphQL.WebAPI.Infraestrutura.Repository
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly IDbContextFactory <Context> _dbContextFactory;

        public AuthorRepository(IDbContextFactory <Context> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;

            using (var _applicationDbContext = _dbContextFactory.CreateDbContext())
            {
                _applicationDbContext.Database
                .EnsureCreated();
            }
        }

        public List<Author> GetAuthors()
        {
            using (var applicationDbContext = _dbContextFactory.CreateDbContext())
            {
                return applicationDbContext.Authors.ToList();
            }
        }

        public Author GetAuthorById(int id)
        {
            using (var applicationDbContext = _dbContextFactory.CreateDbContext())
            {
                return applicationDbContext.Authors.SingleOrDefault(x => x.Id == id);
            }
        }

        public async Task<Author> CreateAuthor(Author author)
        {
            using (var applicationDbContext = _dbContextFactory.CreateDbContext())
            {
                await applicationDbContext.Authors.AddAsync(author);
                await applicationDbContext.SaveChangesAsync();
                return author;
            }
        }
    }
}

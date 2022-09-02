using GraphQL.WebAPI.Dominio;

namespace GraphQL.WebAPI.Infraestrutura.Repository
{
    public interface IAuthorRepository
    {
        public List<Author> GetAuthors();
        public Author GetAuthorById(int id);
        public Task<Author> CreateAuthor(Author author);
    }
}

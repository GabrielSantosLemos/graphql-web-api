using GraphQL.WebAPI.Dominio;
using GraphQL.WebAPI.Infraestrutura.Repository;
using HotChocolate.Resolvers;

namespace GraphQL.WebAPI.Infraestrutura.GraphQL
{
    public class AuthorResolver
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorResolver([Service] IAuthorRepository
        authorService)
        {
            _authorRepository = authorService;
        }

        public Author GetAuthor(int authorId, IResolverContext ctx)
        {
            return _authorRepository.GetAuthors().Where(a => a.Id == authorId).FirstOrDefault();
        }
    }
}

using GraphQL.WebAPI.Dominio;
using GraphQL.WebAPI.Infraestrutura.Repository;
using HotChocolate.Subscriptions;

namespace GraphQL.WebAPI.Infraestrutura.GraphQL
{
    public class AuthorQuery
    {
        public async Task<List<Author>> GetAllAuthors(
            [Service] IAuthorRepository authorRepository,
            [Service] ITopicEventSender eventSender)
        {
            List<Author> authors = authorRepository.GetAuthors();
            await eventSender.SendAsync("ReturnedAuthors", authors);

            return authors;
        }
        public async Task<Author> GetAuthorById(
            [Service] IAuthorRepository authorRepository,
            [Service] ITopicEventSender eventSender, 
            int id)
        {
            Author author = authorRepository.GetAuthorById(id);
            await eventSender.SendAsync("ReturnedAuthor", author);
            return author;
        }
    }
}

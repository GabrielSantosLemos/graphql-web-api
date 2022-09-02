using GraphQL.WebAPI.Dominio;
using GraphQL.WebAPI.Infraestrutura.Repository;
using HotChocolate.Subscriptions;

namespace GraphQL.WebAPI.Infraestrutura.GraphQL
{
    public class AuthorMutation
    {
        public async Task<Author> CreateAuthor(
            [Service] AuthorRepository authorRepository,
            [Service] ITopicEventSender eventSender, int id, string firstName, string lastName)
        {
            var data = new Author
            {
                Id = id,
                FirstName = firstName,
                LastName = lastName
            };

            var result = await authorRepository.CreateAuthor(data);
            await eventSender.SendAsync("AuthorCreated", result);

            return result;
        }
    }
}

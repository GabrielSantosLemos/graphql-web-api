using GraphQL.WebAPI.Dominio;
using HotChocolate.Execution;
using HotChocolate.Subscriptions;

namespace GraphQL.WebAPI.Infraestrutura.GraphQL
{
    public class AuthorSubscription
    {
        [SubscribeAndResolve]
        public async ValueTask<ISourceStream<Author>> OnAuthorCreated(
            [Service] ITopicEventReceiver eventReceiver,
            CancellationToken cancellationToken)
        {
            return await eventReceiver.SubscribeAsync<string, Author>("AuthorCreated", cancellationToken);
        }

        [SubscribeAndResolve] 
        public async ValueTask<ISourceStream <List<Author>>> OnAuthorsGet(
            [Service] ITopicEventReceiver eventReceiver,
            CancellationToken cancellationToken)
        {
            return await eventReceiver.SubscribeAsync<string, List<Author>>("ReturnedAuthors", cancellationToken);
        }

        [SubscribeAndResolve]
        public async ValueTask<ISourceStream<Author>> OnAuthorGet(
            [Service] ITopicEventReceiver eventReceiver, 
            CancellationToken cancellationToken)
        {
            return await eventReceiver.SubscribeAsync<string, Author>("ReturnedAuthor", cancellationToken);
        }
    }
}

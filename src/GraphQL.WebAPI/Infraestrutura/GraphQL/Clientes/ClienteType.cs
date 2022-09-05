using GraphQL.WebAPI.Dominio;
using HotChocolate.Resolvers;

namespace GraphQL.WebAPI.Infraestrutura.GraphQL.Clientes
{
    public class ClienteType : ObjectType<Cliente>
    {
        protected override void Configure(IObjectTypeDescriptor<Cliente> descriptor)
        {
            descriptor.Field(x => x.Id).Type<IdType>();
            descriptor.Field(x => x.Nome).ResolveWith<Resolvers>(x => x.GetNome(default));
        }

        private class Resolvers
        {
            public string GetNome(IResolverContext ctx)
            {
                return "";
            }
        }
    }
}

using HotChocolate.Data;
using HotChocolate.Resolvers;

namespace GraphQL.WebAPI.Infraestrutura.GraphQL.Clientes
{
    public class ClienteQuery
    {
        private readonly List<ClienteViewModel> _clientes = new () 
        {
            new ClienteViewModel
            {
                Id = 1,
                Nome = "Marcio Silva"
            },
            new ClienteViewModel
            {
                Id = 2,
                Nome = "Bruna Rosa"
            },
            new ClienteViewModel
            {
                Id = 2,
                Nome = "Lucas Silva"
            },
        };

        public List<ClienteViewModel> BuscarTodosClientes(IResolverContext context)
        {
            return _clientes;
        }

        public ClienteViewModel? BuscarClientePorId(IResolverContext context, int id)
        {
            //Per the Annotation based Resolver signature here HC will inject the 'id' argument for us!
            //Otherwise this is just normal Resolver stuff...
            var productId = id;

            //Also you could get the argument from the IResolverContext...
            //var productId = context.Argument<int>("id");. . . 


            return _clientes.Where(x => x.Id == id).FirstOrDefault();
        }

        [UsePaging]
        public IEnumerable<ClienteViewModel> BuscarClientesPaging(IResolverContext context)
        {
            return _clientes;
        }

        [UseOffsetPaging]
        public IEnumerable<ClienteViewModel> BuscarClientesOffset(IResolverContext context)
        {
            return _clientes;
        }

    }
}

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
            return _clientes.Where(x => x.Id == id).FirstOrDefault();
        }

        [UsePaging]
        public IEnumerable<ClienteViewModel> Paging(IResolverContext context)
        {
            return _clientes;
        }

        [UseOffsetPaging]
        public IEnumerable<ClienteViewModel> Offset(IResolverContext context)
        {
            return _clientes;
        }
    }
}

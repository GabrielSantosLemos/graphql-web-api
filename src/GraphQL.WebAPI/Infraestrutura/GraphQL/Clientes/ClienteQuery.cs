using GraphQL.WebAPI.Dominio;

namespace GraphQL.WebAPI.Infraestrutura.GraphQL.Clientes
{
    public class ClienteQuery
    {
        private readonly List<Cliente> _clientes = new () 
        {
            new Cliente
            {
                Id = 1,
                Nome = "Marcio Silva"
            },
            new Cliente
            {
                Id = 2,
                Nome = "Bruna Rosa"
            },
            new Cliente
            {
                Id = 2,
                Nome = "Lucas Silva"
            },
        };

        public List<Cliente> BuscarTodosClientes()
        {
            return _clientes;
        }

        public Cliente? BuscarClientePorId(int id)
        {
            return _clientes.Where(x => x.Id == id).FirstOrDefault();
        }
    }
}

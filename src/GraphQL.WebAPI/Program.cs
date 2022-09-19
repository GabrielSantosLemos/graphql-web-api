using GraphQL.WebAPI.Infraestrutura.GraphQL.Clientes;
using GraphQL.WebAPI.Infraestrutura.Repository;
using Microsoft.EntityFrameworkCore;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContextFactory<Context>(options => options.UseInMemoryDatabase("Database"));
builder.Services.AddInMemorySubscriptions();

builder.Services.AddGraphQLServer()
                .AddQueryType<ClienteQuery>();

WebApplication? app = builder.Build();

app.MapGraphQL();

app.Run();

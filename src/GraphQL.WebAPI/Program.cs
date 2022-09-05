using GraphQL.WebAPI.Infraestrutura.GraphQL.Clientes;
using GraphQL.WebAPI.Infraestrutura.Repository;
using Microsoft.EntityFrameworkCore;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContextFactory<Context>(options => options.UseInMemoryDatabase("Database"));
builder.Services.AddInMemorySubscriptions();

builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();

builder.Services.AddGraphQLServer()
                .AddType<ClienteType>()
                .AddQueryType<ClienteQuery>();

WebApplication? app = builder.Build();

app.MapGraphQL();

app.Run();

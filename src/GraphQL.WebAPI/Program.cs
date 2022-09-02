using GraphQL.WebAPI.Infraestrutura.GraphQL;
using GraphQL.WebAPI.Infraestrutura.Repository;
using HotChocolate.AspNetCore;
using HotChocolate.AspNetCore.Playground;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContextFactory<Context>(options => options.UseInMemoryDatabase("Database"));
builder.Services.AddInMemorySubscriptions();

builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();

builder.Services.AddGraphQLServer()
                .AddType<AuthorType>()
                .AddQueryType<AuthorQuery>()
                .AddMutationType<AuthorMutation>()
                .AddSubscriptionType<AuthorSubscription>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UsePlayground(new PlaygroundOptions
    {
        QueryPath = "/graphql",
        Path = "/playground"
    });
}

app.UseWebSockets();

app.UseRouting()
   .UseEndpoints(endpoints =>
   {
       endpoints.MapGraphQL();
   });

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

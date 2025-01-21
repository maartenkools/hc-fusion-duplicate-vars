using HotChocolate.AspNetCore;
using Server.GraphQL;

var builder = WebApplication.CreateBuilder(args);

builder
    .Services
    .AddGraphQLServer()
    .AddQueryType<Query>();

var app = builder.Build();

app
    .MapGraphQL()
    .WithOptions(new GraphQLServerOptions
    {
        Tool = { Enable = false }
    });

app.Run();

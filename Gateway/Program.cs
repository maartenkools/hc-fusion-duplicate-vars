using HotChocolate.Fusion.Composition;
using HotChocolate.Skimmed.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder
    .Services
    .AddHttpClient();

var serverAddress = new Uri("http://localhost:5045/graphql");

var composer = new FusionGraphComposer();
var sd = await composer.ComposeAsync([
    new SubgraphConfiguration(
        "Subgraph",
        await File.ReadAllTextAsync("subgraph.graphql"),
        "",
        new HttpClientConfiguration(serverAddress),
        null
    )
]);

var doc = SchemaFormatter.FormatAsDocument(sd);

builder
    .Services
    .AddFusionGatewayServer()
    .ConfigureFromDocument(doc);

var app = builder.Build();

app.MapGraphQL();

app.Run();

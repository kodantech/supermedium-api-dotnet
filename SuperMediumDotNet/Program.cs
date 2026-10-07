using SuperMediumDotNet.Data;
using SuperMediumDotNet.Endpoints;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddValidation();

builder.Services.AddOpenApi();

builder.InitializeDb();

var app = builder.Build();

app.MigrateDb();

app.MapPostsEndpoints();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.Run();
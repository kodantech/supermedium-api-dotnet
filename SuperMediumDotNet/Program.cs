using SuperMediumDotNet.Endpoints;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddValidation();

builder.Services.AddOpenApi();

var app = builder.Build();

app.MapPostsEndpoints();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.Run();
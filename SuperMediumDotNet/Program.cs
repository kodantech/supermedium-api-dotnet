using SuperMediumDotNet.Data;
using SuperMediumDotNet.Endpoints;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddValidation();

builder.Services.AddOpenApi();

const string connString = "Data Source=SuperMediumDotNet.db";
builder.Services.AddSqlite<PostContext>(connString);

var app = builder.Build();

app.MapPostsEndpoints();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.Run();
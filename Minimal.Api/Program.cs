using Carter;

var builder = WebApplication.CreateBuilder(args);

//Use IHttpClientFactory directly
builder.Services.AddHttpClient();

builder.Services.AddCarter();

var app = builder.Build();


app.MapGet("/minimal", () => "Hello World! Minimal Api");

app.MapCarter();

app.Run();

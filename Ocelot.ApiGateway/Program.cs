using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Security.Claims;
using Ocelot.Cache.CacheManager;

var builder = WebApplication.CreateBuilder(args);

// Add ocelot configuration
builder.Configuration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);

builder.Services.AddOcelot(builder.Configuration)
    .AddCacheManager(x => x.WithDictionaryHandle());

builder.Services.AddAuthorization();
builder.Services.AddAuthentication().AddJwtBearer();
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
// builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
//     app.UseSwagger();
//     app.UseSwaggerUI();
// }

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// Add ocelot middleware
await app.UseOcelot();

// // Minimal public api
// app.MapGet("/", () => "Hello, World!");

// // Protected endpoint ~/secret with JWT and scope=demo:secrets required policy
// app.MapGet("/secret",
//     () => "This is a secure content!")
//     .RequireAuthorization(
//         policy => policy.RequireClaim("scope", "demo:secrets"));

// // app.MapGet("/secret", (ClaimsPrincipal user) => $"Hello {user.Identity?.Name}. My secret")
// //     .RequireAuthorization();

app.Run();

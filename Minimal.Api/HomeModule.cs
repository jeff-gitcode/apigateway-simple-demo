using Carter;
using System.Text.Json;
using System.Text.Json.Nodes;

public class HomeModule : ICarterModule
{
    // private readonly IHttpClientFactory _httpClientFactory;
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/minimal/posts", GetPosts);
        app.MapGet("/minimal/users", GetUsers);
    }

    public async Task<IResult> GetPosts(IHttpClientFactory httpClientFactory)
    {
        var client = httpClientFactory.CreateClient("postsClient");

        var response = await client.GetAsync("https://jsonplaceholder.typicode.com/posts");

        var content = await response.Content.ReadAsStringAsync();

        var jsonObjectList = JsonSerializer.Deserialize<IList<JsonObject>>(content);
        // var jsonObject = JsonNode.Parse(content).AsObject();
        // var jsonObject = JObject.Parse(content);

        return Results.Ok(jsonObjectList);
    }

    public async Task<IResult> GetUsers(IHttpClientFactory httpClientFactory)
    {
        var client = httpClientFactory.CreateClient("usersClient");

        var response = await client.GetAsync("https://jsonplaceholder.typicode.com/users");

        var content = await response.Content.ReadAsStringAsync();

        var jsonObjectList = JsonSerializer.Deserialize<IList<JsonObject>>(content);
        // var jsonObject = JsonNode.Parse(content).AsObject();
        // var jsonObject = JObject.Parse(content);

        return Results.Ok(jsonObjectList);
    }
}
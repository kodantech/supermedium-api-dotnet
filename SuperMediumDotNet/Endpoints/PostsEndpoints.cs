using SuperMediumDotNet.Dtos;

namespace SuperMediumDotNet.Endpoints;

public static class PostsEndpoints
{
    private const string EndpointName = "GetPost";


    public static void MapPostsEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("posts");

        group.MapGet("/", (_, ) =>
        {
            
        });

        group.MapGet(("/{id:int}"), (int id) =>
        {
            var post = Posts.Find(post => post.Id == id);

            return post is null ? Results.NotFound() : Results.Ok(post);
        }).WithName(EndpointName);

        group.MapPost("/", (CreatePostDto post) =>
        {
            PostDto newPost = new(
                Posts.Count + 1,
                post.Title,
                post.Description,
                DateOnly.FromDateTime(DateTime.Today)
            );

            Posts.Add(newPost);

            return Results.CreatedAtRoute(EndpointName, new { id = newPost.Id });
        });

        group.MapPut("/{id:int}", (int id, UpdatePostDto updatedPost) =>
        {
            var index = Posts.FindIndex(post => post.Id == id);

            if (index == -1)
            {
                return Results.NotFound();
            }

            Posts[index] = new PostDto(
                id,
                updatedPost.Title,
                updatedPost.Description,
                DateOnly.FromDateTime(DateTime.Today)
            );

            return Results.NoContent();
        });

        group.MapDelete("/{id:int}", (int id) =>
        {
            var index = Posts.FindIndex(post => post.Id == id);

            if (index == -1)
            {
                return Results.NotFound();
            }

            Posts.RemoveAt(index);

            return Results.NoContent();
        });
    }
}
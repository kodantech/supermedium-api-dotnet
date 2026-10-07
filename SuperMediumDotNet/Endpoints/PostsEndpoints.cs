using SuperMediumDotNet.Data;
using SuperMediumDotNet.Dtos;
using SuperMediumDotNet.Models;

namespace SuperMediumDotNet.Endpoints;

public static class PostsEndpoints
{
    private const string EndpointName = "GetPost";


    public static void MapPostsEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("posts");

        group.MapGet("/", () => Results.Ok());

        // group.MapGet(("/{id:int}"), (int id) =>
        // {
        //     var post = Posts.Find(post => post.Id == id);
        //
        //     return post is null ? Results.NotFound() : Results.Ok(post);
        // }).WithName(EndpointName);

        group.MapPost("/", (CreatedPostDto post, SuperMediumContext dbContext) =>
        {
            Post newPost = new()
            {
                Id = post.Id,
                Title = post.Title,
                Description = post.Description,
                PublishDate = DateOnly.FromDateTime(DateTime.Today),
                TagId = post.TagId
            };


            dbContext.Posts.Add(newPost);
            dbContext.SaveChanges();

            CreatedPostDto postDto = new(
                newPost.Id,
                newPost.Title,
                newPost.Description,
                newPost.PublishDate,
                newPost.TagId
            );

            // return Results.CreatedAtRoute(EndpointName, new { id = postDto.Id }, postDto);
            return Results.Ok();
        });

        // group.MapPut("/{id:int}", (int id, UpdatePostDto updatedPost) =>
        // {
        //     var index = Posts.FindIndex(post => post.Id == id);
        //
        //     if (index == -1)
        //     {
        //         return Results.NotFound();
        //     }
        //
        //     Posts[index] = new PostDto(
        //         id,
        //         updatedPost.Title,
        //         updatedPost.Description,
        //         DateOnly.FromDateTime(DateTime.Today)
        //     );
        //
        //     return Results.NoContent();
        // });
        //
        // group.MapDelete("/{id:int}", (int id) =>
        // {
        //     var index = Posts.FindIndex(post => post.Id == id);
        //
        //     if (index == -1)
        //     {
        //         return Results.NotFound();
        //     }
        //
        //     Posts.RemoveAt(index);
        //
        //     return Results.NoContent();
        // });
    }
}
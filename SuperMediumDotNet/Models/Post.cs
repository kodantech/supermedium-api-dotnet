namespace SuperMediumDotNet.Models;

public class Post
{
    public int Id { get; set; }

    public required string Title { get; set; }

    public string? Description { get; set; }

    public required DateOnly PublishDate { get; set; }

    public Tag? Tag { get; set; }

    public int TagId { get; set; }
}
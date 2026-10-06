using System.ComponentModel.DataAnnotations;

namespace SuperMediumDotNet.Dtos;

public record CreatePostDto(
    int Id,
    [Required] [MinLength(50)] string Title,
    string Description,
    DateOnly PublishDate
);
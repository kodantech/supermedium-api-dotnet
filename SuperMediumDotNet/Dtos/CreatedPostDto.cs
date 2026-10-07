using System.ComponentModel.DataAnnotations;

namespace SuperMediumDotNet.Dtos;

public record CreatedPostDto(
    int Id,
    [Required] string Title,
    string? Description,
    DateOnly PublishDate,
    int TagId
);
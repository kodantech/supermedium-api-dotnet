namespace SuperMediumDotNet.Dtos;

public record UpdatePostDto(
    string Title,
    string Description,
    DateOnly PublishDate
);
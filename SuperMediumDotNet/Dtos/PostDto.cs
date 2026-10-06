namespace SuperMediumDotNet.Dtos;

public record PostDto(
    int Id,
    string Title,
    string Description,
    DateOnly PublishDate
);
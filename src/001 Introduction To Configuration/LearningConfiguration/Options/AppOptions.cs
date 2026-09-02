namespace LearningConfiguration.Options;

public class AppOptions
{
    public string? Name { get; set; }
    public string? Version { get; set; }
    public string? Description { get; set; }
    public DateTime? ReleaseDate { get; set; }
    public List<Author>? Authors { get; set; }
    public bool IsProduction { get; set; }
}

public class Author
{
    public string? Name { get; set; }
    public string? Email { get; set; }
}

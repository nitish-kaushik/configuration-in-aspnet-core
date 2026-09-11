using System.ComponentModel.DataAnnotations;

namespace LearningConfiguration.Options;

public class AppOptions
{
    public static string SectionName = "App";

    //[Required]
    public string? Name { get; set; }
    public string? Version { get; set; }

    [MinLength(20)]
    public string? Description { get; set; }
    public DateTime? ReleaseDate { get; set; }
    public List<Author>? Authors { get; set; }
    public bool IsProduction { get; set; }
}

public class Author
{
    public string? Name { get; set; }
    [EmailAddress]
    public string? Email { get; set; }
}

namespace LearningConfiguration;

public static class ApplicationConfigurationExtensions
{
    public static WebApplicationBuilder AddEnterpriseConfiguration(this WebApplicationBuilder builder, string[] args)
    {
        ArgumentNullException.ThrowIfNull(builder);

        builder.Configuration.AddCommandLine(args, GetCommandLineSwitchMappings());
        builder.Configuration.AddInMemoryCollection(GetInMemoryConfiguration());

        return builder;
    }

    private static Dictionary<string, string> GetCommandLineSwitchMappings() => new()
    {
        ["-db"] = "ConnectionStrings:Default",
        ["-rd"] = "ConnectionStrings:Redis",
        ["--t"] = "Title"
    };

    private static Dictionary<string, string?> GetInMemoryConfiguration() => new()
    {
        ["Title"] = "My In memory Application",
        ["App:Name"] = "App name In memory",
        ["ConnectionStrings:Default"] = "InMem,Server=localhost;Database=mydb;User Id=myuser;Password=mypassword;",
        ["ConnectionStrings:Redis"] = "localhost:inmem"
    };
}

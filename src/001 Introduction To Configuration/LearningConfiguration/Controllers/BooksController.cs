using Microsoft.AspNetCore.Mvc;

namespace LearningConfiguration.Controllers;

[ApiController]
[Route("[controller]")]
public class BooksController(IConfiguration configuration) : ControllerBase
{
    // GET
    [HttpGet("GetAppName")]
    public IActionResult GetAppName()
    {
        /*var appName = configuration["Title"];
        var name = configuration["App:Name"];
        var version = configuration["App:Version"];
        var defaultConnectionString = configuration.GetConnectionString("Default");
        var redisConString = configuration.GetConnectionString("Redis");

        var isEnabledSwagger = configuration.GetValue<bool>("Features:EnableSwagger");
        var isEnabledCaching = configuration.GetValue<bool>("Features:EnableCaching");

        var firstElement = configuration["AllowedHosts:0"];
        var secondElement = configuration["AllowedHosts:1"];
        var thirdElement = configuration["AllowedHosts:2"];

        var port1 = configuration.GetValue<int>("Servers:0:Port", 8080);*/

        // var appSection = configuration.GetSection("App");
        //
        // if (appSection.Exists())
        // {
        //     var result =appSection.GetChildren().Where(x=>x.Value != null).Select(x=> x.Value).ToList();
        // }

        var appObj = new App();

        configuration.GetSection("App").Bind(appObj);

        return Ok();
    }
}

class App
{
    public string? Name { get; set; }
    public string? Version { get; set; }
}

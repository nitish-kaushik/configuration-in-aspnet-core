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
        var appName = configuration["AppName"];
        return Ok(appName);
    }
}

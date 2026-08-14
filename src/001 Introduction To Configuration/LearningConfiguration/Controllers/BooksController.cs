using Microsoft.AspNetCore.Mvc;

namespace LearningConfiguration.Controllers;

[ApiController]
[Route("[controller]")]
public class BooksController : ControllerBase
{
    // GET
    [HttpGet("GetAppName")]
    public IActionResult GetAppName()
    {
        return Ok("LearningConfiguration");
    }
}

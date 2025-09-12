using Microsoft.AspNetCore.Mvc;

namespace TaskManagement.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TaskController : Controller
{
    // GET
    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok();
    }
    
    
    // Create
    [HttpPost]
    public IActionResult Create()
    {
        return Ok();
    }
    
}
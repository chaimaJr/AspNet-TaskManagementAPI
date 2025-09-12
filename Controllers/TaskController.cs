using Microsoft.AspNetCore.Mvc;
using TaskManagement.Services;
using Task = TaskManagement.Models.Task;

namespace TaskManagement.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TaskController : ControllerBase
{
    private readonly ITaskService _taskService;

    public TaskController(ITaskService taskService)
    {
        _taskService = taskService;
    }
    
    // GET ALL
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Models.Task>>> GetAllTasks()
    {
        var tasks = await _taskService.GetAllTasks();

        return Ok(tasks);
    }
    
    // GET ONE
    [HttpGet("{id}")]
    public async Task<ActionResult<Models.Task>> GetTask(int id)
    {
        var task = await _taskService.GetTaskById(id);
        return Ok(task);
    }
    
    // CREATE
    [HttpPost]
    public async Task<ActionResult<Models.Task>> CreateTask(string title, string description)
    {

        var task = new Task
        {
            Title = title,
            Description = description
        };
        
        var t = await _taskService.CreateTask(task);
        
        return CreatedAtAction(
            nameof(GetTask), 
            new { id = t.Id },
            t
        );
    }
    
        
    
    // UPDATE
    
    
    
    // DELETE
    
    
    
    // CHANGE STATUS
    
    
    
}
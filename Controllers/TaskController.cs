using Microsoft.AspNetCore.Mvc;
using TaskManagement.Services;
using Task = TaskManagement.Models.Task;

namespace TaskManagement.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TaskController(ITaskService _taskService) : ControllerBase
{
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
        if (task == null)
            return NotFound($"Task with id {id} not found");

        return Ok(task);
    }
    
    
    // UPDATE
    [HttpPut("{id}")]
    public async Task<ActionResult<Models.Task>> UpdateTask(int id, string? title, string? description)
    {
        var task = new Task
        {
            Title = title,
            Description = description
        };
        var updatedTask = await _taskService.UpdateTask(id, task);
        return Ok(updatedTask);
    }
    
    
    // DELETE
    [HttpDelete("{id}")]
    public async Task<ActionResult<bool>> DeleteTask(int id)
    {
        var success = await _taskService.DeleteTask(id);
        if (!success)
            return NotFound($"Task with id {id} not found");
    
        return NoContent();
    }     
    
    // CHANGE STATUS
    [HttpPatch("{id}")]
    public async Task<ActionResult<Task>> UpdateStatus(int id)
    {
        var task = await _taskService.UpdateStatus(id);
        if (task == null)
            return NotFound($"Task with id {id} not found");

        return Ok(task);
    }
    
    
}
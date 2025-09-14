using Microsoft.AspNetCore.Mvc;
using TaskManagement.Models;
using TaskManagement.Services;

namespace TaskManagement.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProjectController(IProjectService _projectService): ControllerBase
{
    // GET ALL
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Project>>> GetAllTasks()
    {
        var projects = await _projectService.GetAllProjects();
        return Ok(projects);
    } 
    
    // GET ONE
    [HttpGet("{id}")]
    public async Task<ActionResult<Project>> GetProject(int id)
    {
        var project = await _projectService.GetProjectById(id);
        return Ok(project);
    }
    
    // CREATE
    [HttpPost]
    public async Task<ActionResult<Project>> CreateProject(string name)
    {
        var p = new Project()
        {
            Name = name
        };
        var project = await _projectService.CreateProject(p);
        return CreatedAtAction(nameof(GetProject), new { id = project.Id }, project);
    }
    
    
    // UPDATE
    [HttpPatch("{id}")]
    public async Task<ActionResult<Project>> UpdateProjectName(int id, string name)
    {
        var project = await _projectService.UpdateProjectName(id, name);
        if (project == null)
            return NotFound($"Project with id {id} not found");
        
        return Ok(project);
    }
    
    
    // DELETE
    [HttpDelete("{id}")]
    public async Task<ActionResult<bool>> DeleteProject(int id)
    {
        return await _projectService.DeleteProject(id);
    }
    
    
    
    // ADD TASK (new)
    [HttpPost("{id}/tasks")]
    public async Task<ActionResult<Project>> AddTask(int id, string title, string description)
    {
        var task = new Models.Task
        {
            Title = title,
            Description = description,
        };
        var project = await _projectService.AddTask(id, task);
        if (project == null)
            return NotFound($"Project with id {id} not found");

        return Ok(project);
    }

    [HttpDelete("{id}/tasks/{taskId}")]
    public async Task<ActionResult<Project>> RemoveTask(int id, int taskId)
    {
        var project = await _projectService.RemoveTask(id, taskId);
        if (project == null)
            return NotFound($"Project with id {id} not found");

        return Ok(project);
    }
    
}
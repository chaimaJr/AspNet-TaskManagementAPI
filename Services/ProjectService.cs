using TaskManagement.Models;
using TaskManagement.Repositories;
using Task = TaskManagement.Models.Task;

namespace TaskManagement.Services;

public class ProjectService(IProjectRepository _projectRepo): IProjectService
{
    public async Task<IEnumerable<Project>> GetAllProjects()
    {
        return await _projectRepo.GetAllProjects();
    }

    public async Task<Project?> GetProjectById(int id)
    {
        return await _projectRepo.GetProject(id);
    }

    public async Task<Project> CreateProject(Project project)
    {
        project.CreatedAt = DateTime.UtcNow;
        
        return await _projectRepo.CreateProject(project);;
    }

    public async Task<Project?> UpdateProjectName(int id, string name)
    {
        var existingProject = await _projectRepo.GetProject(id);

        if (existingProject == null)
            return null;

        existingProject.Name = name;
        return await _projectRepo.UpdateProject(existingProject);
    }

    public async Task<bool> DeleteProject(int id)
    {
        return await _projectRepo.DeleteProject(id);
    }
    
    // Extra
    public async Task<Project?> AddTask(int id, Task task)
    {
        var project = await _projectRepo.GetProject(id);

        if (project == null)
            return null;
        
        task.CreatedAt = DateTime.UtcNow;
        task.IsCompleted = false;
        task.ProjectId = id;
        
        project.Tasks.Add(task);
        return await _projectRepo.UpdateProject(project);
    }

    public async Task<Project?> RemoveTask(int id, int taskId)
    {
        var project = await _projectRepo.GetProject(id);
        if (project == null)
            return null;
        
        var task = project.Tasks.FirstOrDefault(t => t.Id == taskId);
        if (task == null)
            return null;

        project.Tasks.Remove(task);
        return await _projectRepo.UpdateProject(project);
    }
}
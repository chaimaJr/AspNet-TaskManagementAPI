
using TaskManagement.Models;
using Task = TaskManagement.Models.Task;

namespace TaskManagement.Services;

public interface IProjectService
{
    Task<IEnumerable<Project>> GetAllProjects();
    Task<Project?> GetProjectById(int id);
    Task<Project> CreateProject(Project project);
    Task<Project?> UpdateProjectName(int id, string name);
    Task<bool> DeleteProject(int id);
    
    // Extra

    Task<Project?> AddTask(int id, Task task);
    Task<Project?> RemoveTask(int id, int taskId);

}
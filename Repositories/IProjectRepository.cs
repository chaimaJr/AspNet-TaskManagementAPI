using TaskManagement.Data;
using TaskManagement.Models;
using Task = TaskManagement.Models.Task;

namespace TaskManagement.Repositories;

public interface IProjectRepository
{
   Task<IEnumerable<Project>> GetAllProjects();
   Task<Project?> GetProject(int id);
   Task<Project> CreateProject(Project project);
   Task<Project?> UpdateProject(Project project);
   Task<bool> DeleteProject(int id);
   
   // Task<Project> AddTask(Models.Task task);
   // Task<Project> RemoveTask(int id); 
   
}
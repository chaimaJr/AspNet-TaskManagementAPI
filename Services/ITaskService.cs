
namespace TaskManagement.Services;

public interface ITaskService
{
    // Basic
    Task<IEnumerable<Models.Task>> GetAllTasks();
    Task<Models.Task?> GetTaskById(int id);
    Task<Models.Task> CreateTask(Models.Task task);
    Task<Models.Task?> UpdateTask(int id, Models.Task task);
    Task<bool> DeleteTask(int id);
    
    // Extra 
    public Task<Models.Task?> UpdateStatus(int id);

}
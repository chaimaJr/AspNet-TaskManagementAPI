
namespace TaskManagement.Services;

public interface ITaskService
{
    // Basic
    public Task<List<Models.Task>> GetAllTasks();    // Task<T>: For Async/Await: Threading Task, Promise to return T (type)
    public Task<Models.Task?> GetTask(int id);
    public Task<Models.Task> CreateTask(Models.Task task);
    public Task<Models.Task?> UpdateTask(Models.Task task);
    public bool DeleteTask(int id);
    
    // Extra 
    public Task<Models.Task?> UpdateStatus(Models.Task task);

}
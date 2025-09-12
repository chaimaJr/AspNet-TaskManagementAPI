namespace TaskManagement.Repositories;

public interface ITaskRepository
{
    // Basic
    Task<IEnumerable<Models.Task>> GetAllTasks();    // Task<T>: For Async/Await: Threading Task, Promise to return T (type)
    Task<Models.Task?> GetTask(int id);
    Task<Models.Task> CreateTask(Models.Task task);
    Task<Models.Task?> UpdateTask(Models.Task task);
    Task<bool> DeleteTask(int id);
    
    // Extra 
    Task<Models.Task?> UpdateStatus(Models.Task task);
}
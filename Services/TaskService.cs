using Microsoft.EntityFrameworkCore;
using TaskManagement.Data;
using TaskManagement.Repositories;
using Task = TaskManagement.Models.Task;

namespace TaskManagement.Services;

public class TaskService: ITaskService
{
    private readonly ITaskRepository _taskRepo;
    
    public async Task<IEnumerable<Task>> GetAllTasks()
    {
        return await _taskRepo.GetAllTasks();
    }

    public async Task<Task?> GetTaskById(int id)
    {
        return await _taskRepo.GetTask(id);
    }

    public async Task<Task> CreateTask(Task task)
    {
        task.CreatedAt = DateTime.UtcNow;
        task.IsCompleted = false;
        
        return await _taskRepo.CreateTask(task);
    }

    
    // [To Test] check if the existing values are changing (createdAt, ...)
    public async Task<Task?> UpdateTask(int id, Task task)
    {
        var existingTask = await _taskRepo.GetTask(id);

        if (existingTask == null)
            return null;
        
        existingTask.Title = task.Title;
        existingTask.Description = task.Description;
        
        return await _taskRepo.UpdateTask(existingTask);
    }

    public async Task<bool> DeleteTask(int id)
    {
        return await _taskRepo.DeleteTask(id);
    }

    // [To Test] check if the existing values are changing (createdAt, ...)
    public async Task<Task?> UpdateStatus(int id)
    {
        var task = await _taskRepo.GetTask(id);
        if (task == null)
            return null;

        return await _taskRepo.UpdateStatus(task);
    }
}
using Microsoft.EntityFrameworkCore;
using TaskManagement.Data;
using Task = TaskManagement.Models.Task;

namespace TaskManagement.Repositories;

public class TaskRepository: ITaskRepository
{
    private readonly ApplicationDbContext _context;

    public TaskRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    
    
    public async Task<IEnumerable<Task>> GetAllTasks()
    {
        return await _context.Tasks
            .OrderBy(t => t.CreatedAt)
            .ToListAsync();
    }

    public async Task<Task?> GetTask(int id)
    {
        return await _context.Tasks
            .FindAsync(id);
    }

    public async Task<Task> CreateTask(Task task)
    {
        _context.Tasks.Add(task);
        await _context.SaveChangesAsync();

        return task;
    }

    public async Task<Task> UpdateTask(Task task)
    {
        _context.Tasks.Update(task);
        await _context.SaveChangesAsync();

        return task;
    }

    public async Task<bool> DeleteTask(int id)
    {
        var task = await _context.Tasks.FindAsync(id);

        if (task == null)
            return false;

        _context.Tasks.Remove(task);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<Task?> UpdateStatus(Task task)
    {
        task.IsCompleted = !task.IsCompleted;
        _context.Tasks.Update(task);
        await _context.SaveChangesAsync();

        return task;
    }
}
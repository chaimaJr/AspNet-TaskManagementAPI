using Microsoft.EntityFrameworkCore;
using TaskManagement.Data;
using TaskManagement.Models;

namespace TaskManagement.Repositories;

public class ProjectRepository(ApplicationDbContext context) : IProjectRepository
{
    public async Task<IEnumerable<Project>> GetAllProjects()
    {
        return await context.Projects
            .OrderBy(p => p.Name)
            .Include(p => p.Tasks)
            .ToListAsync();
    }

    public async Task<Project?> GetProject(int id)
    {
        return await context.Projects
            .FindAsync(id);
    }

    public async Task<Project> CreateProject(Project project)
    {
        await context.Projects.AddAsync(project);
        await context.SaveChangesAsync();

        return project;
    }

    public async Task<Project?> UpdateProject(Project project)
    {
        context.Projects.Update(project);
        await context.SaveChangesAsync();

        return project;
    }

    public async Task<bool> DeleteProject(int id)
    {
        var project = await context.Projects.FindAsync(id);
        
        if (project == null)
            return false;
        
        context.Projects.Remove(project);
        await context.SaveChangesAsync();

        return true;
    }
}
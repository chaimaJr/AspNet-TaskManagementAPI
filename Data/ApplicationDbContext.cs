using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using TaskManagement.Models;
using Task = TaskManagement.Models.Task;

namespace TaskManagement.Data;

public class ApplicationDbContext: DbContext
{
    public DbSet<Task> Tasks { get; set; }
    public DbSet<Project> Projects { get; set; }
    
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options) {}

    
    
}
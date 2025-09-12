using System.ComponentModel.DataAnnotations;

namespace TaskManagement.Models;

public class Project
{
    [Key] public int Id { get; set; }
    [Required][MaxLength(100)] 
    public string Name { get; set; } = null!;
    
    // Tasks List
    public ICollection<Task>? Tasks { get; set; }
}
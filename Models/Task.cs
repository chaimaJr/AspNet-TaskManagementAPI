using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TaskManagement.Models;

public class Task
{
    [Key] public int Id { get; set; }
    [Required][MaxLength(100)] 
    public string Title { get; set; } = null!;
    [MaxLength(300)] 
    public string? Description { get; set; }
    public bool IsCompleted { get; set; } = false;
    public DateTime CreatedAt { get; set; }
    
    // Project Relation
    [JsonIgnore][Required] 
    public Project Project { get; set; } = null!;
    public int ProjectId { get; set; }
}
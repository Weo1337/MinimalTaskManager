using TaskManager.Models;

namespace TaskManager.DTOs;

public class TaskResponseDTO
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public DateTime DueDate { get; set; }
    public TaskManagerStatus Status { get; set; }
}

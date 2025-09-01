namespace TaskManager.DTOs;

public class CreateTaskDTO
{
    public string Title { get; set; } = string.Empty;
    public DateTime DueDate { get; set; }
}

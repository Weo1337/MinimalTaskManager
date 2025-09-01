namespace TaskManager.Models;

public class TaskItem
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Title { get; set; } = string.Empty;
    public DateTime DueDate { get; set; }
    public TaskManagerStatus Status { get; set; } = TaskManagerStatus.Pending;
}

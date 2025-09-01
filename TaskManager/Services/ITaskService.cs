using TaskManager.DTOs;

namespace TaskManager.Services;

public interface ITaskService
{
    TaskResponseDTO CreateTask(CreateTaskDTO createTask);
    IEnumerable<TaskResponseDTO> GetTasks(string? status, DateTime? from, DateTime? to, int? top);
    bool MarkCompleted(Guid id);
    bool Delete(Guid id);
}

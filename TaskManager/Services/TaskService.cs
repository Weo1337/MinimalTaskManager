using TaskManager.DTOs;
using TaskManager.Models;
using TaskManager.Repositories;

namespace TaskManager.Services;

public class TaskService : ITaskService
{
    private readonly ITaskRepository _repository;

    public TaskService(ITaskRepository repository)
    {
        _repository = repository;
    }

    public TaskResponseDTO CreateTask(CreateTaskDTO createTask)
    {
        var task = new TaskItem
        {
            Title = createTask.Title,
            DueDate = createTask.DueDate
        };
        _repository.Add(task);
        return ToResponse(task);
    }

    public IEnumerable<TaskResponseDTO> GetTasks(string? status, DateTime? from, DateTime? to, int? top)
    {
        var query = _repository.GetAll().AsQueryable();

        if (!string.IsNullOrEmpty(status) && Enum.TryParse<TaskManagerStatus>(status, true, out var parsedStatus))
            query = query.Where(t => t.Status == parsedStatus);

        if (from.HasValue)
            query = query.Where(t => t.DueDate >= from.Value);

        if (to.HasValue)
            query = query.Where(t => t.DueDate <= to.Value);

        query = query.OrderBy(t => t.DueDate);

        if (top.HasValue)
            query = query.Take(top.Value);

        return query.Select(ToResponse).ToList();
    }

    public bool MarkCompleted(Guid id)
    {
        var task = _repository.GetById(id);
        if (task == null) return false;

        task.Status = TaskManagerStatus.Completed;
        _repository.Update(task);
        return true;
    }

    public bool Delete(Guid id)
    {
        var task = _repository.GetById(id);
        if (task == null) return false;

        _repository.Remove(id);
        return true;
    }

    private static TaskResponseDTO ToResponse(TaskItem task) =>
        new()
        {
            Id = task.Id,
            Title = task.Title,
            DueDate = task.DueDate,
            Status = task.Status
        };
}

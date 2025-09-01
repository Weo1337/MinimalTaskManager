using TaskManager.Models;

namespace TaskManager.Repositories;

public class TaskRepository : ITaskRepository
{
    private readonly List<TaskItem> _tasks = new();

    public TaskItem Add(TaskItem task)
    {
        _tasks.Add(task);
        return task;
    }

    public IEnumerable<TaskItem> GetAll() => _tasks;

    public TaskItem? GetById(Guid id) => _tasks.FirstOrDefault(t => t.Id == id);

    public void Remove(Guid id)
    {
        var task = GetById(id);
        if (task != null) _tasks.Remove(task);
    }

    public void Update(TaskItem task)
    {
        var existingTask = GetById(task.Id);
        if (existingTask != null)
        {
            existingTask.Title = task.Title;
            existingTask.DueDate = task.DueDate;
            existingTask.Status = task.Status;
        }
    }
}

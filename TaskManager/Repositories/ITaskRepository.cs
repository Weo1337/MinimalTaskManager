using TaskManager.Models;

namespace TaskManager.Repositories;

public interface ITaskRepository
{
    TaskItem Add(TaskItem task);
    IEnumerable<TaskItem> GetAll();
    TaskItem? GetById(Guid id);
    void Remove(Guid id);
    void Update(TaskItem task);
}

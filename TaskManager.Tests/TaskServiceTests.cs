using TaskManager.DTOs;
using TaskManager.Repositories;
using TaskManager.Services;

namespace TaskManager.Tests;

public class TaskServiceTests
{
    [Fact]
    public void AddTask_RetrieveTask_Success()
    {
        var repo = new TaskRepository();
        var service = new TaskService(repo);

        var dto = new CreateTaskDTO
        {
            Title = "Test Task",
            DueDate = DateTime.UtcNow
        };

        var created = service.CreateTask(dto);

        var tasks = service.GetTasks(null, null, null, null);

        Assert.Single(tasks);
        Assert.Equal("Test Task", tasks.First().Title);
    }
}
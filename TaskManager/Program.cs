using TaskManager.DTOs;
using TaskManager.Repositories;
using TaskManager.Services;

var builder = WebApplication.CreateBuilder(args);

// Register services
builder.Services.AddSingleton<ITaskRepository, TaskRepository>();
builder.Services.AddScoped<ITaskService, TaskService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

// nable Swagger middleware
if (app.Environment.IsDevelopment() || app.Environment.IsStaging() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// API endpoints
app.MapPost("/tasks", (CreateTaskDTO dto, ITaskService service) =>
{
    var task = service.CreateTask(dto);
    return Results.Created($"/tasks/{task.Id}", task);
});

app.MapGet("/tasks", (string? status, DateTime? from, DateTime? to, int? top, ITaskService service) =>
{
    var tasks = service.GetTasks(status, from, to, top);
    return Results.Ok(tasks);
});

app.MapPut("/tasks/{id}/complete", (Guid id, ITaskService service) =>
{
    return service.MarkCompleted(id) ? Results.NoContent() : Results.NotFound();
});

app.MapDelete("/tasks/{id}", (Guid id, ITaskService service) =>
{
    return service.Delete(id) ? Results.NoContent() : Results.NotFound();
});

app.Run();

# Minimal Task Manager API

## Requirements
- .NET 8 SDK

## Run
- cd TaskManager.Api
- dotnet run

## API Endpoints

- **Create Task:**  
  **POST** `/tasks`  
  Request body example:
  ```json
  {
    "title": "Task 1",
    "dueDate": "2025-09-03T20:00:00Z"
  }

- **List Tasks:**
  **GET** `/tasks`
	```
	GET /tasks?from=2025-09-01&to=2025-09-15
	```

- **Optional Query Parameters:**
- `status` – Filter by task status (`Pending` or `Completed`)
- `from` – Start of due date range (ISO date, e.g., `2025-09-01`)
- `to` – End of due date range (ISO date, e.g., `2025-09-30`)
- `top` – Limit the number of tasks returned

- **Put Task:**
  **PUT** `/tasks{id}/complete`
	```
	PUT /tasks/3fa85f64-5717-4562-b3fc-2c963f66afa6/complete
	```
	
- **Delete Task:**
  **DELETE** `/tasks{id}`
	```
	DELETE /tasks/3fa85f64-5717-4562-b3fc-2c963f66afa6
	```

### 📚 Mentoring a Junior Dev

If I mentored a junior dev on this task, I’d emphasize:

- Naming – Meaningful names (TaskItem, TaskService) make code readable.

- Separation of Concerns – Controllers/Endpoints don’t contain business logic.

- Testing – Start with at least one unit test for the core service.

- LINQ – Powerful for filtering/sorting collections in a readable way.

- Git hygiene – Small commits, meaningful commit messages, PR reviews.

- Scalability – Start simple (in-memory), but structure code so you can swap in a real DB later without rewriting services.
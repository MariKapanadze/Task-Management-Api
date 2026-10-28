\# Task Management API



A REST API for managing tasks, built with C# and ASP.NET Core Web API.


# Task Management API

A RESTful task management backend built with ASP.NET Core Web API, Entity Framework Core, and SQLite.

## Features

- Create, retrieve, update, and delete tasks.
- Update task status.
- Filter tasks by status, assignee, and title.
- Combine multiple filters using AND logic.
- Persist task data using SQLite.
- Seed 10 sample tasks automatically in the Development environment when the task table is empty.
- Handle unexpected exceptions through centralized middleware.
- Explore API endpoints using Swagger UI and OpenAPI documentation.
- Run automated unit tests with xUnit.

## Technologies

- C#
- .NET 10
- ASP.NET Core Web API
- Entity Framework Core
- SQLite
- Swagger / OpenAPI
- xUnit

## Project Structure

```text
Task_Management_Api/
├── Controllers/
├── Data/
│   ├── TaskManagementDbContext.cs
│   └── DbSeeder.cs
├── DTOs/
├── Middleware/
│   └── ExceptionHandlingMiddleware.cs
├── Models/
├── Repositories/
├── Services/
├── Program.cs
└── appsettings.json

Task_Management_Api.Tests/
└── UnitTest1.cs
```

## Prerequisites

Install the following:

- .NET 10 SDK
- Visual Studio with ASP.NET and web development support, or another .NET-compatible editor
- Git

## Getting Started

### 1. Clone the repository

```bash
git clone https://github.com/MariKapanadze/Task-Management-Api.git
cd Task-Management-Api
```

### 2. Restore dependencies

```bash
dotnet restore
```

### 3. Configure the database

The application uses SQLite. The default connection string is configured in `Task_Management_Api/appsettings.json`.

Example:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Data Source=tasks.db"
  }
}
```

The database file is created or accessed according to the configured connection string.

### 4. Apply database migrations

If the database has not been initialized, run:

```bash
dotnet ef database update --project Task_Management_Api
```

If the Entity Framework command is unavailable, install the tool:

```bash
dotnet tool install --global dotnet-ef
```

If it is already installed, update it when necessary:

```bash
dotnet tool update --global dotnet-ef
```

### 5. Run the API

```bash
dotnet run --project Task_Management_Api
```

Use the local URL printed in the terminal.

In Development mode, Swagger UI is available at `/swagger`, and the OpenAPI JSON document is available at `/openapi/v1.json` on the same host and port.

## API Endpoints

The API provides endpoints for creating, retrieving, updating, and deleting tasks, as well as updating task status.

| Method | Endpoint | Purpose |
|---|---|---|
| GET | `/api/tasks` | Retrieve tasks, optionally filtered |
| GET | `/api/tasks/{id}` | Retrieve a task by ID |
| POST | `/api/tasks` | Create a task |
| PUT | `/api/tasks/{id}` | Update task details |
| PATCH | `/api/tasks/{id}/status` | Update task status |
| DELETE | `/api/tasks/{id}` | Delete a task |

Check Swagger UI for the exact request and response schemas.

## Filtering Tasks

The `GET /api/tasks` endpoint supports three optional query parameters:

- `status`
- `assignee`
- `title`

Examples:

```http
GET /api/tasks
GET /api/tasks?status=DONE
GET /api/tasks?assignee=Alice
GET /api/tasks?title=login
GET /api/tasks?status=DONE&assignee=Alice&title=login
```

When multiple filters are provided, all conditions must match. Assignee and title matching are case-insensitive, and title filtering supports partial matches.

Available task statuses are:

- `TO_DO`
- `IN_PROGRESS`
- `DONE`

## Database Seeding

When the application runs in the Development environment, it checks whether the task table already contains records.

If the table is empty, the seeder inserts 10 sample tasks. If tasks already exist, it skips seeding to avoid inserting duplicates.

## Error Handling

Centralized exception-handling middleware catches unexpected exceptions and returns a JSON response containing:

- `timestamp`
- `status`
- `error`
- `message`
- `path`

Unexpected exceptions return HTTP `500 Internal Server Error`. Missing tasks return HTTP `404 Not Found` through the API's existing endpoint behavior.

## Running Tests

Run the automated test suite from the repository root:

```bash
dotnet test
```

The tests cover task service operations, validation, filtering, and the exception-handling middleware.

## Git Branches

- `main` — main branch
- `development` — development work

## License

Add a license here if the project is distributed under a specific open-source license.

\## Technologies# Task Management API

A RESTful task management backend built with ASP.NET Core Web API, Entity Framework Core, and SQLite.

## Features

- Create, retrieve, update, and delete tasks.
- Update task status.
- Filter tasks by status, assignee, and title.
- Combine multiple filters using AND logic.
- Persist task data using SQLite.
- Seed 10 sample tasks automatically in the Development environment when the task table is empty.
- Handle unexpected exceptions through centralized middleware.
- Explore API endpoints using Swagger UI and OpenAPI documentation.
- Run automated unit tests with xUnit.

## Technologies

- C#
- .NET 10
- ASP.NET Core Web API
- Entity Framework Core
- SQLite
- Swagger / OpenAPI
- xUnit

## Project Structure

```text
Task_Management_Api/
├── Controllers/
├── Data/
│   ├── TaskManagementDbContext.cs
│   └── DbSeeder.cs
├── DTOs/
├── Middleware/
│   └── ExceptionHandlingMiddleware.cs
├── Models/
├── Repositories/
├── Services/
├── Program.cs
└── appsettings.json

Task_Management_Api.Tests/
└── UnitTest1.cs
```

## Prerequisites

Install the following:

- .NET 10 SDK
- Visual Studio with ASP.NET and web development support, or another .NET-compatible editor
- Git

## Getting Started

### 1. Clone the repository

```bash
git clone https://github.com/MariKapanadze/Task-Management-Api.git
cd Task-Management-Api
```

### 2. Restore dependencies

```bash
dotnet restore
```

### 3. Configure the database

The application uses SQLite. The default connection string is configured in `Task_Management_Api/appsettings.json`.

Example:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Data Source=tasks.db"
  }
}
```

The database file is created or accessed according to the configured connection string.

### 4. Apply database migrations

If the database has not been initialized, run:

```bash
dotnet ef database update --project Task_Management_Api
```

If the Entity Framework command is unavailable, install the tool:

```bash
dotnet tool install --global dotnet-ef
```

If it is already installed, update it when necessary:

```bash
dotnet tool update --global dotnet-ef
```

### 5. Run the API

```bash
dotnet run --project Task_Management_Api
```

Use the local URL printed in the terminal.

In Development mode, Swagger UI is available at `/swagger`, and the OpenAPI JSON document is available at `/openapi/v1.json` on the same host and port.

## API Endpoints

The API provides endpoints for creating, retrieving, updating, and deleting tasks, as well as updating task status.

| Method | Endpoint | Purpose |
|---|---|---|
| GET | `/api/tasks` | Retrieve tasks, optionally filtered |
| GET | `/api/tasks/{id}` | Retrieve a task by ID |
| POST | `/api/tasks` | Create a task |
| PUT | `/api/tasks/{id}` | Update task details |
| PATCH | `/api/tasks/{id}/status` | Update task status |
| DELETE | `/api/tasks/{id}` | Delete a task |

Check Swagger UI for the exact request and response schemas.

## Filtering Tasks

The `GET /api/tasks` endpoint supports three optional query parameters:

- `status`
- `assignee`
- `title`

Examples:

```http
GET /api/tasks
GET /api/tasks?status=DONE
GET /api/tasks?assignee=Alice
GET /api/tasks?title=login
GET /api/tasks?status=DONE&assignee=Alice&title=login
```

When multiple filters are provided, all conditions must match. Assignee and title matching are case-insensitive, and title filtering supports partial matches.

Available task statuses are:

- `TO_DO`
- `IN_PROGRESS`
- `DONE`

## Database Seeding

When the application runs in the Development environment, it checks whether the task table already contains records.

If the table is empty, the seeder inserts 10 sample tasks. If tasks already exist, it skips seeding to avoid inserting duplicates.

## Error Handling

Centralized exception-handling middleware catches unexpected exceptions and returns a JSON response containing:

- `timestamp`
- `status`
- `error`
- `message`
- `path`

Unexpected exceptions return HTTP `500 Internal Server Error`. Missing tasks return HTTP `404 Not Found` through the API's existing endpoint behavior.

## Running Tests

Run the automated test suite from the repository root:

```bash
dotnet test
```

The tests cover task service operations, validation, filtering, and the exception-handling middleware.

## Git Branches

- `main` — main branch
- `development` — development work

## License

Add a license here if the project is distributed under a specific open-source license.

# Task Management API

A RESTful task management backend built with ASP.NET Core Web API, Entity Framework Core, and SQLite.

## Features

- Create, retrieve, update, and delete tasks.
- Update task status.
- Filter tasks by status, assignee, and title.
- Combine multiple filters using AND logic.
- Persist task data using SQLite.
- Seed 10 sample tasks automatically in the Development environment when the task table is empty.
- Handle unexpected exceptions through centralized middleware.
- Explore API endpoints using Swagger UI and OpenAPI documentation.
- Run automated unit tests with xUnit.

## Technologies

- C#
- .NET 10
- ASP.NET Core Web API
- Entity Framework Core
- SQLite
- Swagger / OpenAPI
- xUnit

## Project Structure

```text
Task_Management_Api/
├── Controllers/
├── Data/
│   ├── TaskManagementDbContext.cs
│   └── DbSeeder.cs
├── DTOs/
├── Middleware/
│   └── ExceptionHandlingMiddleware.cs
├── Models/
├── Repositories/
├── Services/
├── Program.cs
└── appsettings.json

Task_Management_Api.Tests/
└── UnitTest1.cs
```

## Prerequisites

Install the following:

- .NET 10 SDK
- Visual Studio with ASP.NET and web development support, or another .NET-compatible editor
- Git

## Getting Started

### 1. Clone the repository

```bash
git clone https://github.com/MariKapanadze/Task-Management-Api.git
cd Task-Management-Api
```

### 2. Restore dependencies

```bash
dotnet restore
```

### 3. Configure the database

The application uses SQLite. The default connection string is configured in `Task_Management_Api/appsettings.json`.

Example:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Data Source=tasks.db"
  }
}
```

The database file is created or accessed according to the configured connection string.

### 4. Apply database migrations

If the database has not been initialized, run:

```bash
dotnet ef database update --project Task_Management_Api
```

If the Entity Framework command is unavailable, install the tool:

```bash
dotnet tool install --global dotnet-ef
```

If it is already installed, update it when necessary:

```bash
dotnet tool update --global dotnet-ef
```

### 5. Run the API

```bash
dotnet run --project Task_Management_Api
```

Use the local URL printed in the terminal.

In Development mode, Swagger UI is available at `/swagger`, and the OpenAPI JSON document is available at `/openapi/v1.json` on the same host and port.

## API Endpoints

The API provides endpoints for creating, retrieving, updating, and deleting tasks, as well as updating task status.

| Method | Endpoint | Purpose |
|---|---|---|
| GET | `/api/tasks` | Retrieve tasks, optionally filtered |
| GET | `/api/tasks/{id}` | Retrieve a task by ID |
| POST | `/api/tasks` | Create a task |
| PUT | `/api/tasks/{id}` | Update task details |
| PATCH | `/api/tasks/{id}/status` | Update task status |
| DELETE | `/api/tasks/{id}` | Delete a task |

Check Swagger UI for the exact request and response schemas.

## Filtering Tasks

The `GET /api/tasks` endpoint supports three optional query parameters:

- `status`
- `assignee`
- `title`

Examples:

```http
GET /api/tasks
GET /api/tasks?status=DONE
GET /api/tasks?assignee=Alice
GET /api/tasks?title=login
GET /api/tasks?status=DONE&assignee=Alice&title=login
```

When multiple filters are provided, all conditions must match. Assignee and title matching are case-insensitive, and title filtering supports partial matches.

Available task statuses are:

- `TO_DO`
- `IN_PROGRESS`
- `DONE`

## Database Seeding

When the application runs in the Development environment, it checks whether the task table already contains records.

If the table is empty, the seeder inserts 10 sample tasks. If tasks already exist, it skips seeding to avoid inserting duplicates.

## Error Handling

Centralized exception-handling middleware catches unexpected exceptions and returns a JSON response containing:

- `timestamp`
- `status`
- `error`
- `message`
- `path`

Unexpected exceptions return HTTP `500 Internal Server Error`. Missing tasks return HTTP `404 Not Found` through the API's existing endpoint behavior.

## Running Tests

Run the automated test suite from the repository root:

```bash
dotnet test
```

The tests cover task service operations, validation, filtering, and the exception-handling middleware.

## Git Branches

- `main` — main branch
- `development` — development work

## License

Add a license here if the project is distributed under a specific open-source license.

# Task Management API

A RESTful task management backend built with ASP.NET Core Web API, Entity Framework Core, and SQLite.

## Features

- Create, retrieve, update, and delete tasks.
- Update task status.
- Filter tasks by status, assignee, and title.
- Combine multiple filters using AND logic.
- Persist task data using SQLite.
- Seed 10 sample tasks automatically in the Development environment when the task table is empty.
- Handle unexpected exceptions through centralized middleware.
- Explore API endpoints using Swagger UI and OpenAPI documentation.
- Run automated unit tests with xUnit.

## Technologies

- C#
- .NET 10
- ASP.NET Core Web API
- Entity Framework Core
- SQLite
- Swagger / OpenAPI
- xUnit

## Project Structure

```text
Task_Management_Api/
├── Controllers/
├── Data/
│   ├── TaskManagementDbContext.cs
│   └── DbSeeder.cs
├── DTOs/
├── Middleware/
│   └── ExceptionHandlingMiddleware.cs
├── Models/
├── Repositories/
├── Services/
├── Program.cs
└── appsettings.json

Task_Management_Api.Tests/
└── UnitTest1.cs
```

## Prerequisites

Install the following:

- .NET 10 SDK
- Visual Studio with ASP.NET and web development support, or another .NET-compatible editor
- Git

## Getting Started

### 1. Clone the repository

```bash
git clone https://github.com/MariKapanadze/Task-Management-Api.git
cd Task-Management-Api
```

### 2. Restore dependencies

```bash
dotnet restore
```

### 3. Configure the database

The application uses SQLite. The default connection string is configured in `Task_Management_Api/appsettings.json`.

Example:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Data Source=tasks.db"
  }
}
```

The database file is created or accessed according to the configured connection string.

### 4. Apply database migrations

If the database has not been initialized, run:

```bash
dotnet ef database update --project Task_Management_Api
```

If the Entity Framework command is unavailable, install the tool:

```bash
dotnet tool install --global dotnet-ef
```

If it is already installed, update it when necessary:

```bash
dotnet tool update --global dotnet-ef
```

### 5. Run the API

```bash
dotnet run --project Task_Management_Api
```

Use the local URL printed in the terminal.

In Development mode, Swagger UI is available at `/swagger`, and the OpenAPI JSON document is available at `/openapi/v1.json` on the same host and port.

## API Endpoints

The API provides endpoints for creating, retrieving, updating, and deleting tasks, as well as updating task status.

| Method | Endpoint | Purpose |
|---|---|---|
| GET | `/api/tasks` | Retrieve tasks, optionally filtered |
| GET | `/api/tasks/{id}` | Retrieve a task by ID |
| POST | `/api/tasks` | Create a task |
| PUT | `/api/tasks/{id}` | Update task details |
| PATCH | `/api/tasks/{id}/status` | Update task status |
| DELETE | `/api/tasks/{id}` | Delete a task |

Check Swagger UI for the exact request and response schemas.

## Filtering Tasks

The `GET /api/tasks` endpoint supports three optional query parameters:

- `status`
- `assignee`
- `title`

Examples:

```http
GET /api/tasks
GET /api/tasks?status=DONE
GET /api/tasks?assignee=Alice
GET /api/tasks?title=login
GET /api/tasks?status=DONE&assignee=Alice&title=login
```

When multiple filters are provided, all conditions must match. Assignee and title matching are case-insensitive, and title filtering supports partial matches.

Available task statuses are:

- `TO_DO`
- `IN_PROGRESS`
- `DONE`

## Database Seeding

When the application runs in the Development environment, it checks whether the task table already contains records.

If the table is empty, the seeder inserts 10 sample tasks. If tasks already exist, it skips seeding to avoid inserting duplicates.

## Error Handling

Centralized exception-handling middleware catches unexpected exceptions and returns a JSON response containing:

- `timestamp`
- `status`
- `error`
- `message`
- `path`

Unexpected exceptions return HTTP `500 Internal Server Error`. Missing tasks return HTTP `404 Not Found` through the API's existing endpoint behavior.

## Running Tests

Run the automated test suite from the repository root:

```bash
dotnet test
```

The tests cover task service operations, validation, filtering, and the exception-handling middleware.

## Git Branches

- `main` — main branch
- `development` — development work

## License

Add a license here if the project is distributed under a specific open-source license.

# Task Management API

A RESTful task management backend built with ASP.NET Core Web API, Entity Framework Core, and SQLite.

## Features

- Create, retrieve, update, and delete tasks.
- Update task status.
- Filter tasks by status, assignee, and title.
- Combine multiple filters using AND logic.
- Persist task data using SQLite.
- Seed 10 sample tasks automatically in the Development environment when the task table is empty.
- Handle unexpected exceptions through centralized middleware.
- Explore API endpoints using Swagger UI and OpenAPI documentation.
- Run automated unit tests with xUnit.

## Technologies

- C#
- .NET 10
- ASP.NET Core Web API
- Entity Framework Core
- SQLite
- Swagger / OpenAPI
- xUnit

## Project Structure

```text
Task_Management_Api/
├── Controllers/
├── Data/
│   ├── TaskManagementDbContext.cs
│   └── DbSeeder.cs
├── DTOs/
├── Middleware/
│   └── ExceptionHandlingMiddleware.cs
├── Models/
├── Repositories/
├── Services/
├── Program.cs
└── appsettings.json

Task_Management_Api.Tests/
└── UnitTest1.cs
```

## Prerequisites

Install the following:

- .NET 10 SDK
- Visual Studio with ASP.NET and web development support, or another .NET-compatible editor
- Git

## Getting Started

### 1. Clone the repository

```bash
git clone https://github.com/MariKapanadze/Task-Management-Api.git
cd Task-Management-Api
```

### 2. Restore dependencies

```bash
dotnet restore
```

### 3. Configure the database

The application uses SQLite. The default connection string is configured in `Task_Management_Api/appsettings.json`.

Example:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Data Source=tasks.db"
  }
}
```

The database file is created or accessed according to the configured connection string.

### 4. Apply database migrations

If the database has not been initialized, run:

```bash
dotnet ef database update --project Task_Management_Api
```

If the Entity Framework command is unavailable, install the tool:

```bash
dotnet tool install --global dotnet-ef
```

If it is already installed, update it when necessary:

```bash
dotnet tool update --global dotnet-ef
```

### 5. Run the API

```bash
dotnet run --project Task_Management_Api
```

Use the local URL printed in the terminal.

In Development mode, Swagger UI is available at `/swagger`, and the OpenAPI JSON document is available at `/openapi/v1.json` on the same host and port.

## API Endpoints

The API provides endpoints for creating, retrieving, updating, and deleting tasks, as well as updating task status.

| Method | Endpoint | Purpose |
|---|---|---|
| GET | `/api/tasks` | Retrieve tasks, optionally filtered |
| GET | `/api/tasks/{id}` | Retrieve a task by ID |
| POST | `/api/tasks` | Create a task |
| PUT | `/api/tasks/{id}` | Update task details |
| PATCH | `/api/tasks/{id}/status` | Update task status |
| DELETE | `/api/tasks/{id}` | Delete a task |

Check Swagger UI for the exact request and response schemas.

## Filtering Tasks

The `GET /api/tasks` endpoint supports three optional query parameters:

- `status`
- `assignee`
- `title`

Examples:

```http
GET /api/tasks
GET /api/tasks?status=DONE
GET /api/tasks?assignee=Alice
GET /api/tasks?title=login
GET /api/tasks?status=DONE&assignee=Alice&title=login
```

When multiple filters are provided, all conditions must match. Assignee and title matching are case-insensitive, and title filtering supports partial matches.

Available task statuses are:

- `TO_DO`
- `IN_PROGRESS`
- `DONE`

## Database Seeding

When the application runs in the Development environment, it checks whether the task table already contains records.

If the table is empty, the seeder inserts 10 sample tasks. If tasks already exist, it skips seeding to avoid inserting duplicates.

## Error Handling

Centralized exception-handling middleware catches unexpected exceptions and returns a JSON response containing:

- `timestamp`
- `status`
- `error`
- `message`
- `path`

Unexpected exceptions return HTTP `500 Internal Server Error`. Missing tasks return HTTP `404 Not Found` through the API's existing endpoint behavior.

## Running Tests

Run the automated test suite from the repository root:

```bash
dotnet test
```

The tests cover task service operations, validation, filtering, and the exception-handling middleware.

## Git Branches

- `main` — main branch
- `development` — development work

## License

Add a license here if the project is distributed under a specific open-source license.

\- C## Task Management API

A RESTful task management backend built with ASP.NET Core Web API, Entity Framework Core, and SQLite.

## Features

- Create, retrieve, update, and delete tasks.
- Update task status.
- Filter tasks by status, assignee, and title.
- Combine multiple filters using AND logic.
- Persist task data using SQLite.
- Seed 10 sample tasks automatically in the Development environment when the task table is empty.
- Handle unexpected exceptions through centralized middleware.
- Explore API endpoints using Swagger UI and OpenAPI documentation.
- Run automated unit tests with xUnit.

## Technologies

- C#
- .NET 10
- ASP.NET Core Web API
- Entity Framework Core
- SQLite
- Swagger / OpenAPI
- xUnit

## Project Structure

```text
Task_Management_Api/
├── Controllers/
├── Data/
│   ├── TaskManagementDbContext.cs
│   └── DbSeeder.cs
├── DTOs/
├── Middleware/
│   └── ExceptionHandlingMiddleware.cs
├── Models/
├── Repositories/
├── Services/
├── Program.cs
└── appsettings.json

Task_Management_Api.Tests/
└── UnitTest1.cs
```

## Prerequisites

Install the following:

- .NET 10 SDK
- Visual Studio with ASP.NET and web development support, or another .NET-compatible editor
- Git

## Getting Started

### 1. Clone the repository

```bash
git clone https://github.com/MariKapanadze/Task-Management-Api.git
cd Task-Management-Api
```

### 2. Restore dependencies

```bash
dotnet restore
```

### 3. Configure the database

The application uses SQLite. The default connection string is configured in `Task_Management_Api/appsettings.json`.

Example:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Data Source=tasks.db"
  }
}
```

The database file is created or accessed according to the configured connection string.

### 4. Apply database migrations

If the database has not been initialized, run:

```bash
dotnet ef database update --project Task_Management_Api
```

If the Entity Framework command is unavailable, install the tool:

```bash
dotnet tool install --global dotnet-ef
```

If it is already installed, update it when necessary:

```bash
dotnet tool update --global dotnet-ef
```

### 5. Run the API

```bash
dotnet run --project Task_Management_Api
```

Use the local URL printed in the terminal.

In Development mode, Swagger UI is available at `/swagger`, and the OpenAPI JSON document is available at `/openapi/v1.json` on the same host and port.

## API Endpoints

The API provides endpoints for creating, retrieving, updating, and deleting tasks, as well as updating task status.

| Method | Endpoint | Purpose |
|---|---|---|
| GET | `/api/tasks` | Retrieve tasks, optionally filtered |
| GET | `/api/tasks/{id}` | Retrieve a task by ID |
| POST | `/api/tasks` | Create a task |
| PUT | `/api/tasks/{id}` | Update task details |
| PATCH | `/api/tasks/{id}/status` | Update task status |
| DELETE | `/api/tasks/{id}` | Delete a task |

Check Swagger UI for the exact request and response schemas.

## Filtering Tasks

The `GET /api/tasks` endpoint supports three optional query parameters:

- `status`
- `assignee`
- `title`

Examples:

```http
GET /api/tasks
GET /api/tasks?status=DONE
GET /api/tasks?assignee=Alice
GET /api/tasks?title=login
GET /api/tasks?status=DONE&assignee=Alice&title=login
```

When multiple filters are provided, all conditions must match. Assignee and title matching are case-insensitive, and title filtering supports partial matches.

Available task statuses are:

- `TO_DO`
- `IN_PROGRESS`
- `DONE`

## Database Seeding

When the application runs in the Development environment, it checks whether the task table already contains records.

If the table is empty, the seeder inserts 10 sample tasks. If tasks already exist, it skips seeding to avoid inserting duplicates.

## Error Handling

Centralized exception-handling middleware catches unexpected exceptions and returns a JSON response containing:

- `timestamp`
- `status`
- `error`
- `message`
- `path`

Unexpected exceptions return HTTP `500 Internal Server Error`. Missing tasks return HTTP `404 Not Found` through the API's existing endpoint behavior.

## Running Tests

Run the automated test suite from the repository root:

```bash
dotnet test
```

The tests cover task service operations, validation, filtering, and the exception-handling middleware.

## Git Branches

- `main` — main branch
- `development` — development work

## License

Add a license here if the project is distributed under a specific open-source license.

# Task Management API

A RESTful task management backend built with ASP.NET Core Web API, Entity Framework Core, and SQLite.

## Features

- Create, retrieve, update, and delete tasks.
- Update task status.
- Filter tasks by status, assignee, and title.
- Combine multiple filters using AND logic.
- Persist task data using SQLite.
- Seed 10 sample tasks automatically in the Development environment when the task table is empty.
- Handle unexpected exceptions through centralized middleware.
- Explore API endpoints using Swagger UI and OpenAPI documentation.
- Run automated unit tests with xUnit.

## Technologies

- C#
- .NET 10
- ASP.NET Core Web API
- Entity Framework Core
- SQLite
- Swagger / OpenAPI
- xUnit

## Project Structure

```text
Task_Management_Api/
├── Controllers/
├── Data/
│   ├── TaskManagementDbContext.cs
│   └── DbSeeder.cs
├── DTOs/
├── Middleware/
│   └── ExceptionHandlingMiddleware.cs
├── Models/
├── Repositories/
├── Services/
├── Program.cs
└── appsettings.json

Task_Management_Api.Tests/
└── UnitTest1.cs
```

## Prerequisites

Install the following:

- .NET 10 SDK
- Visual Studio with ASP.NET and web development support, or another .NET-compatible editor
- Git

## Getting Started

### 1. Clone the repository

```bash
git clone https://github.com/MariKapanadze/Task-Management-Api.git
cd Task-Management-Api
```

### 2. Restore dependencies

```bash
dotnet restore
```

### 3. Configure the database

The application uses SQLite. The default connection string is configured in `Task_Management_Api/appsettings.json`.

Example:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Data Source=tasks.db"
  }
}
```

The database file is created or accessed according to the configured connection string.

### 4. Apply database migrations

If the database has not been initialized, run:

```bash
dotnet ef database update --project Task_Management_Api
```

If the Entity Framework command is unavailable, install the tool:

```bash
dotnet tool install --global dotnet-ef
```

If it is already installed, update it when necessary:

```bash
dotnet tool update --global dotnet-ef
```

### 5. Run the API

```bash
dotnet run --project Task_Management_Api
```

Use the local URL printed in the terminal.

In Development mode, Swagger UI is available at `/swagger`, and the OpenAPI JSON document is available at `/openapi/v1.json` on the same host and port.

## API Endpoints

The API provides endpoints for creating, retrieving, updating, and deleting tasks, as well as updating task status.

| Method | Endpoint | Purpose |
|---|---|---|
| GET | `/api/tasks` | Retrieve tasks, optionally filtered |
| GET | `/api/tasks/{id}` | Retrieve a task by ID |
| POST | `/api/tasks` | Create a task |
| PUT | `/api/tasks/{id}` | Update task details |
| PATCH | `/api/tasks/{id}/status` | Update task status |
| DELETE | `/api/tasks/{id}` | Delete a task |

Check Swagger UI for the exact request and response schemas.

## Filtering Tasks

The `GET /api/tasks` endpoint supports three optional query parameters:

- `status`
- `assignee`
- `title`

Examples:

```http
GET /api/tasks
GET /api/tasks?status=DONE
GET /api/tasks?assignee=Alice
GET /api/tasks?title=login
GET /api/tasks?status=DONE&assignee=Alice&title=login
```

When multiple filters are provided, all conditions must match. Assignee and title matching are case-insensitive, and title filtering supports partial matches.

Available task statuses are:

- `TO_DO`
- `IN_PROGRESS`
- `DONE`

## Database Seeding

When the application runs in the Development environment, it checks whether the task table already contains records.

If the table is empty, the seeder inserts 10 sample tasks. If tasks already exist, it skips seeding to avoid inserting duplicates.

## Error Handling

Centralized exception-handling middleware catches unexpected exceptions and returns a JSON response containing:

- `timestamp`
- `status`
- `error`
- `message`
- `path`

Unexpected exceptions return HTTP `500 Internal Server Error`. Missing tasks return HTTP `404 Not Found` through the API's existing endpoint behavior.

## Running Tests

Run the automated test suite from the repository root:

```bash
dotnet test
```

The tests cover task service operations, validation, filtering, and the exception-handling middleware.

## Git Branches

- `main` — main branch
- `development` — development work

## License

Add a license here if the project is distributed under a specific open-source license.

\- ASP.NET Core Web API# Task Management API

A RESTful task management backend built with ASP.NET Core Web API, Entity Framework Core, and SQLite.

## Features

- Create, retrieve, update, and delete tasks.
- Update task status.
- Filter tasks by status, assignee, and title.
- Combine multiple filters using AND logic.
- Persist task data using SQLite.
- Seed 10 sample tasks automatically in the Development environment when the task table is empty.
- Handle unexpected exceptions through centralized middleware.
- Explore API endpoints using Swagger UI and OpenAPI documentation.
- Run automated unit tests with xUnit.

## Technologies

- C#
- .NET 10
- ASP.NET Core Web API
- Entity Framework Core
- SQLite
- Swagger / OpenAPI
- xUnit

## Project Structure

```text
Task_Management_Api/
├── Controllers/
├── Data/
│   ├── TaskManagementDbContext.cs
│   └── DbSeeder.cs
├── DTOs/
├── Middleware/
│   └── ExceptionHandlingMiddleware.cs
├── Models/
├── Repositories/
├── Services/
├── Program.cs
└── appsettings.json

Task_Management_Api.Tests/
└── UnitTest1.cs
```

## Prerequisites

Install the following:

- .NET 10 SDK
- Visual Studio with ASP.NET and web development support, or another .NET-compatible editor
- Git

## Getting Started

### 1. Clone the repository

```bash
git clone https://github.com/MariKapanadze/Task-Management-Api.git
cd Task-Management-Api
```

### 2. Restore dependencies

```bash
dotnet restore
```

### 3. Configure the database

The application uses SQLite. The default connection string is configured in `Task_Management_Api/appsettings.json`.

Example:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Data Source=tasks.db"
  }
}
```

The database file is created or accessed according to the configured connection string.

### 4. Apply database migrations

If the database has not been initialized, run:

```bash
dotnet ef database update --project Task_Management_Api
```

If the Entity Framework command is unavailable, install the tool:

```bash
dotnet tool install --global dotnet-ef
```

If it is already installed, update it when necessary:

```bash
dotnet tool update --global dotnet-ef
```

### 5. Run the API

```bash
dotnet run --project Task_Management_Api
```

Use the local URL printed in the terminal.

In Development mode, Swagger UI is available at `/swagger`, and the OpenAPI JSON document is available at `/openapi/v1.json` on the same host and port.

## API Endpoints

The API provides endpoints for creating, retrieving, updating, and deleting tasks, as well as updating task status.

| Method | Endpoint | Purpose |
|---|---|---|
| GET | `/api/tasks` | Retrieve tasks, optionally filtered |
| GET | `/api/tasks/{id}` | Retrieve a task by ID |
| POST | `/api/tasks` | Create a task |
| PUT | `/api/tasks/{id}` | Update task details |
| PATCH | `/api/tasks/{id}/status` | Update task status |
| DELETE | `/api/tasks/{id}` | Delete a task |

Check Swagger UI for the exact request and response schemas.

## Filtering Tasks

The `GET /api/tasks` endpoint supports three optional query parameters:

- `status`
- `assignee`
- `title`

Examples:

```http
GET /api/tasks
GET /api/tasks?status=DONE
GET /api/tasks?assignee=Alice
GET /api/tasks?title=login
GET /api/tasks?status=DONE&assignee=Alice&title=login
```

When multiple filters are provided, all conditions must match. Assignee and title matching are case-insensitive, and title filtering supports partial matches.

Available task statuses are:

- `TO_DO`
- `IN_PROGRESS`
- `DONE`

## Database Seeding

When the application runs in the Development environment, it checks whether the task table already contains records.

If the table is empty, the seeder inserts 10 sample tasks. If tasks already exist, it skips seeding to avoid inserting duplicates.

## Error Handling

Centralized exception-handling middleware catches unexpected exceptions and returns a JSON response containing:

- `timestamp`
- `status`
- `error`
- `message`
- `path`

Unexpected exceptions return HTTP `500 Internal Server Error`. Missing tasks return HTTP `404 Not Found` through the API's existing endpoint behavior.

## Running Tests

Run the automated test suite from the repository root:

```bash
dotnet test
```

The tests cover task service operations, validation, filtering, and the exception-handling middleware.

## Git Branches

- `main` — main branch
- `development` — development work

## License

Add a license here if the project is distributed under a specific open-source license.

# Task Management API

A RESTful task management backend built with ASP.NET Core Web API, Entity Framework Core, and SQLite.

## Features

- Create, retrieve, update, and delete tasks.
- Update task status.
- Filter tasks by status, assignee, and title.
- Combine multiple filters using AND logic.
- Persist task data using SQLite.
- Seed 10 sample tasks automatically in the Development environment when the task table is empty.
- Handle unexpected exceptions through centralized middleware.
- Explore API endpoints using Swagger UI and OpenAPI documentation.
- Run automated unit tests with xUnit.

## Technologies

- C#
- .NET 10
- ASP.NET Core Web API
- Entity Framework Core
- SQLite
- Swagger / OpenAPI
- xUnit

## Project Structure

```text
Task_Management_Api/
├── Controllers/
├── Data/
│   ├── TaskManagementDbContext.cs
│   └── DbSeeder.cs
├── DTOs/
├── Middleware/
│   └── ExceptionHandlingMiddleware.cs
├── Models/
├── Repositories/
├── Services/
├── Program.cs
└── appsettings.json

Task_Management_Api.Tests/
└── UnitTest1.cs
```

## Prerequisites

Install the following:

- .NET 10 SDK
- Visual Studio with ASP.NET and web development support, or another .NET-compatible editor
- Git

## Getting Started

### 1. Clone the repository

```bash
git clone https://github.com/MariKapanadze/Task-Management-Api.git
cd Task-Management-Api
```

### 2. Restore dependencies

```bash
dotnet restore
```

### 3. Configure the database

The application uses SQLite. The default connection string is configured in `Task_Management_Api/appsettings.json`.

Example:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Data Source=tasks.db"
  }
}
```

The database file is created or accessed according to the configured connection string.

### 4. Apply database migrations

If the database has not been initialized, run:

```bash
dotnet ef database update --project Task_Management_Api
```

If the Entity Framework command is unavailable, install the tool:

```bash
dotnet tool install --global dotnet-ef
```

If it is already installed, update it when necessary:

```bash
dotnet tool update --global dotnet-ef
```

### 5. Run the API

```bash
dotnet run --project Task_Management_Api
```

Use the local URL printed in the terminal.

In Development mode, Swagger UI is available at `/swagger`, and the OpenAPI JSON document is available at `/openapi/v1.json` on the same host and port.

## API Endpoints

The API provides endpoints for creating, retrieving, updating, and deleting tasks, as well as updating task status.

| Method | Endpoint | Purpose |
|---|---|---|
| GET | `/api/tasks` | Retrieve tasks, optionally filtered |
| GET | `/api/tasks/{id}` | Retrieve a task by ID |
| POST | `/api/tasks` | Create a task |
| PUT | `/api/tasks/{id}` | Update task details |
| PATCH | `/api/tasks/{id}/status` | Update task status |
| DELETE | `/api/tasks/{id}` | Delete a task |

Check Swagger UI for the exact request and response schemas.

## Filtering Tasks

The `GET /api/tasks` endpoint supports three optional query parameters:

- `status`
- `assignee`
- `title`

Examples:

```http
GET /api/tasks
GET /api/tasks?status=DONE
GET /api/tasks?assignee=Alice
GET /api/tasks?title=login
GET /api/tasks?status=DONE&assignee=Alice&title=login
```

When multiple filters are provided, all conditions must match. Assignee and title matching are case-insensitive, and title filtering supports partial matches.

Available task statuses are:

- `TO_DO`
- `IN_PROGRESS`
- `DONE`

## Database Seeding

When the application runs in the Development environment, it checks whether the task table already contains records.

If the table is empty, the seeder inserts 10 sample tasks. If tasks already exist, it skips seeding to avoid inserting duplicates.

## Error Handling

Centralized exception-handling middleware catches unexpected exceptions and returns a JSON response containing:

- `timestamp`
- `status`
- `error`
- `message`
- `path`

Unexpected exceptions return HTTP `500 Internal Server Error`. Missing tasks return HTTP `404 Not Found` through the API's existing endpoint behavior.

## Running Tests

Run the automated test suite from the repository root:

```bash
dotnet test
```

The tests cover task service operations, validation, filtering, and the exception-handling middleware.

## Git Branches

- `main` — main branch
- `development` — development work

## License

Add a license here if the project is distributed under a specific open-source license.

\- .NET 10# Task Management API

A RESTful task management backend built with ASP.NET Core Web API, Entity Framework Core, and SQLite.

## Features

- Create, retrieve, update, and delete tasks.
- Update task status.
- Filter tasks by status, assignee, and title.
- Combine multiple filters using AND logic.
- Persist task data using SQLite.
- Seed 10 sample tasks automatically in the Development environment when the task table is empty.
- Handle unexpected exceptions through centralized middleware.
- Explore API endpoints using Swagger UI and OpenAPI documentation.
- Run automated unit tests with xUnit.

## Technologies

- C#
- .NET 10
- ASP.NET Core Web API
- Entity Framework Core
- SQLite
- Swagger / OpenAPI
- xUnit

## Project Structure

```text
Task_Management_Api/
├── Controllers/
├── Data/
│   ├── TaskManagementDbContext.cs
│   └── DbSeeder.cs
├── DTOs/
├── Middleware/
│   └── ExceptionHandlingMiddleware.cs
├── Models/
├── Repositories/
├── Services/
├── Program.cs
└── appsettings.json

Task_Management_Api.Tests/
└── UnitTest1.cs
```

## Prerequisites

Install the following:

- .NET 10 SDK
- Visual Studio with ASP.NET and web development support, or another .NET-compatible editor
- Git

## Getting Started

### 1. Clone the repository

```bash
git clone https://github.com/MariKapanadze/Task-Management-Api.git
cd Task-Management-Api
```

### 2. Restore dependencies

```bash
dotnet restore
```

### 3. Configure the database

The application uses SQLite. The default connection string is configured in `Task_Management_Api/appsettings.json`.

Example:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Data Source=tasks.db"
  }
}
```

The database file is created or accessed according to the configured connection string.

### 4. Apply database migrations

If the database has not been initialized, run:

```bash
dotnet ef database update --project Task_Management_Api
```

If the Entity Framework command is unavailable, install the tool:

```bash
dotnet tool install --global dotnet-ef
```

If it is already installed, update it when necessary:

```bash
dotnet tool update --global dotnet-ef
```

### 5. Run the API

```bash
dotnet run --project Task_Management_Api
```

Use the local URL printed in the terminal.

In Development mode, Swagger UI is available at `/swagger`, and the OpenAPI JSON document is available at `/openapi/v1.json` on the same host and port.

## API Endpoints

The API provides endpoints for creating, retrieving, updating, and deleting tasks, as well as updating task status.

| Method | Endpoint | Purpose |
|---|---|---|
| GET | `/api/tasks` | Retrieve tasks, optionally filtered |
| GET | `/api/tasks/{id}` | Retrieve a task by ID |
| POST | `/api/tasks` | Create a task |
| PUT | `/api/tasks/{id}` | Update task details |
| PATCH | `/api/tasks/{id}/status` | Update task status |
| DELETE | `/api/tasks/{id}` | Delete a task |

Check Swagger UI for the exact request and response schemas.

## Filtering Tasks

The `GET /api/tasks` endpoint supports three optional query parameters:

- `status`
- `assignee`
- `title`

Examples:

```http
GET /api/tasks
GET /api/tasks?status=DONE
GET /api/tasks?assignee=Alice
GET /api/tasks?title=login
GET /api/tasks?status=DONE&assignee=Alice&title=login
```

When multiple filters are provided, all conditions must match. Assignee and title matching are case-insensitive, and title filtering supports partial matches.

Available task statuses are:

- `TO_DO`
- `IN_PROGRESS`
- `DONE`

## Database Seeding

When the application runs in the Development environment, it checks whether the task table already contains records.

If the table is empty, the seeder inserts 10 sample tasks. If tasks already exist, it skips seeding to avoid inserting duplicates.

## Error Handling

Centralized exception-handling middleware catches unexpected exceptions and returns a JSON response containing:

- `timestamp`
- `status`
- `error`
- `message`
- `path`

Unexpected exceptions return HTTP `500 Internal Server Error`. Missing tasks return HTTP `404 Not Found` through the API's existing endpoint behavior.

## Running Tests

Run the automated test suite from the repository root:

```bash
dotnet test
```

The tests cover task service operations, validation, filtering, and the exception-handling middleware.

## Git Branches

- `main` — main branch
- `development` — development work

## License

Add a license here if the project is distributed under a specific open-source license.

# Task Management API

A RESTful task management backend built with ASP.NET Core Web API, Entity Framework Core, and SQLite.

## Features

- Create, retrieve, update, and delete tasks.
- Update task status.
- Filter tasks by status, assignee, and title.
- Combine multiple filters using AND logic.
- Persist task data using SQLite.
- Seed 10 sample tasks automatically in the Development environment when the task table is empty.
- Handle unexpected exceptions through centralized middleware.
- Explore API endpoints using Swagger UI and OpenAPI documentation.
- Run automated unit tests with xUnit.

## Technologies

- C#
- .NET 10
- ASP.NET Core Web API
- Entity Framework Core
- SQLite
- Swagger / OpenAPI
- xUnit

## Project Structure

```text
Task_Management_Api/
├── Controllers/
├── Data/
│   ├── TaskManagementDbContext.cs
│   └── DbSeeder.cs
├── DTOs/
├── Middleware/
│   └── ExceptionHandlingMiddleware.cs
├── Models/
├── Repositories/
├── Services/
├── Program.cs
└── appsettings.json

Task_Management_Api.Tests/
└── UnitTest1.cs
```

## Prerequisites

Install the following:

- .NET 10 SDK
- Visual Studio with ASP.NET and web development support, or another .NET-compatible editor
- Git

## Getting Started

### 1. Clone the repository

```bash
git clone https://github.com/MariKapanadze/Task-Management-Api.git
cd Task-Management-Api
```

### 2. Restore dependencies

```bash
dotnet restore
```

### 3. Configure the database

The application uses SQLite. The default connection string is configured in `Task_Management_Api/appsettings.json`.

Example:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Data Source=tasks.db"
  }
}
```

The database file is created or accessed according to the configured connection string.

### 4. Apply database migrations

If the database has not been initialized, run:

```bash
dotnet ef database update --project Task_Management_Api
```

If the Entity Framework command is unavailable, install the tool:

```bash
dotnet tool install --global dotnet-ef
```

If it is already installed, update it when necessary:

```bash
dotnet tool update --global dotnet-ef
```

### 5. Run the API

```bash
dotnet run --project Task_Management_Api
```

Use the local URL printed in the terminal.

In Development mode, Swagger UI is available at `/swagger`, and the OpenAPI JSON document is available at `/openapi/v1.json` on the same host and port.

## API Endpoints

The API provides endpoints for creating, retrieving, updating, and deleting tasks, as well as updating task status.

| Method | Endpoint | Purpose |
|---|---|---|
| GET | `/api/tasks` | Retrieve tasks, optionally filtered |
| GET | `/api/tasks/{id}` | Retrieve a task by ID |
| POST | `/api/tasks` | Create a task |
| PUT | `/api/tasks/{id}` | Update task details |
| PATCH | `/api/tasks/{id}/status` | Update task status |
| DELETE | `/api/tasks/{id}` | Delete a task |

Check Swagger UI for the exact request and response schemas.

## Filtering Tasks

The `GET /api/tasks` endpoint supports three optional query parameters:

- `status`
- `assignee`
- `title`

Examples:

```http
GET /api/tasks
GET /api/tasks?status=DONE
GET /api/tasks?assignee=Alice
GET /api/tasks?title=login
GET /api/tasks?status=DONE&assignee=Alice&title=login
```

When multiple filters are provided, all conditions must match. Assignee and title matching are case-insensitive, and title filtering supports partial matches.

Available task statuses are:

- `TO_DO`
- `IN_PROGRESS`
- `DONE`

## Database Seeding

When the application runs in the Development environment, it checks whether the task table already contains records.

If the table is empty, the seeder inserts 10 sample tasks. If tasks already exist, it skips seeding to avoid inserting duplicates.

## Error Handling

Centralized exception-handling middleware catches unexpected exceptions and returns a JSON response containing:

- `timestamp`
- `status`
- `error`
- `message`
- `path`

Unexpected exceptions return HTTP `500 Internal Server Error`. Missing tasks return HTTP `404 Not Found` through the API's existing endpoint behavior.

## Running Tests

Run the automated test suite from the repository root:

```bash
dotnet test
```

The tests cover task service operations, validation, filtering, and the exception-handling middleware.

## Git Branches

- `main` — main branch
- `development` — development work

## License

Add a license here if the project is distributed under a specific open-source license.

\- OpenAPI# Task Management API

A RESTful task management backend built with ASP.NET Core Web API, Entity Framework Core, and SQLite.

## Features

- Create, retrieve, update, and delete tasks.
- Update task status.
- Filter tasks by status, assignee, and title.
- Combine multiple filters using AND logic.
- Persist task data using SQLite.
- Seed 10 sample tasks automatically in the Development environment when the task table is empty.
- Handle unexpected exceptions through centralized middleware.
- Explore API endpoints using Swagger UI and OpenAPI documentation.
- Run automated unit tests with xUnit.

## Technologies

- C#
- .NET 10
- ASP.NET Core Web API
- Entity Framework Core
- SQLite
- Swagger / OpenAPI
- xUnit

## Project Structure

```text
Task_Management_Api/
├── Controllers/
├── Data/
│   ├── TaskManagementDbContext.cs
│   └── DbSeeder.cs
├── DTOs/
├── Middleware/
│   └── ExceptionHandlingMiddleware.cs
├── Models/
├── Repositories/
├── Services/
├── Program.cs
└── appsettings.json

Task_Management_Api.Tests/
└── UnitTest1.cs
```

## Prerequisites

Install the following:

- .NET 10 SDK
- Visual Studio with ASP.NET and web development support, or another .NET-compatible editor
- Git

## Getting Started

### 1. Clone the repository

```bash
git clone https://github.com/MariKapanadze/Task-Management-Api.git
cd Task-Management-Api
```

### 2. Restore dependencies

```bash
dotnet restore
```

### 3. Configure the database

The application uses SQLite. The default connection string is configured in `Task_Management_Api/appsettings.json`.

Example:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Data Source=tasks.db"
  }
}
```

The database file is created or accessed according to the configured connection string.

### 4. Apply database migrations

If the database has not been initialized, run:

```bash
dotnet ef database update --project Task_Management_Api
```

If the Entity Framework command is unavailable, install the tool:

```bash
dotnet tool install --global dotnet-ef
```

If it is already installed, update it when necessary:

```bash
dotnet tool update --global dotnet-ef
```

### 5. Run the API

```bash
dotnet run --project Task_Management_Api
```

Use the local URL printed in the terminal.

In Development mode, Swagger UI is available at `/swagger`, and the OpenAPI JSON document is available at `/openapi/v1.json` on the same host and port.

## API Endpoints

The API provides endpoints for creating, retrieving, updating, and deleting tasks, as well as updating task status.

| Method | Endpoint | Purpose |
|---|---|---|
| GET | `/api/tasks` | Retrieve tasks, optionally filtered |
| GET | `/api/tasks/{id}` | Retrieve a task by ID |
| POST | `/api/tasks` | Create a task |
| PUT | `/api/tasks/{id}` | Update task details |
| PATCH | `/api/tasks/{id}/status` | Update task status |
| DELETE | `/api/tasks/{id}` | Delete a task |

Check Swagger UI for the exact request and response schemas.

## Filtering Tasks

The `GET /api/tasks` endpoint supports three optional query parameters:

- `status`
- `assignee`
- `title`

Examples:

```http
GET /api/tasks
GET /api/tasks?status=DONE
GET /api/tasks?assignee=Alice
GET /api/tasks?title=login
GET /api/tasks?status=DONE&assignee=Alice&title=login
```

When multiple filters are provided, all conditions must match. Assignee and title matching are case-insensitive, and title filtering supports partial matches.

Available task statuses are:

- `TO_DO`
- `IN_PROGRESS`
- `DONE`

## Database Seeding

When the application runs in the Development environment, it checks whether the task table already contains records.

If the table is empty, the seeder inserts 10 sample tasks. If tasks already exist, it skips seeding to avoid inserting duplicates.

## Error Handling

Centralized exception-handling middleware catches unexpected exceptions and returns a JSON response containing:

- `timestamp`
- `status`
- `error`
- `message`
- `path`

Unexpected exceptions return HTTP `500 Internal Server Error`. Missing tasks return HTTP `404 Not Found` through the API's existing endpoint behavior.

## Running Tests

Run the automated test suite from the repository root:

```bash
dotnet test
```

The tests cover task service operations, validation, filtering, and the exception-handling middleware.

## Git Branches

- `main` — main branch
- `development` — development work

## License

Add a license here if the project is distributed under a specific open-source license.




\## Current Features



\- Health check endpoint: `GET /api/health`

\- OpenAPI specification



\## Running Locally



1\. Open `Task\_Management\_Api.slnx` in Visual Studio.

2\. Set `Task\_Management\_Api` as the startup project if necessary.

3\. Run the application.

4\. Open `/api/health` using the local URL printed by Visual Studio.



The health endpoint returns a JSON response indicating that the application is running.



\## Development



The repository uses the following branches:



\- `main` — stable version

\- `development` — integration and ongoing development



\## Project Status



The project is under development. Task CRUD operations, database integration, and authentication will be added in subsequent stages.


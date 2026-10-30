# Task Management API

A RESTful backend application for managing tasks, built with ASP.NET Core Web API and C#. The application supports task management, PostgreSQL persistence, user registration, Basic Authentication, and role-based authorization.

The project is containerized with Docker and includes automated unit and integration tests.

## Table of Contents

- [Overview](#overview)
- [Features](#features)
- [Technologies](#technologies)
- [Project Structure](#project-structure)
- [Prerequisites](#prerequisites)
- [Getting Started](#getting-started)
- [Environment Configuration](#environment-configuration)
- [Running the Application](#running-the-application)
- [API Endpoints](#api-endpoints)
- [Authentication and Authorization](#authentication-and-authorization)
- [Task Model](#task-model)
- [Database](#database)
- [Running Tests](#running-tests)
- [Git Workflow](#git-workflow)
- [Security Notes](#security-notes)

## Overview

The Task Management API provides endpoints for creating, retrieving, updating, filtering, and deleting tasks.

It uses PostgreSQL to persist application data and Entity Framework Core to interact with the database.

Users must authenticate to access protected endpoints. Access to specific operations depends on the user's role.

The application is designed to run locally or inside Docker containers.

## Features

### Task Management

- Create tasks.
- Retrieve tasks.
- Retrieve individual tasks by ID.
- Update existing tasks.
- Update task status.
- Filter tasks.
- Delete tasks, subject to authorization rules.
- Validate task data before processing requests.
- Persist task data in PostgreSQL.

### Authentication and Authorization

- Register new users.
- Authenticate requests using HTTP Basic Authentication.
- Hash user passwords using BCrypt.
- Support role-based access control.
- Restrict task deletion to administrators.
- Return appropriate HTTP status codes for unauthorized and forbidden requests.
- Seed a development administrator account using environment configuration.

### Database and Infrastructure

- PostgreSQL database integration.
- Entity Framework Core.
- Database migrations.
- Docker and Docker Compose configuration.
- Environment-based configuration for sensitive settings.

### Testing

- Unit tests for task service behavior.
- Tests for task validation and business logic.
- Tests for exception-handling middleware.
- Integration tests for authentication and authorization.
- Tests for user registration and invalid credentials.

## Technologies

| Technology | Purpose |
|---|---|
| C# | Programming language |
| .NET 10 | Application framework |
| ASP.NET Core Web API | HTTP API |
| Entity Framework Core | Object-relational mapping |
| PostgreSQL | Relational database |
| Docker | Containerization |
| Docker Compose | Running the application and database together |
| HTTP Basic Authentication | Request authentication |
| BCrypt | Password hashing |
| xUnit | Automated testing |
| SQLite | Isolated database provider for integration tests |
| Git | Version control |
| GitHub | Source code hosting |

## Project Structure

The repository contains the API project, its test project, and the configuration needed to run the application.

```text
Task_management_api/
│
├── Task_Management_Api/
│   ├── Controllers/
│   ├── Data/
│   ├── Models/
│   ├── DTOs/
│   ├── Services/
│   ├── Repositories/
│   ├── Middleware/
│   ├── Program.cs
│   └── Task_Management_Api.csproj
│
├── Task_Management_Api.Tests/
│   ├── AuthenticationTests.cs
│   ├── CustomWebApplicationFactory.cs
│   ├── ExceptionHandlingMiddlewareTests.cs
│   ├── UnitTest1.cs
│   └── Task_Management_Api.Tests..csproj
│
├── docker-compose.yml
├── .env
├── .gitignore
├── README.md
└── Task_Management_Api.slnx
```

**Note:** This structure summarizes the main project areas. Some folders may contain additional files, and the exact names should match the repository.

## Prerequisites

Install the following tools before running the application:

- [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0)
- [Docker Desktop](https://www.docker.com/products/docker-desktop/)
- [Git](https://git-scm.com/downloads)

An API client such as Swagger UI, Postman, or curl is useful for testing endpoints.

## Getting Started

### 1. Clone the repository

```bash
git clone https://github.com/MariKapanadze/Task-Management-Api.git
```

Navigate to the project directory:

```bash
cd Task-Management-Api
```

### 2. Configure environment variables

The application uses environment variables for database credentials and the development administrator's password.

Create a `.env` file in the repository root if one does not already exist.

Add the following variables:

```dotenv
POSTGRES_PASSWORD=replace_with_a_strong_database_password
ADMIN_SEED_PASSWORD=replace_with_a_strong_admin_password
```

Replace both example values with your own passwords.

**Important:** The `.env` file contains sensitive information and must not be committed to Git. The repository's `.gitignore` should exclude it.

### 3. Start Docker Desktop

Ensure Docker Desktop is running before continuing.

### 4. Start the application

From the repository root, run:

```bash
docker compose up --build
```

Docker Compose builds the API image and starts the configured services, including PostgreSQL.

Wait until the containers finish starting.

The API is expected to be accessible at:

```text
http://localhost:8080
```

Swagger UI:

```text
http://localhost:8080/swagger
```

The exact startup behavior depends on the Docker Compose and application configuration.

### 5. Verify the application

Open Swagger UI in your browser:

```text
http://localhost:8080/swagger
```

You can use Swagger to inspect available endpoints and send HTTP requests.

To check the health endpoint, send:

```http
GET /api/health
```

A successful response should indicate that the application is running.

Example response:

```json
{
  "status": "UP",
  "application": "task-management-api"
}
```

The exact response depends on the health controller implementation.

## Environment Configuration

The application uses environment variables to configure sensitive settings.

| Variable | Purpose |
|---|---|
| `POSTGRES_PASSWORD` | Password for the PostgreSQL database user |
| `ADMIN_SEED_PASSWORD` | Password used when creating the development administrator account |

The application and database must use matching database connection settings.

Do not store real passwords in source code, configuration files committed to Git, or this README.

## Running the Application

### Using Docker Compose

From the repository root:

```bash
docker compose up --build
```

To run the services in the background:

```bash
docker compose up --build -d
```

To inspect running containers:

```bash
docker compose ps
```

To view application logs:

```bash
docker compose logs -f
```

To stop the services:

```bash
docker compose down
```

Stopping the containers does not necessarily delete the database volume. Persistent database data may remain available when the services are started again.

**Warning:** Do not use `docker compose down -v` unless you intentionally want to remove the associated volumes and understand that database data stored there may be deleted.

### Running the API Locally

You can also run the API directly with the .NET SDK.

From the repository root:

```bash
dotnet restore
```

Build the solution:

```bash
dotnet build
```

Run the API project:

```bash
dotnet run --project Task_Management_Api
```

When running outside Docker, ensure that the database is running and that the API's database connection string points to the correct PostgreSQL host and port.

The local database configuration may differ from the Docker configuration.

## API Endpoints

The API exposes endpoints for health checks, authentication, and task management.

The tables below summarize the main routes. Refer to Swagger UI for the complete request schemas, query parameters, and response details.

### Health

| Method | Endpoint | Description |
|---|---|---|
| GET | `/api/health` | Checks whether the application is running |

### Authentication

| Method | Endpoint | Description |
|---|---|---|
| POST | `/api/Auth/register` | Registers a new user |

Authentication for protected endpoints uses HTTP Basic Authentication.

### Tasks

| Method | Endpoint | Description |
|---|---|---|
| GET | `/api/Tasks` | Retrieves tasks |
| GET | `/api/Tasks/{id}` | Retrieves a task by ID |
| POST | `/api/Tasks` | Creates a task |
| PUT | `/api/Tasks/{id}` | Updates an existing task |
| PATCH | `/api/Tasks/{id}/status` | Updates task status, if exposed by the current controller |
| DELETE | `/api/Tasks/{id}` | Deletes a task |

The status-update route shown above is illustrative; verify the exact route in Swagger before using it.

Task retrieval and filtering options depend on the implemented controller parameters.

### HTTP Status Codes

The API uses standard HTTP status codes to communicate the result of a request.

| Status Code | Meaning |
|---|---|
| `200 OK` | The request completed successfully |
| `201 Created` | A resource was created successfully |
| `204 No Content` | The operation succeeded without a response body |
| `400 Bad Request` | The request contains invalid data |
| `401 Unauthorized` | Authentication is missing or invalid |
| `403 Forbidden` | The authenticated user does not have permission |
| `404 Not Found` | The requested resource does not exist |
| `409 Conflict` | The request conflicts with existing data, such as a duplicate username |

## Authentication and Authorization

The API uses HTTP Basic Authentication to authenticate users.

A client sends credentials in the `Authorization` header:

```http
Authorization: Basic <base64-encoded-credentials>
```

The encoded value represents a username and password separated by a colon.

For example, a client can configure Basic Authentication directly in Swagger UI or Postman.

### User Roles

The application supports role-based authorization.

| Role | Permissions |
|---|---|
| USER | Access permitted task operations, including viewing, creating, and updating tasks |
| ADMIN | Access permitted task operations, including deleting tasks |

The API enforces permissions on protected endpoints. Authentication alone does not grant access to every operation.

### Registering a User

Send a `POST` request to:

```http
POST /api/Auth/register
```

Use the request schema displayed in Swagger UI.

A successful registration creates a user account. The API may reject invalid registration data or an existing username.

### Development Administrator

The application supports seeding a development administrator account using environment configuration.

Set the administrator seed password in the `.env` file before starting the application.

The seed configuration should be used only as intended by the development setup. Do not use development credentials as production credentials.

## Task Model

A task contains the following core fields:

| Field | Description |
|---|---|
| `Id` | Unique task identifier |
| `Title` | Task title |
| `Description` | Task description |
| `Status` | Current task status |
| `Assignee` | Person assigned to the task |
| `CreatedAt` | Date and time the task was created |
| `DueDate` | Optional deadline |

### Task Statuses

The supported task statuses are:

- `TO_DO` — The task has not been started.
- `IN_PROGRESS` — The task is currently being worked on.
- `DONE` — The task has been completed.

The API validates task data before processing requests.

For the precise validation rules and required fields, refer to the current DTOs and validation logic in the API project.

## Database

PostgreSQL is used to persist application data.

Entity Framework Core provides database access through the application's database context and related services.

### Database Migrations

The project uses Entity Framework Core migrations to manage database schema changes.

If the Entity Framework CLI is not installed, install it with:

```bash
dotnet tool install --global dotnet-ef
```

If it is already installed, update it when necessary:

```bash
dotnet tool update --global dotnet-ef
```

To create a migration after changing the data model:

```bash
dotnet ef migrations add MigrationName --project Task_Management_Api
```

Replace `MigrationName` with a descriptive name for your change.

To apply migrations to the configured database:

```bash
dotnet ef database update --project Task_Management_Api
```

These commands must be run from the repository root with the appropriate database configuration available.

### Integration Test Database

The integration tests use an in-memory SQLite database through a custom `WebApplicationFactory` configuration.

This isolates the integration tests from the PostgreSQL database used by the running application.

Consequently, running the tests does not require the test suite to use the Docker PostgreSQL database.

## Running Tests

The project includes automated unit and integration tests.

From the repository root, run:

```bash
dotnet test
```

To build and run the tests with detailed output:

```bash
dotnet test --verbosity normal
```

The test suite covers areas including:

- Task service behavior.
- Task creation and validation.
- Retrieving and updating tasks.
- Exception-handling middleware.
- Authentication with valid credentials.
- Rejection of invalid credentials.
- User registration.
- Role-based authorization for task deletion.

The current recorded test result is **26 passing tests**, with zero failures. Run the test suite again to verify the result after making changes.

## Git Workflow

The project uses Git for version control and GitHub for remote source code hosting.

The main branches are:

- `main` — The main branch.
- `development` — The development branch used for ongoing implementation.

### Check the Current Branch

```bash
git branch
```

### Switch to the Development Branch

```bash
git switch development
```

### Check Working Tree Status

```bash
git status
```

### Stage Changes

```bash
git add .
```

Review staged changes before committing, especially to ensure that no secrets or local configuration files are included.

### Commit Changes

```bash
git commit -m "Describe your changes"
```

### Push Development Changes

```bash
git push origin development
```

Use descriptive commit messages that explain the changes being introduced.

## Security Notes

- Never commit `.env` files containing passwords or other secrets.
- Do not hardcode database credentials or administrator passwords.
- Store passwords using an appropriate password-hashing algorithm; this application uses BCrypt.
- Basic Authentication encodes credentials using Base64, which is **not encryption**.
- Use HTTPS when sending Basic Authentication credentials outside a trusted local development environment.
- Apply role-based authorization on the server, not only in the client.
- Validate incoming data before persisting it.
- Use separate credentials and configuration for development and production.
- Restrict access to production database credentials and infrastructure.

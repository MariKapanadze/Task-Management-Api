using Task_Management_Api.DTOs;
using Task_Management_Api.Models;
using Task_Management_Api.Repositories;

namespace Task_Management_Api.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _repository;

        public TaskService(ITaskRepository repository)
        {
            _repository = repository;
        }

        public List<TaskResponse> GetAll()
        {
            return _repository.GetAll()
                .Select(MapToResponse)
                .ToList();
        }

        public TaskResponse? GetById(int id)
        {
            var task = _repository.GetById(id);

            return task == null ? null : MapToResponse(task);
        }

        public TaskResponse Create(CreateTaskRequest request)
        {
            ValidateTitle(request.Title);
            ValidateAssignee(request.Assignee);
            ValidateDueDate(request.DueDate);

            var task = new TaskItem
            {
                Title = request.Title.Trim(),
                Description = request.Description,
                Assignee = request.Assignee,
                DueDate = request.DueDate,
                Status = Task_Management_Api.Models.TaskStatus.TO_DO
            };

            _repository.Add(task);

            return MapToResponse(task);
        }

        public TaskResponse? Update(int id, UpdateTaskRequest request)
        {
            var task = _repository.GetById(id);

            if (task == null)
            {
                return null;
            }

            ValidateTitle(request.Title);
            ValidateAssignee(request.Assignee);
            ValidateDueDate(request.DueDate);
            ValidateStatus(request.Status);

            task.Title = request.Title.Trim();
            task.Description = request.Description;
            task.Assignee = request.Assignee;
            task.DueDate = request.DueDate;
            task.Status = request.Status;

            _repository.Update(task);

            return MapToResponse(task);
        }

        public bool UpdateStatus(
            int id,
            UpdateTaskStatusRequest request)
        {
            var task = _repository.GetById(id);

            if (task == null)
            {
                return false;
            }

            ValidateStatus(request.Status);

            task.Status = request.Status;

            _repository.Update(task);

            return true;
        }

        public bool Delete(int id)
        {
            var task = _repository.GetById(id);

            if (task == null)
            {
                return false;
            }

            _repository.Delete(task);

            return true;
        }


        private static void ValidateTitle(string title)
        {
            if (string.IsNullOrWhiteSpace(title) ||
                title.Trim().Length < 3)
            {
                throw new ArgumentException(
                    "Title is required and must be at least 3 characters long.");
            }
        }

        private static void ValidateAssignee(string assignee)
        {
            if (string.IsNullOrWhiteSpace(assignee))
            {
                throw new ArgumentException(
                    "Assignee is required.");
            }
        }

        private static void ValidateDueDate(DateTime? dueDate)
        {
            if (dueDate.HasValue &&
                dueDate.Value == DateTime.MinValue)
            {
                throw new ArgumentException(
                    "Due date must be a valid date.");
            }
        }


        private static void ValidateStatus(
            Task_Management_Api.Models.TaskStatus status)
        {
            if (!Enum.IsDefined(typeof(
                Task_Management_Api.Models.TaskStatus), status))
            {
                throw new ArgumentException("Invalid task status.");
            }
        }

        private static TaskResponse MapToResponse(TaskItem task)
        {
            return new TaskResponse
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
                Assignee = task.Assignee,
                DueDate = task.DueDate,
                Status = task.Status,
                CreatedAt = task.CreatedAt
            };
        }
    }
}


using Task_Management_Api.DTOs;

namespace Task_Management_Api.Services
{
    public interface ITaskService
    {
        List<TaskResponse> GetAll();

        TaskResponse? GetById(int id);

        TaskResponse Create(CreateTaskRequest request);

        TaskResponse? Update(int id, UpdateTaskRequest request);

        bool UpdateStatus(int id, UpdateTaskStatusRequest request);

        bool Delete(int id);
    }
}

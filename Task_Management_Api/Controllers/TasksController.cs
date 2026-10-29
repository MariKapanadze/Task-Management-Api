using Microsoft.AspNetCore.Mvc;
using Task_Management_Api.DTOs;
using Task_Management_Api.Services;
using Microsoft.AspNetCore.Authorization;

namespace Task_Management_Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class TasksController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TasksController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet]
        public ActionResult<List<TaskResponse>> GetAll(
            [FromQuery] Task_Management_Api.Models.TaskStatus? status = null,
            [FromQuery] string? assignee = null,
            [FromQuery] string? title = null)
        {
            var tasks = _taskService.GetAll(status, assignee, title);

            return Ok(tasks);
        }

        [HttpGet("{id:int}")]
        public ActionResult<TaskResponse> GetById(int id)
        {
            var task = _taskService.GetById(id);

            if (task == null)
            {
                return NotFound();
            }

            return Ok(task);
        }

        [HttpPost]
        public ActionResult<TaskResponse> Create(
            CreateTaskRequest request)
        {
            try
            {
                var task = _taskService.Create(request);

                return CreatedAtAction(
                    nameof(GetById),
                    new { id = task.Id },
                    task);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("{id:int}")]
        public ActionResult<TaskResponse> Update(
            int id,
            UpdateTaskRequest request)
        {
            try
            {
                var task = _taskService.Update(id, request);

                if (task == null)
                {
                    return NotFound();
                }

                return Ok(task);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPatch("{id:int}/status")]
        public IActionResult UpdateStatus(
            int id,
            UpdateTaskStatusRequest request)
        {
            try
            {
                var updated = _taskService.UpdateStatus(id, request);

                if (!updated)
                {
                    return NotFound();
                }

                return Ok(new { message = "Task status updated successfully." });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [Authorize(Roles = "ADMIN")]
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var deleted = _taskService.Delete(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}

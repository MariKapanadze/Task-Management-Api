using Microsoft.AspNetCore.Mvc;

namespace Task_Management_Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HealthController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new
            {
                status = "UP",
                application = "task-management-api"
            });
        }
    }
}

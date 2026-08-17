using Microsoft.AspNetCore.Mvc;
using TaskApi.Models;
using TaskApi.Services;

namespace TaskApi.Controllers.v2
{
    [ApiController]
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/TaskV2")]
    public class TaskV2Controller : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TaskV2Controller(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpPost]
        public ActionResult CreateTask(Tasks task)
        {
            return Ok(_taskService.CreateTask(task));
        }

        [HttpGet]
        public IActionResult GetAllTasks([FromQuery] TaskFilter param)
        {
            return Ok(_taskService.GetTasks(param));
        }
    }
}

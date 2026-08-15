using Microsoft.AspNetCore.Mvc;
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

        [HttpGet]
        public IActionResult GetAllTasks()
        {
            var tasks = _taskService.GetTasks();
            var result = tasks.Select(t => new
            {
                t.Id,
                t.Title,
                t.Status,
                t.DueDate,
                t.CreatedAt
            });
            return Ok(result);
        }
    }
}

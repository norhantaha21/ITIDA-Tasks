using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using TaskApi.Services;

namespace TaskApi.Controllers.v1
{
    [ApiController]
    [ApiVersion("1.0", Deprecated = true)]
    [Route("api/v{version:apiVersion}/TaskV1")]
    public class TaskV1Controller : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TaskV1Controller(ITaskService taskService)
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
                t.IsCompleted

            });
            return Ok(result);
        }
    }
}

using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using TaskApi.Models;
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

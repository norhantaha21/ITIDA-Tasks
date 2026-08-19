using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.Threading.Tasks;
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
        public async Task<ActionResult> CreateTask(Tasks task)
        {
            return Created($"/api/task/{task.Id}", await _taskService.CreateTask(task));
        }

        [HttpGet]
        public IActionResult GetAllTasks([FromQuery] TaskFilter param)
        {
            return Ok(_taskService.GetTasks(param));
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> GetTaskById(int id)
        {
            var data =await _taskService.GetById(id);
            return Ok(new
            {
                Id=data.Id,
                Title=data.Title,
                Description=data.Description,
                UserId=data.UserId,
                Name=data.User.Name

            });
        }
    }
}

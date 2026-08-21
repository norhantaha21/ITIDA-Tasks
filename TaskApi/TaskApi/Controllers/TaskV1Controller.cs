using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.Threading.Tasks;
using TaskApi.Dtos;
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

        [HttpGet]
        public ActionResult<PagedResult<TaskDto>> GetTasks([FromQuery] TaskFilter param)
        {
            var result = _taskService.GetTasks(param);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TaskDto>> GetById(int id)
        {
            var task = await _taskService.GetById(id);
            if (task == null) return NotFound();
            return Ok(task);
        }

        [HttpPost]
        public async Task<ActionResult<TaskDto>> CreateTask([FromBody] CreateTaskRequestDto request)
        {
            var created = await _taskService.CreateTask(request);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TaskDto>> UpdateTask(int id, [FromBody] UpdateTaskRequestDto request)
        {
            var updated = await _taskService.UpdateTask(id, request);
            if (updated == null) return NotFound();
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            var deleted = await _taskService.DeleteTask(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}

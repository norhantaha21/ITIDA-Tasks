using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskApi.Dtos;
using TaskApi.helpers;
using TaskApi.Models;
using TaskApi.Repositories;
using TaskApi.Services;

namespace TaskApi.Controllers.v2
{
    [ApiController]
    [ApiVersion("2.0")]
    [Authorize]
    [Route("api/v{version:apiVersion}/TaskV2")]
    public class TaskV2Controller : ControllerBase
    {
        private readonly ITaskService _taskService;
        private readonly ITaskRepository _taskRepository;
        private readonly IAuthorizationService _authz;

        public TaskV2Controller(ITaskService taskService, ITaskRepository taskRepository, IAuthorizationService authz)
        {
            _taskService = taskService;
            _taskRepository = taskRepository;
            _authz = authz;
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

        [HttpPut]
        [Route("{id}")]
        [Authorize(Policy = "CanManageTasks")]
        public async Task<ActionResult<TaskDto>> UpdateTask(int id, [FromBody] UpdateTaskRequestDto request)
        {
            var existingTask = await _taskRepository.GetById(id);
            if (existingTask == null) return NotFound();

            var result = await _authz.AuthorizeAsync(User, existingTask, Operations.Update);
            if (!result.Succeeded) return Forbid();

            var updated = await _taskService.UpdateTask(id, request);
            return Ok(updated);
        }

        [HttpDelete]
        [Route("{id}")]
        [Authorize(Policy = "CanManageTasks")]
        public async Task<ActionResult> DeleteTask(int id)
        {
            var existingTask = await _taskRepository.GetById(id);
            if (existingTask == null) return NotFound();

            var result = await _authz.AuthorizeAsync(User, existingTask, Operations.Delete);
            if (!result.Succeeded) return Forbid();

            await _taskService.DeleteTask(id);
            return NoContent();
        }
    }
}
using TaskApi.Dtos;
using TaskApi.Models;

namespace TaskApi.Services
{
    public interface ITaskService
    {
        public Task<TaskDto> CreateTask(CreateTaskRequestDto request);
        public PagedResult<TaskDto> GetTasks(TaskFilter param);
        public Task<TaskDto> GetById(int id);
        public Task<TaskDto> UpdateTask(int id, UpdateTaskRequestDto request);
        public Task<bool> DeleteTask(int id);
    }
}

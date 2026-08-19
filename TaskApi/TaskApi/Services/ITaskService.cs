using TaskApi.Models;

namespace TaskApi.Services
{
    public interface ITaskService
    {
        public Task<Tasks> CreateTask(Tasks task);
        public PagedResult<Tasks> GetTasks(TaskFilter param);
        public Task<Tasks> GetById(int id);
    }
}

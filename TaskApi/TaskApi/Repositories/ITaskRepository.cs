using TaskApi.Models;

namespace TaskApi.Repositories
{
    public interface ITaskRepository
    {
        public Task<Tasks> CreateTask(Tasks task);
        public PagedResult<Tasks> GetTasks(TaskFilter param);

        public Task<Tasks> GetById(int id);
    }
}

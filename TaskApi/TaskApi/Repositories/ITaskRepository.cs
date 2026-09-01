using TaskApi.Models;

namespace TaskApi.Repositories
{
    public interface ITaskRepository
    {
        public Task<Tasks> CreateTask(Tasks task);
        public PagedResult<Tasks> GetTasks(TaskFilter param);

        public Task<Tasks> GetById(int id);
        public Task<Tasks> UpdateTask(Tasks task);
        public Task<bool> DeleteTask(int id);
    }
}

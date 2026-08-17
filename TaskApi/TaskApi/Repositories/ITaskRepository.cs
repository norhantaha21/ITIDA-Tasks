using TaskApi.Models;

namespace TaskApi.Repositories
{
    public interface ITaskRepository
    {
        public Tasks CreateTask(Tasks task);
        public PagedResult<Tasks> GetTasks(TaskFilter param);
    }
}

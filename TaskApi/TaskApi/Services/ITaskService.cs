using TaskApi.Models;

namespace TaskApi.Services
{
    public interface ITaskService
    {
        public Tasks CreateTask(Tasks task);
        public PagedResult<Tasks> GetTasks(TaskFilter param);
    }
}

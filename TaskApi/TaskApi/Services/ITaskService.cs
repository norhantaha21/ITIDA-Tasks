using TaskApi.Models;

namespace TaskApi.Services
{
    public interface ITaskService
    {
        public IEnumerable<Tasks> GetTasks();
    }
}

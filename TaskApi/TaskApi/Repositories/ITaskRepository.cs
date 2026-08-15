using TaskApi.Models;

namespace TaskApi.Repositories
{
    public interface ITaskRepository
    {
        public IEnumerable<Tasks> GetTasks();
    }
}

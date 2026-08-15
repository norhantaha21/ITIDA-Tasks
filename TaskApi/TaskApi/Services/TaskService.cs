
using TaskApi.Models;
using TaskApi.Repositories;

namespace TaskApi.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;

        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public IEnumerable<Tasks> GetTasks()
        {
            return _taskRepository.GetTasks();
        }
    }
}

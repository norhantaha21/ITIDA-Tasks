
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

        public Tasks CreateTask(Tasks task)
        {
            return _taskRepository.CreateTask(task);
        }

        public PagedResult<Tasks> GetTasks(TaskFilter param)
        {
            return _taskRepository.GetTasks(param);
        }
    }
}

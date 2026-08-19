
using System.Threading.Tasks;
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

        public async Task<Tasks> CreateTask(Tasks task)
        {
            return await _taskRepository.CreateTask(task);
        }

        public async Task<Tasks> GetById(int id)
        {
            return await _taskRepository.GetById(id);
        }

        public PagedResult<Tasks> GetTasks(TaskFilter param)
        {
            return _taskRepository.GetTasks(param);
        }
    }
}

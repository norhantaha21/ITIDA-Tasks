
using AutoMapper;
using Azure.Core;
using System.Threading.Tasks;
using TaskApi.Dtos;
using TaskApi.Models;
using TaskApi.Repositories;

namespace TaskApi.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IMapper _mapper;

        public TaskService(ITaskRepository taskRepository , IMapper mapper)
        {
            _taskRepository = taskRepository;
            _mapper = mapper;
        }

        public async Task<TaskDto> CreateTask(CreateTaskRequestDto request)
        {
            var tasks=_mapper.Map<Tasks>(request);
            var created=await _taskRepository.CreateTask(tasks);
            return _mapper.Map<TaskDto>(created);

        }


        public async Task<TaskDto> GetById(int id)
        {
            var task=await _taskRepository.GetById(id);
            if (task == null) return null;
            return _mapper.Map<TaskDto>(task);
        }

        public PagedResult<TaskDto> GetTasks(TaskFilter param)
        {
            var result = _taskRepository.GetTasks(param);
            return new PagedResult<TaskDto>
            {
                Data = _mapper.Map<IEnumerable<TaskDto>>(result.Data),
                Page = result.Page,
                PageSize = result.PageSize,
                TotalCount = result.TotalCount
            };
        }

        public async Task<TaskDto> UpdateTask(int id, UpdateTaskRequestDto request)
        {
            var existingTask = await _taskRepository.GetById(id);
            if (existingTask == null) return null;

            _mapper.Map(request, existingTask);
            var updated = await _taskRepository.UpdateTask(existingTask);
            return _mapper.Map<TaskDto>(updated);
        }

        public async Task<bool> DeleteTask(int id)
        {
           return await _taskRepository.DeleteTask(id);
        }
    }
}

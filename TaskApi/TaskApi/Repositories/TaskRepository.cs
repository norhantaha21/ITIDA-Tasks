using TaskApi.Models;
namespace TaskApi.Repositories
{
    public class TaskRepository : ITaskRepository
    {
                private readonly List<Tasks> _tasks = new()
                    {
                        new Tasks
                        {
                            Id = 1,
                            Title = "Study API Versioning",
                            Status="pending",
                            IsCompleted = false
                        },
                        new Tasks
                        {
                            Id = 2,
                            Title = "Finish Assignment",
                            Status="pending",
                            IsCompleted = true
                        }
                    };


        IEnumerable<Tasks> ITaskRepository.GetTasks()
        {
            return _tasks;
        }
    }
}

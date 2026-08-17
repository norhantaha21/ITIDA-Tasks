using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.VisualBasic;
using System.Threading.Tasks;
using TaskApi.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace TaskApi.Repositories
{
    public class TaskRepository : ITaskRepository
    {
       private readonly List<Tasks> _tasks = new List<Tasks> ();

        public Tasks CreateTask(Tasks task)
        {
             _tasks.Add(task);
            return task;
        }

        public PagedResult<Tasks> GetTasks(TaskFilter param) 
        {
            IEnumerable<Tasks> tasks = _tasks;

            if (!string.IsNullOrEmpty(param.Search))
            {
                tasks=tasks.Where(p=>p.Title.Contains(param.Search, StringComparison.OrdinalIgnoreCase));
            }
            if (param.IsCompleted.HasValue)
            {
                tasks = tasks.Where(p => p.IsCompleted=param.IsCompleted.Value);
            }
            if (param.CreatedAfter.HasValue)
            {
                tasks=tasks.Where(p=>p.CreatedAt>=param.CreatedAfter.Value);
            }
            if (param.CreatesBefore.HasValue) { 
                tasks=tasks.Where(p=>p.CreatedAt<param.CreatesBefore.Value.AddDays(1));
            }


            var allowedSort = new Dictionary<string, Func<Tasks, object>>
            {
                ["Title"]= t=>t.Title,
                ["IsCompleted"]= t=>t.IsCompleted,
            };
            if(allowedSort.TryGetValue(
                param.SortBy?? "Title", out var KeySelector))
            {
                tasks = param.Order?.ToLower()== "desc"
                    ? tasks.OrderByDescending(KeySelector)
                    : tasks.OrderBy(KeySelector);
            }

            var totalCount = tasks.Count();


            tasks=tasks.Skip((param.Page-1 * param.PageSize))
            .Take(param.PageSize)
            .ToList();

            return new PagedResult<Tasks>
            {
                Data = tasks,
                Page = param.Page,
                PageSize = param.PageSize,
                TotalCount = _tasks.Count()
            };
        }
    }
}

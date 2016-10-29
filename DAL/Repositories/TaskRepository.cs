using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using Data;

namespace DAL.Repositories
{
    public class TaskRepository : BaseRepository<Task>, ITaskRepository
    {
        public IQueryable<Task> GetAllTasks()
        {
            return DataContext.Tasks.Where(t=>t.ParentTaskId == null).Include(t=>t.ChildTasks.Select(c => c.Activities)).Include(t=>t.ChildTasks.Select(c=>c.ChildTasks.Select(cc=>cc.Activities))).Include(t=>t.Activities);
        }

        public Task GetTaskById(int taskId)
        {
            return
                DataContext.Tasks.Include(t => t.ChildTasks.Select(c => c.Activities))
                    .FirstOrDefault(t => t.Id == taskId);
        }

        public TaskRepository(DataContext dataContext) : base(dataContext)
        {
        }
    }
}

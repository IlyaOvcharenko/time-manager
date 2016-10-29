using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data;

namespace DAL.Repositories
{
    public interface ITaskRepository : IBaseRepository<Task>
    {
        IQueryable<Task> GetAllTasks();

        Task GetTaskById(int taskId);
    }

    
}

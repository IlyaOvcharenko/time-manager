using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BL.Paging;
using Data;

namespace BL
{
    public interface ITaskService
    {
        EntityDataPage<Task> GetUsersTasksPage(int userId, int pageNumber, int pageSize);

        Task GetTaskById(int taskId, int userId);

        Task CreateTask(Task task);

        void Update(Task task, int userId);

        void Delete(int taskId, int userId);
    }
}

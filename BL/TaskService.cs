using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BL.Paging;
using Data;
using DAL.Repositories;

namespace BL
{
    public class TaskService : ITaskService
    {
        private ITaskRepository _taskRepository;

        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }
        public EntityDataPage<Task> GetUsersTasksPage(int userId, int pageNumber, int pageSize)
        {
            var list =
                _taskRepository.GetAllTasks()
                    .Where(t => t.UserId == userId)
                    .OrderBy(t => t.Priority)
                    .Skip(pageSize*pageNumber)
                    .Take(pageSize)
                    .ToList();
            return new EntityDataPage<Task>
            {
                EntityCount = list.Count,
                List = list,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }

        public Task GetTaskById(int taskId, int userId)
        {
            var task = _taskRepository.GetTaskById(taskId);
            return task != null && task.UserId == userId ? task : null;
        }

        public Task CreateTask(Task task)
        {
            return _taskRepository.Create(task);
        }

        public void Update(Task task, int userId)
        {
            var existTask = _taskRepository.GetTaskById(task.Id);
            if (existTask == null || existTask.UserId != userId)
                throw new Exception("Task not exist for user");
            _taskRepository.Update(task);
        }

        public void Delete(int taskId, int userId)
        {
            var existTask = _taskRepository.GetTaskById(taskId);
            if (existTask == null || existTask.UserId != userId)
                throw new Exception("Task not exist for user");

            _taskRepository.Delete(taskId);
        }
    }
}

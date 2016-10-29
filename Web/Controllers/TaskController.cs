using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BL;
using BL.Paging;
using Data;

namespace Web.Controllers
{
    public class TaskController : ApiController
    {
        private readonly ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        // GET: api/Task
        public EntityDataPage<Task> Get(int pageNumber, int pageSize,string searchText)
        {
            var page = _taskService.GetUsersTasksPage(1, pageNumber, pageSize);
            return page;
        }

        // GET: api/Task/5
        public Task Get(int id)
        {
            return _taskService.GetTaskById(id, 1);
        }

        // POST: api/Task
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Task/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Task/5
        public void Delete(int id)
        {
        }
    }
}

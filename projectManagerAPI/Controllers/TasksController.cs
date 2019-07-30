using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using BusinessLayer;
using DataAccessLayer;

namespace ProjectManagerAPI.Controllers
{
    public class TasksController : ApiController
    {
        private TaskBusiness taskBusiness = new TaskBusiness();

        // GET: api/Tasks
        public IQueryable<Task> GetTasks()
        {
            return taskBusiness.GetTasks();
        }

        // GET: api/Tasks/5
        [ResponseType(typeof(Task))]
        public IHttpActionResult GetTask(int id)
        {
            Task task = taskBusiness.GetTask(id);
            if (task == null)
            {
                return NotFound();
            }

            return Ok(task);
        }

        // PUT: api/Tasks/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTask(int id, Task task)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != task.TaskId)
            {
                return BadRequest();
            }
            try
            {
                taskBusiness.PutTask(task);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!taskBusiness.TaskExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        [ResponseType(typeof(void))]
        public IHttpActionResult PutEndTask(Task task)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            task.TaskStatus = "1";     

            try
            {
                taskBusiness.PutTask(task);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
            return StatusCode(HttpStatusCode.NoContent);
        }


        // POST: api/Tasks
        [ResponseType(typeof(Task))]
        public IHttpActionResult PostTask(Task task)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            taskBusiness.PostTask(task);          
            return CreatedAtRoute("DefaultApi", new { id = task.TaskId }, task);
        }

        // DELETE: api/Tasks/5
        [ResponseType(typeof(Task))]
        public IHttpActionResult DeleteTask(int id)
        {
            Task task = taskBusiness.GetTask(id);
            if (task == null)
            {
                return NotFound();
            }
            taskBusiness.DeleteTask(task);           
            return Ok(task);
        }

    }
}
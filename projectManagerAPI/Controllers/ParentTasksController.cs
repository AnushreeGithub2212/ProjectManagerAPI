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
    public class ParentTasksController : ApiController
    {
        private ParentTaskBusiness parentTaskBusiness = new ParentTaskBusiness();

        // GET: api/ParentTasks
        public IQueryable<ParentTask> GetParentTasks()
        {
            return parentTaskBusiness.GetParentTasks();
        }

        // GET: api/ParentTasks/5
        [ResponseType(typeof(ParentTask))]
        public IHttpActionResult GetParentTask(int id)
        {
            ParentTask parentTask = parentTaskBusiness.GetParentTask(id);
            if (parentTask == null)
            {
                return NotFound();
            }

            return Ok(parentTask);
        }

        // PUT: api/ParentTasks/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutParentTask(int id, ParentTask parentTask)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != parentTask.ParentId)
            {
                return BadRequest();
            }

            try
            {
                parentTaskBusiness.PutParentTask(parentTask);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!parentTaskBusiness.ParentTaskExists(id))
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

        // POST: api/ParentTasks
        [ResponseType(typeof(ParentTask))]
        public IHttpActionResult PostParentTask(ParentTask parentTask)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            parentTaskBusiness.PostParentTask(parentTask);
           
            return CreatedAtRoute("DefaultApi", new { id = parentTask.ParentId }, parentTask);
        }

        // DELETE: api/ParentTasks/5
        [ResponseType(typeof(ParentTask))]
        public IHttpActionResult DeleteParentTask(int id)
        {
            ParentTask parentTask = parentTaskBusiness.GetParentTask(id);
            if (parentTask == null)
            {
                return NotFound();
            }
             parentTaskBusiness.DeleteParentTask(parentTask);
            return Ok(parentTask);
        }

    
    }

}
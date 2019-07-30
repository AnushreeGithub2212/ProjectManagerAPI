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
    public class ProjectsController : ApiController
    {
        private ProjectBusiness projectBusiness = new ProjectBusiness();

        // GET: api/Projects
        public IQueryable<Project> GetProjects()
        {
            return projectBusiness.GetProjects();
        }

        // GET: api/Projects/5
        [ResponseType(typeof(Project))]
        public IHttpActionResult GetProject(int id)
        {
            Project project = projectBusiness.GetProject(id);
            if (project == null)
            {
                return NotFound();
            }

            return Ok(project);
        }

        // PUT: api/Projects/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProject(int id, Project project)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != project.ProjectId)
            {
                return BadRequest();
            }
         
            try
            {
                projectBusiness.PutProject(project);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!projectBusiness.ProjectExists(id))
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

        // POST: api/Projects
        [ResponseType(typeof(Project))]
        public IHttpActionResult PostProject(Project project)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            projectBusiness.PostProject(project);
           
            return CreatedAtRoute("DefaultApi", new { id = project.ProjectId }, project);
        }

        // DELETE: api/Projects/5
        [ResponseType(typeof(Project))]
        public IHttpActionResult DeleteProject(int id)
        {
            Project project = projectBusiness.GetProject(id);
            if (project == null)
            {
                return NotFound();
            }
            projectBusiness.DeleteProject(project);
            return Ok(project);
        }

        
    }
}
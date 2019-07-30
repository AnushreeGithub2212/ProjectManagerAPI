using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class ProjectBusiness
    {
        private FSEfinalAssingmentProManagerEntities db = new FSEfinalAssingmentProManagerEntities();

        
        public IQueryable<Project> GetProjects()
        {
            return db.Projects;
        }

        public Project GetProject(int id)
        {
            Project project = db.Projects.Find(id);
            
            return project;
        }

    
        public void PutProject( Project project)
        {           
            db.Entry(project).State = EntityState.Modified;
            db.SaveChanges();           
        }

        public Project PostProject(Project project)
        {           
            db.Projects.Add(project);
            db.SaveChanges();

            return project;
        }

        public Project DeleteProject(Project project)
        {
            
           
            db.Projects.Remove(project);
            db.SaveChanges();
            return project;
        }
       
        public bool ProjectExists(int id)
        {
            return db.Projects.Count(e => e.ProjectId == id) > 0;
        }
    }
}

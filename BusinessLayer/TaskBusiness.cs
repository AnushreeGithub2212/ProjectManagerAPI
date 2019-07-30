using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;


namespace BusinessLayer
{
    public class TaskBusiness
    {
        private FSEfinalAssingmentProManagerEntities db = new FSEfinalAssingmentProManagerEntities();

        public IQueryable<Task> GetTasks()
        {
            return db.Tasks;
        }

        
        public Task GetTask(int id)
        {
            Task task = db.Tasks.Find(id);

            return task;
        }

    
        public void PutTask(Task task)
        {          
            db.Entry(task).State = EntityState.Modified;
            db.SaveChanges();
         
        }


        public Task PostTask(Task task)
        {
            db.Tasks.Add(task);
            db.SaveChanges();

            return task;
        }

        public Task DeleteTask(Task task)
        {                    
            db.Tasks.Remove(task);
            db.SaveChanges();
            return task;
        }

     

        public bool TaskExists(int id)
        {
            return db.Tasks.Count(e => e.TaskId == id) > 0;
        }
    }
}

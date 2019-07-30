using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class ParentTaskBusiness
    {

        private FSEfinalAssingmentProManagerEntities db = new FSEfinalAssingmentProManagerEntities();

        public IQueryable<ParentTask> GetParentTasks()
        {
            return db.ParentTasks;
        }
       
        public ParentTask GetParentTask(int id)
        {
            ParentTask parentTask = db.ParentTasks.Find(id);
           
            return parentTask;
        }
     
        public void PutParentTask(ParentTask parentTask)
        {          
            db.Entry(parentTask).State = EntityState.Modified;
            db.SaveChanges();          
        }

        public ParentTask PostParentTask(ParentTask parentTask)
        {
          
            db.ParentTasks.Add(parentTask);
            db.SaveChanges();

            return parentTask;
        }

        public ParentTask DeleteParentTask(ParentTask parentTask)
        {
          
           
            db.ParentTasks.Remove(parentTask);
            db.SaveChanges();

            return parentTask;
        }



        public bool ParentTaskExists(int id)
        {
            return db.ParentTasks.Count(e => e.ParentId == id) > 0;
        }
    }
}

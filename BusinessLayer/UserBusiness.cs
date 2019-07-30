using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class UserBusiness
    {

        private FSEfinalAssingmentProManagerEntities db = new FSEfinalAssingmentProManagerEntities();

    
        public IQueryable<User> GetUsers()
        {
            return db.Users;
        }

        public User GetUser(int id)
        {
            User user = db.Users.Find(id);           
            return user;
        }

       
        public void PutUser(User user)
        {
            
            db.Entry(user).State = EntityState.Modified;
            db.SaveChanges();
            

        }

        public User PostUser(User user)
        {
          
            db.Users.Add(user);
            db.SaveChanges();

            return user;
        }

     
        public User DeleteUser(User user)
        {                   
            db.Users.Remove(user);
            db.SaveChanges();
            return user;
        }

        public bool UserExists(int id)
        {
            return db.Users.Count(e => e.UserId == id) > 0;
        }
    }
}

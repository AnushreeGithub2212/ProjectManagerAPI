using System;
using BusinessLayer;
using DataAccessLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProjectManagerAPI.Tests
{
    [TestClass]
    public class ProjectManagerAPItest
    {
      
        [TestMethod]
        public void GetUserTest()
        {    //Arrange
            UserBusiness userBusiness = new UserBusiness();       
            //Act         
            User user = userBusiness.GetUser(1);
            //Assert
            if(user!=null)
            Assert.AreEqual(1,user.UserId);
            else
                Assert.IsNotNull(user);
        }
        [TestMethod]
        public void PostUserTest()
        {    //Arrange
            UserBusiness userBusiness = new UserBusiness();
            User usObj = new User();
            usObj.UserId = 0;
            usObj.FirstName ="testUser";
            usObj.LastName = "lastName";
            usObj.EmpId = "emp001";
      
            //Act
            usObj= userBusiness.PostUser(usObj);
           
            //Assert
            Assert.AreNotEqual(0,usObj.UserId);
        }
        [TestMethod]
        public void GetParentTaskTest()
        {    //Arrange
            ParentTaskBusiness parentTaskBusiness = new ParentTaskBusiness();
            //Act         
            ParentTask parentTask = parentTaskBusiness.GetParentTask(2);
            //Assert
            if (parentTask != null)
                Assert.AreEqual(2, parentTask.ParentId);
            else
                Assert.IsNotNull(parentTask);
        }

        [TestMethod]
        public void PostParentTaskTest()
        {    //Arrange
            ParentTaskBusiness parentTaskBusiness = new ParentTaskBusiness();
            ParentTask parentTask = new ParentTask();
            parentTask.ParentTask1 = "Parent task test";
            //Act
            parentTaskBusiness.PostParentTask(parentTask);

            //Assert
            Assert.AreNotEqual(0, parentTask.ParentId);
        }

        [TestMethod]
        public void GetProjectTest()
        {    //Arrange
            ProjectBusiness projectBusiness = new ProjectBusiness();
            //Act                  
            Project project = projectBusiness.GetProject(4);
            //Assert
            if (project != null)
                Assert.AreEqual(4, project.ProjectId);
            else
                Assert.IsNotNull(project);
        }

        [TestMethod]
        public void GetTaskTest()
        {    //Arrange
            TaskBusiness taskBusiness = new TaskBusiness();
            //Act                  
            Task task = taskBusiness.GetTask(4);
            //Assert
            if (task != null)
                Assert.AreEqual(4, task.TaskId);
            else
                Assert.IsNotNull(task);
        }

    }
}

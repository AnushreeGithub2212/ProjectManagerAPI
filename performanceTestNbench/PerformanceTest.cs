using BusinessLayer;
using DataAccessLayer;
using NBench;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace PerformanceTestNbench
{
    public class PerformanceTest
    {

        private const string AddCounterName = "AddCounter";
        private Counter addCounter;


        private const int AcceptableMinAddThroughput = 20000;

        [PerfSetup]
        public void Setup(BenchmarkContext context)
        {
            addCounter = context.GetCounter(AddCounterName);

        }
        [PerfBenchmark(RunMode = RunMode.Throughput, TestMode = TestMode.Test)]
        [CounterThroughputAssertion(AddCounterName, MustBe.LessThan, AcceptableMinAddThroughput)]
        public void GetUsersThroughput_ThroughputMode(BenchmarkContext context)
        {
            UserBusiness userBusiness = new UserBusiness();                  
            List<User> user = userBusiness.GetUsers().ToList();
            addCounter.Increment();
        }
        [PerfBenchmark(RunMode = RunMode.Throughput, TestMode = TestMode.Test)]
        [CounterThroughputAssertion(AddCounterName, MustBe.LessThan, AcceptableMinAddThroughput)]
        public void GetParentTaskThroughput_ThroughputMode(BenchmarkContext context)
        {
            ParentTaskBusiness parentTaskBusiness = new ParentTaskBusiness();                     
            List<ParentTask> parentTask = parentTaskBusiness.GetParentTasks().ToList();
            addCounter.Increment();
        }
        [PerfBenchmark(RunMode = RunMode.Throughput, TestMode = TestMode.Test)]
        [CounterThroughputAssertion(AddCounterName, MustBe.LessThan, AcceptableMinAddThroughput)]
        public void GetProjectThroughput_ThroughputMode(BenchmarkContext context)
        {
            ProjectBusiness projectBusiness = new ProjectBusiness();
                       
            List<Project> project = projectBusiness.GetProjects().ToList();
            addCounter.Increment();
        }
        [PerfBenchmark(RunMode = RunMode.Throughput, TestMode = TestMode.Test)]
        [CounterThroughputAssertion(AddCounterName, MustBe.LessThan, AcceptableMinAddThroughput)]
        public void GetTasksThroughput_ThroughputMode(BenchmarkContext context)
        {
            TaskBusiness taskBusiness = new TaskBusiness();
                           
            List<Task> task = taskBusiness.GetTasks().ToList();
            addCounter.Increment();
        }

        [PerfCleanup]
        public void Cleanup(BenchmarkContext context)
        {
            //does nothing
        }
    }
}

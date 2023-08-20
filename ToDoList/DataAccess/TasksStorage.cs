using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Threading.Tasks;
using ToDoList.Models;

namespace ToDoList.DataAccess
{
    public class TasksStorage : ITaskStorage
    {
        public ApplicationContext DbContext { get; set; }
        public TasksStorage(ApplicationContext dbContext)
        {
            DbContext = dbContext;
        }

        public void CreateTask(ToDoTask task)
        {
            DbContext.Add(task);
            DbContext.SaveChanges();
        }
         
        public void DeleteTask(Guid taskId)
        {
            var task = DbContext.Tasks.FirstOrDefault(x => x.Id == taskId) 
                ?? throw new Exception($"Task with {taskId} ID was not found. ");

            DbContext.Remove(task);
        }

        public ToDoTask GetTask(Guid taskId)
        {
            var task = DbContext.Tasks.FirstOrDefault(x => x.Id == taskId)
                ?? throw new Exception($"Task with {taskId} ID was not found. ");
            return task;
        }

        public IEnumerable<ToDoTask> GetTasks()
        {
            return DbContext.Tasks;
        }

        public void UpdateTask(ToDoTask updateTask)
        {
           throw new NotImplementedException();
        }
    }
}

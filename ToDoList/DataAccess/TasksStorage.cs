using System.Threading.Tasks;

namespace ToDoList.DataAccess
{
    public class TasksStorage : ITaskStorage
    {

        private static List<ToDoTask> Tasks = new List<ToDoTask>();

        public void CreateTask(ToDoTask task)
        {
            Tasks.Add(task);
        }

        public void DeleteTask(Guid taskId)
        {
            var task = Tasks.FirstOrDefault(x => x.Id == taskId)
               ?? throw new Exception($"Task with {taskId} ID was not found. ");

            Tasks.Remove(task);
        }

        public ToDoTask GetTask(Guid taskId)
        {
            var task = Tasks.FirstOrDefault(x => x.Id == taskId)
                ?? throw new Exception($"Task with {taskId} ID was not found. ");
            return task;
        }

        public IEnumerable<ToDoTask> GetTasks()
        {
            return Tasks;
        }

        public void UpdateTask(ToDoTask updateTask)
        {
           throw new NotImplementedException();
        }
    }
}

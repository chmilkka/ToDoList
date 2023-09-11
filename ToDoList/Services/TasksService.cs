using System.Threading.Tasks;
using ToDoList.DataAccess;
using ToDoList.Models;

namespace ToDoList.Services
{
    public class TasksService : ITasksService
    {
        private readonly ITaskStorage _taskStorage;
        public TasksService(ITaskStorage taskStorage)
        {
            _taskStorage = taskStorage;
        }
        public void CreateTask(CreateModelRequest request)
        {
            var task = new ToDoTask
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Content = request.Content
            };
           _taskStorage.CreateTask(task);
        }

        public void DeleteTask(Guid taskId)
        {
           _taskStorage.DeleteTask(taskId);
        }

        public ToDoTask GetTask(Guid taskId)
        {
            return _taskStorage.GetTask(taskId);
        }

        public IEnumerable<ToDoTask> GetTasks()
        {
            return _taskStorage.GetTasks();
        }

        public void UpdateTask(ToDoTask updateTask)
        {
            var task = _taskStorage.GetTask(updateTask.Id);
            task.Name = updateTask.Name;
            task.Content = updateTask.Content;           
        }
    }
}

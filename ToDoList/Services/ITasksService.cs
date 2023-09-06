using ToDoList.Models;

namespace ToDoList.Services
{
    public interface ITasksService
    {
        IEnumerable<ToDoTask> GetTasks();
        ToDoTask GetTask(Guid taskId);
        void CreateTask(CreateModelRequest request);
        void UpdateTask(ToDoTask updateTask);
        void DeleteTask(Guid taskId);
    }
}
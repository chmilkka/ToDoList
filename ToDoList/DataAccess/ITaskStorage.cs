using ToDoList.Models;

namespace ToDoList.DataAccess
{
    public interface ITaskStorage
    {
        IEnumerable<ToDoTask> GetTasks();
        ToDoTask GetTask(Guid taskId);
        void CreateTask(ToDoTask task);
        void UpdateTask(ToDoTask updateTask);
        void DeleteTask(Guid taskId);
    }
}
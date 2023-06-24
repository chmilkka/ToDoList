namespace ToDoList.Services
{
    public interface ITasksService
    {
        IEnumerable<ToDoTask> GetTasks();
        ToDoTask GetTask(Guid taskId);
        void CreateTask(string name, string content);
        void UpdateTask(ToDoTask updateTask);
        void DeleteTask(Guid taskId);
    }
}
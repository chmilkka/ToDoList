using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ToDoList.Models
{
    public class ToDoTask
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public User User { get; set; }
        public Guid? UserId { get; set; }

    }
}

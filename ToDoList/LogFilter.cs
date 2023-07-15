using Microsoft.AspNetCore.Mvc.Filters;

namespace ToDoList
{
    public class LogFilter : Attribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine($"[filter] After {context.HttpContext.Request.Path}");
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine($"[filter] Before {context.HttpContext.Request.Path}");
        }
    }
}

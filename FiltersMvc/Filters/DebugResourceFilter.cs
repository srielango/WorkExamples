using Microsoft.AspNetCore.Mvc.Filters;

namespace FiltersMvc.Filters
{
    public class DebugResourceFilter : Attribute, IResourceFilter
    {
        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            Console.WriteLine($"[ResourceFilter] {context.ActionDescriptor.DisplayName} is executing...");
        }
        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            Console.WriteLine($"[ResourceFilter] {context.ActionDescriptor.DisplayName} is executed...");
        }
    }
}

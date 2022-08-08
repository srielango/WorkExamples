using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Text;

namespace FiltersMvc.Filters
{
    public class DebugActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine($"[ActionFilter] {context.ActionDescriptor.DisplayName} has executed...");
            var result = context.Result;
            //if(context.Result)
            base.OnActionExecuted(context);
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
            Console.WriteLine($"[ActionFilter] {context.ActionDescriptor.DisplayName} is executing...");
            //Console.WriteLine($"[ActionFilter] {await ReadBodyAsString(context.HttpContext.Response)}");
            //context.Result = new ContentResult() { Content = "Hello" };
            
        }


        //private async Task<string> ReadBodyAsString(HttpResponse response)
        //{
        //    var initialBody = response.Body; // Workaround

        //    try
        //    {
        //        //request.EnableRewind();

        //        using (StreamReader reader = new StreamReader(response.Body))
        //        {
        //            string text = await reader.ReadToEndAsync();
        //            return text;
        //        }
        //    }
        //    finally
        //    {
        //        // Workaround so MVC action will be able to read body as well
        //        response.Body = initialBody;
        //    }

        //    //return string.Empty;
        //}
    }

    

}

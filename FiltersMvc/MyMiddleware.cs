namespace FiltersMvc
{
    public class MyMiddleware
    {
        private readonly RequestDelegate _next;

        public MyMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            bool modifyResponse = true;
            Stream originBody = null;

            if (modifyResponse)
            {
                //uncomment this line only if you need to read context.Request.Body stream
                //context.Request.EnableRewind();

                originBody = ReplaceBody(context.Response);
            }

            await _next(context);

            if (modifyResponse)
            {
                //as we replaced the Response.Body with a MemoryStream instance before,
                //here we can read/write Response.Body
                //containing the data written by middlewares down the pipeline 

                //finally, write modified data to originBody and set it back as Response.Body value
                ReturnBody(context.Response, originBody);
            }
        }

        private Stream ReplaceBody(HttpResponse response)
        {
            var originBody = response.Body;
            response.Body = new MemoryStream();
            return originBody;
        }

        private void ReturnBody(HttpResponse response, Stream originBody)
        {
            response.Body.Seek(0, SeekOrigin.Begin);
            response.Body.CopyTo(originBody);
            response.Body = originBody;
        }

        //public async Task Invoke(HttpContext httpContext)
        //{
        //    var originBody = httpContext.Response.Body;
        //    try
        //    {
        //        var memStream = new MemoryStream();
        //        httpContext.Response.Body = memStream;

        //        await _next(httpContext).ConfigureAwait(false);

        //        memStream.Position = 0;
        //        var responseBody = new StreamReader(memStream).ReadToEnd();

        //        //Custom logic to modify response
        //        responseBody = responseBody.Replace("test", "hi", StringComparison.InvariantCultureIgnoreCase);

        //        var memoryStreamModified = new MemoryStream();
        //        var sw = new StreamWriter(memoryStreamModified);
        //        sw.Write(responseBody);
        //        sw.Flush();
        //        memoryStreamModified.Position = 0;

        //        await memoryStreamModified.CopyToAsync(originBody).ConfigureAwait(false);
        //    }
        //    finally
        //    {
        //        httpContext.Response.Body = originBody;
        //    }
        //}

        //public async Task InvokeAsync(HttpContext context)
        //{
        //    var requestReader = new StreamReader(context.Request.Body);

        //    var requestContent = await requestReader.ReadToEndAsync();
        //    Console.WriteLine($"Request Body: {requestContent}");

        //    //await _next(context);

        //    using (var ms = new MemoryStream())
        //    {
        //        context.Response.Body = ms;
        //        await _next(context);

        //        context.Response.Body.Position = 0;

        //        var responseReader = new StreamReader(context.Response.Body);

        //        var responseContent = responseReader.ReadToEnd();
        //        Console.WriteLine($"Response Body: {responseContent}");

        //        context.Response.Body.Position = 0;
        //    }
        //    //var responseReader = new StreamReader(context.Response.Body);
        //    //var responseContent = await responseReader.ReadToEndAsync();
        //    //Console.WriteLine($"Response Body: {responseContent}");
        //}
    }
}

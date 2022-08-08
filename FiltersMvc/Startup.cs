
namespace FiltersMvc
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfigurationRoot configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {

        }

        public void Configure(IApplicationBuilder app)
        {
            app.Use(async (context, next) =>
            {
                var newContent = string.Empty;

                var existingBody = context.Response.Body;

                using (var newBody = new MemoryStream())
                {
                    // We set the response body to our stream so we can read after the chain of middlewares have been called.
                    //context.Response.Body = newBody;

                    await next();

                    // Reset the body so nothing from the latter middlewares goes to the output.
                    //context.Response.Body = new MemoryStream();
                    context.Response.Body = existingBody;

                    newBody.Seek(0, SeekOrigin.Begin);

                    // newContent will be `Hello`.
                    newContent = new StreamReader(newBody).ReadToEnd();

                    newContent += ", World!";

                    // Send our modified content to the response body.
                    await context.Response.WriteAsync(newContent);
                }
            });

            //app.Map("", configuration =>
            //{
            //    configuration.Use(async (context, next) =>
            //    {
            //        await context.Response.WriteAsync("Hello");
            //    });
            //});
        }
    }
}

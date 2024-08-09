using Library_Management_System.HandleErrors;
using System.Net;
using System.Text.Json;

namespace Library_Management_System.MiddleWare
{
    public class MiddleWareExceptions 
    {
        private readonly RequestDelegate next;
        private readonly ILogger<MiddleWareExceptions> logger;
        private readonly IHostEnvironment env;

        public MiddleWareExceptions(RequestDelegate next, ILogger<MiddleWareExceptions> logger, IHostEnvironment env)
        {
            this.next = next;
            this.logger = logger;
            this.env = env;
        }

        public async Task InvokeAsunc(HttpContext context)
        {
            try
            {
                await next.Invoke(context);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                var response = env.IsDevelopment()
                    ? new ApiExceptionError(ex.Message, ex.StackTrace, (int)HttpStatusCode.InternalServerError)
                    : new ApiExceptionError("Internal Server Error", ex.Message, (int)HttpStatusCode.InternalServerError);

                var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };

                var json = JsonSerializer.Serialize(response, options);

                await context.Response.WriteAsync(json);
            }

        }

    }
}

using System.Text.Json;

namespace backendWebAPI.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _req;
        public ExceptionMiddleware(RequestDelegate req)
        {
            _req = req; 
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {


                await _req(context);
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = 500;
                context.Response.ContentType = "application/json";
                var error = new { Message = ex.Message };
                await context.Response.WriteAsync(JsonSerializer.Serialize(error));
            }
        }
    }
}

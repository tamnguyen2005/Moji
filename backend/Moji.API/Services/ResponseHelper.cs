namespace Moji.API.Services
{
    public static class ResponseHelper
    {
        public static async Task HandleException(HttpContext context,int statusCode,string msg)
        {
            context.Response.StatusCode = statusCode;
            await context.Response.WriteAsync(msg);
        }
    }
}

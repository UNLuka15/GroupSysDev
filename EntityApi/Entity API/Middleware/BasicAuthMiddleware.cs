using System.Text;
using ConfigurationManager = System.Configuration.ConfigurationManager;

namespace EntityAPI
{
    public class BasicAuthMiddleware
    {
        private readonly RequestDelegate _next;

        public BasicAuthMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            string authHeader = httpContext.Request.Headers["Authorization"];

            if (authHeader != null && authHeader.StartsWith("Basic"))
            {
                var encodedAuth = authHeader.Substring("Basic ".Length).Trim();
                var usernamePasswordPair = Encoding.GetEncoding("UTF-8").GetString(Convert.FromBase64String(encodedAuth));

                var authList = usernamePasswordPair.Split(':');

                var expectedUsername = ConfigurationManager.AppSettings["Username"];
                var expectedPassword = ConfigurationManager.AppSettings["Password"];

                if (expectedUsername != null && expectedPassword != null)
                {
                    if (authList.Length > 1 && authList[0] == expectedUsername && authList[1] == expectedPassword)
                    {
                        await _next.Invoke(httpContext);
                    }
                }
                else 
                {
                    throw new ArgumentNullException("Username or password unavailable");
                }
            }

            httpContext.Response.StatusCode = 401;
            return;
        }
    }

    public static class BasicAuthMiddlewareExtensions
    {
        public static IApplicationBuilder UseBasicAuthMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<BasicAuthMiddleware>();
        }
    }
}

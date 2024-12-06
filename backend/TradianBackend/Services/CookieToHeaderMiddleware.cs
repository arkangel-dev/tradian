namespace TradianBackend.Services {
    public class CookieToHeaderMiddleware {
        private readonly RequestDelegate _next;

        public CookieToHeaderMiddleware(RequestDelegate next) {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context) {
            // Check if the "AuthToken" cookie exists
            var token = context.Request.Cookies["AuthToken"];
            if (!string.IsNullOrEmpty(token)) {
                // Add the token to the Authorization header
                context.Request.Headers["Authorization"] = $"Bearer {token}";
            }

            // Call the next middleware in the pipeline
            await _next(context);
        }
    }
}

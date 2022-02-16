namespace WebService.Middlewares
{
    internal class TestMiddleware
    {
        private readonly RequestDelegate _requestDelegate;

        public TestMiddleware(RequestDelegate requestDelegate)
        {
            _requestDelegate = requestDelegate;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            await _requestDelegate.Invoke(context);
        }
    }
}

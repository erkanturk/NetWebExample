using System.Diagnostics;

namespace _15_Middleware.Middleware
{
    public class RequestTimingMiddleware
    {
        private readonly RequestDelegate _next;
        public RequestTimingMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            var watch = Stopwatch.StartNew();//Zaman ölçümü başlatma.
            await _next(context);//Bir sonraki middleware e geç.
            watch.Stop();//Zaman ölçümünü durdur.
            var elapsed = watch.ElapsedMilliseconds;//geçen süreyi milisaniye cinsinden al.
            Debug.WriteLine($"istek yolu:{context.Request.Path} - işlem süresi:{elapsed}");
        }
    }
}

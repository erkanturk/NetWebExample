using _15_Middleware.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();



var app = builder.Build();
app.UseMiddleware<RequestTimingMiddleware>();
/* Middleware nedir ?
Middleware, .net Core uygulamalar�nda gelen istekleri (request) i�lemek ve yan�tlar� (response) olu�turmak i�in kullan�lan bir yaz�l�m bile�enidir.
Middleware'ler genellikle http isteklerini ve yan�tlar�n� i�lemmenin yan� s�ra uygulaman�n �e�itli i�levlerinide yerine getirir.
iste�i i�leyip bir sonraki middleware'e ge�ebilir yada yan�t� olu�turulabilir.

*/

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

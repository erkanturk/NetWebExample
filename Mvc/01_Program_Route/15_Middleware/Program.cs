using _15_Middleware.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();



var app = builder.Build();
app.UseMiddleware<RequestTimingMiddleware>();
/* Middleware nedir ?
Middleware, .net Core uygulamalarýnda gelen istekleri (request) iþlemek ve yanýtlarý (response) oluþturmak için kullanýlan bir yazýlým bileþenidir.
Middleware'ler genellikle http isteklerini ve yanýtlarýný iþlemmenin yaný sýra uygulamanýn çeþitli iþlevlerinide yerine getirir.
isteði iþleyip bir sonraki middleware'e geçebilir yada yanýtý oluþturulabilir.

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

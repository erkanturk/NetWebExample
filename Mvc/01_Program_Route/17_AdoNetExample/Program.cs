using _17_AdoNetExample.DbService.Abstract;
using _17_AdoNetExample.DbService.Concrete;

var builder = WebApplication.CreateBuilder(args);
// MICRO ORM ARA�LARI
// Object Relation Mapping

// Bir yaz�l�m projesinde data arama, filtreleme, ekle, silme, g�ncelleme gibi i�lemler i�in Yaz�l�m Dili ile SQL aras�nda ileti�im kurulmal�d�r. Bunu en kolay ve performansl� yapmak i�in frameworkler kullan�l�r.

/* EN POP�LER FRAMEWORKLER
 * Entity Framework(C# <-> MSSQL 631ms)
 * Dapper (C# <-> MSSQL 49ms)
 * Ado.Net (C# <-> MSSQL 47ms) 
 */
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IDbService, DbService>();
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

var app = builder.Build();

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

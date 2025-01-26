using _17_AdoNetExample.DbService.Abstract;
using _17_AdoNetExample.DbService.Concrete;

var builder = WebApplication.CreateBuilder(args);
// MICRO ORM ARAÇLARI
// Object Relation Mapping

// Bir yazýlým projesinde data arama, filtreleme, ekle, silme, güncelleme gibi iþlemler için Yazýlým Dili ile SQL arasýnda iletiþim kurulmalýdýr. Bunu en kolay ve performanslý yapmak için frameworkler kullanýlýr.

/* EN POPÜLER FRAMEWORKLER
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

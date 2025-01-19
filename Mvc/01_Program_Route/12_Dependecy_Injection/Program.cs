using _12_Dependecy_Injection.Services.Abstract;
using _12_Dependecy_Injection.Services.Concrete;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddControllersWithViews();
/* IMyService i ve MyService i container a ekliyoruz
.net core da dependency Injection da servislerin �mr�n� (lifecycle) belirlemek i�in �� ana y�ntem kullan�l�r AddTransient,
AddScoped,AddSingelton
1.AddTransient
Her istek i�in yeni bir nesn olu�turulur.yani her bir servis her kullan�ld���nda yeni bir instance olu�turulur.
Bu durum maliyetlidir.Performans a��s�ndan s�k�nt� yaratabilir
2.AddScoped
Her istek i�in yeni bir nesne olu�turur. Ayn� istek i�inde ayn� servis nesnesi kullan�l�r fakat farkl� isteklerde farkl� nesneler olu�turulur.
3.AddSingelton
Uygulama ba�lad���nda bir kez olu�turulan ve uygulama ya�am d�ng�s� boyunca ayn� kalan tek bir nesne olu�turulur ve kullan�l�r
performans a��s�ndan en verimlisidir. ��nk� nesne bir kez olu�turulur.

*/
builder.Services.AddTransient<IMyService, MyService>();
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

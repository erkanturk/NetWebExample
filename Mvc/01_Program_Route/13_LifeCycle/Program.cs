using _13_LifeCycle.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

/*
.net core da dependency Injection da servislerin ömrünü (lifecycle) belirlemek için üç ana yöntem kullanýlýr AddTransient,
AddScoped,AddSingelton
1.AddTransient
Her istek için yeni bir nesn oluþturulur.yani her bir servis her kullanýldýðýnda yeni bir instance oluþturulur.
Bu durum maliyetlidir.Performans açýsýndan sýkýntý yaratabilir
2.AddScoped
Her istek için yeni bir nesne oluþturur. Ayný istek içinde ayný servis nesnesi kullanýlýr fakat farklý isteklerde farklý nesneler oluþturulur.
3.AddSingelton
Uygulama baþladýðýnda bir kez oluþturulan ve uygulama yaþam döngüsü boyunca ayný kalan tek bir nesne oluþturulur ve kullanýlýr
performans açýsýndan en verimlisidir. Çünkü nesne bir kez oluþturulur.

*/
builder.Services.AddTransient<TransientRandomNumberService>();
builder.Services.AddScoped<ScopedRandomNumberService>();
builder.Services.AddScoped<ScopedHelperService>();
builder.Services.AddSingleton<SingletonRandomNumberService>();
builder.Services.AddControllersWithViews();
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

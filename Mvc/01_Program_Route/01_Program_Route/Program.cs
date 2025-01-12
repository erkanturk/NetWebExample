namespace _01_Program_Route
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // uygulamay� yap�land�rmak i�in kullan�lan bir nesne olu�umu
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            //MVC modelinde controller ve view deste�i eklenir.

            //aplication taraf�n�n mimar�n� Yap�land�r�r. Http isteklerini i�lemek i�in kullan�l�r.
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

            app.UseRouting();// Bu uygulama otomatik roter sistemi kullans�n

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.MapControllerRoute(
                name: "blogDetails",
                pattern: "blog/details/{id}",
                defaults: new { controller = "Blog", action = "Details" },
                constraints: new { id = @"\d+" }

                );
            app.MapControllerRoute(// Kendi �zel rotam�z� yazm�� olduk =>/Hakk�m�zda route u HomeControllerdaki about action result�n� �al��t�r�r.
                name: "about",
                pattern: "hakk�m�zda",
                defaults: new { controller = "Home", action = "About" }

                );
            //controller: hangi controller a y�nlendirece�ini belirtir
            //Action ilgili controller daki hangi Action metodunun �al��aca��n� belirtil
            //id opsiyonel bir parametre Url de bir id ge�ilebilir veya ge�ilmeyebilir.
            app.Run();//Uygulamay� ba�lat�r ve Http isteklerini dinlemeye ba�lar.
        }
    }
}

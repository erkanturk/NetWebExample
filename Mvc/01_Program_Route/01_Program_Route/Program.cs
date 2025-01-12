namespace _01_Program_Route
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // uygulamayý yapýlandýrmak için kullanýlan bir nesne oluþumu
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            //MVC modelinde controller ve view desteði eklenir.

            //aplication tarafýnýn mimarýný Yapýlandýrýr. Http isteklerini iþlemek için kullanýlýr.
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

            app.UseRouting();// Bu uygulama otomatik roter sistemi kullansýn

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
            app.MapControllerRoute(// Kendi özel rotamýzý yazmýþ olduk =>/Hakkýmýzda route u HomeControllerdaki about action resultýný çalýþtýrýr.
                name: "about",
                pattern: "hakkýmýzda",
                defaults: new { controller = "Home", action = "About" }

                );
            //controller: hangi controller a yönlendireceðini belirtir
            //Action ilgili controller daki hangi Action metodunun çalýþacaðýný belirtil
            //id opsiyonel bir parametre Url de bir id geçilebilir veya geçilmeyebilir.
            app.Run();//Uygulamayý baþlatýr ve Http isteklerini dinlemeye baþlar.
        }
    }
}

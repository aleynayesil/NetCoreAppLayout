using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreAppLayout
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {//uygulma fluenti desteklesin ve startup dosyas�n�n bulundu�u k�s�mda ne kadar validator s�n�f varsa projeye register et demek
            services.AddControllersWithViews().AddRazorRuntimeCompilation().AddFluentValidation(x=>x.RegisterValidatorsFromAssemblyContaining<Startup>());//mvc application
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();//wwwroot alt�ndaki dosyalar�n �al��mas�n� sa�lar.built-in net core taraf�ndan yaz�lm��
            app.UseRouting();

            app.UseEndpoints(endpoints =>//bu middleware uygulamaya gelen route isteklerinin farkl� uygulama templateleri i�in yaklanmas�n� sa�lar
            {
                endpoints.MapControllerRoute(//i�erisinde default y�nlendirme varsa kullan�r�z
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                //  endpoints.MapRazorPages();//uygulama razor web uygulamas� olarak a��lm��sa pages sayfalar�na y�nendriri.
                // endpoints.MapHub();chat uygulamalar� i�in kullan�l�r uygulama i�eisi nde signalr ile socket programlama varsa ilgili hup classa y�nlendirir.
                //endpoints.MapControllers();//default bir sayfa y�nlendirmesi yapmayacak isek mvc ve api uygulamalar�nda uygulaman�n controller y�nlenmesini sa�lar.
                // endpoints.MapBlazorHub();//blazor net core spa uygulamas�n�n sayfalar�na y�nlendirir
                //birka sayfadan olu�acak bir uygulama yazacaksak a�a��daki gbi bir route ayar� yapabiliriz.
                endpoints.MapGet("/home", async context =>//sadece slashl� olamaz home controller� engeller
                {
                    await context.Response.WriteAsync("<p>home page!</p>");
                });
                endpoints.MapGet("/about", async context =>
                {
                    await context.Response.WriteAsync("<h1><p>about page!</p></h1>");
                });
                ///endpoints.MapPost();//uygulamaya form �zerinden veri g�nderirken kullanaca��m�z routelar�n tan�mmlamas�n� yapabiliriz
            });
        }
    }
}

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
        {//uygulma fluenti desteklesin ve startup dosyasýnýn bulunduðu kýsýmda ne kadar validator sýnýf varsa projeye register et demek
            services.AddControllersWithViews().AddRazorRuntimeCompilation().AddFluentValidation(x=>x.RegisterValidatorsFromAssemblyContaining<Startup>());//mvc application
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();//wwwroot altýndaki dosyalarýn çalýþmasýný saðlar.built-in net core tarafýndan yazýlmýþ
            app.UseRouting();

            app.UseEndpoints(endpoints =>//bu middleware uygulamaya gelen route isteklerinin farklý uygulama templateleri için yaklanmasýný saðlar
            {
                endpoints.MapControllerRoute(//içerisinde default yönlendirme varsa kullanýrýz
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                //  endpoints.MapRazorPages();//uygulama razor web uygulamasý olarak açýlmýþsa pages sayfalarýna yönendriri.
                // endpoints.MapHub();chat uygulamalarý için kullanýlýr uygulama içeisi nde signalr ile socket programlama varsa ilgili hup classa yönlendirir.
                //endpoints.MapControllers();//default bir sayfa yönlendirmesi yapmayacak isek mvc ve api uygulamalarýnda uygulamanýn controller yönlenmesini saðlar.
                // endpoints.MapBlazorHub();//blazor net core spa uygulamasýnýn sayfalarýna yönlendirir
                //birka sayfadan oluþacak bir uygulama yazacaksak aþaðýdaki gbi bir route ayarý yapabiliriz.
                endpoints.MapGet("/home", async context =>//sadece slashlý olamaz home controllerý engeller
                {
                    await context.Response.WriteAsync("<p>home page!</p>");
                });
                endpoints.MapGet("/about", async context =>
                {
                    await context.Response.WriteAsync("<h1><p>about page!</p></h1>");
                });
                ///endpoints.MapPost();//uygulamaya form üzerinden veri gönderirken kullanacaðýmýz routelarýn tanýmmlamasýný yapabiliriz
            });
        }
    }
}

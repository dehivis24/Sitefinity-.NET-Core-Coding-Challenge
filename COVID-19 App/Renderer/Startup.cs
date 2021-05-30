using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Progress.Sitefinity.AspNetCore;
using Renderer.Models.Appointment;
using Renderer.Models.ContentBlockDisplay;
using Renderer.Models.VaccinationGallery;
using Renderer.Models.VaccinationGraph;
using Renderer.Models.VaccinationSiteDetail;
using Renderer.Models.VaccinationSiteSearch;

namespace Renderer
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMemoryCache();
            services.AddHttpClient();
            services.AddControllersWithViews();
            services.AddScoped<IContentBlockDisplayModel, ContentBlockDisplayModel>();
            services.AddScoped<IVaccinationGraphModel, VaccinationGraphModel>();
            services.AddScoped<IVaccinationGalleryModel, VaccinationGalleryModel>();
            services.AddScoped<IVaccinationAppointmentModel, VaccinationAppointmentModel>();
            services.AddScoped<IVaccinationSiteDetailModel, VaccinationSiteDetailModel>();
            services.AddScoped<IVaccinationSiteSearchModel, VaccinationSiteSearchModel>();
            services.AddSitefinity();
            services.AddViewComponentModels();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseRouting();
            app.UseSitefinity();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });

                endpoints.MapControllers();

                endpoints.MapControllerRoute(
                   name: "default",
                   pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapSitefinityEndpoints();
            });
        }
    }
}

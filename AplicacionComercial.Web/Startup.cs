using AplicacionComercial.Common.Entities;
using AplicacionComercial.Web.Data;
using AplicacionComercial.Web.FileManager;
using AplicacionComercial.Web.Helper;
using AplicacionComercial.Web.Helpers;
using AplicacionComercial.Web.Interfaces;
using AplicacionComercial.Web.Repository;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AplicacionComercial.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DataContext>(cfg =>
            {
                cfg.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });
            services.AddTransient<SeedDb>();
            services.AddTransient<ITipoDocumento, TipoDocumentoRepository>();
            services.AddTransient<IBodega, BodegaRepository>();
            services.AddTransient<IDepartamentoRepository, DepartamentoRepository>();
            services.AddTransient<IConcepto, ConceptoRepository>();
            services.AddTransient<IMedidaRepository, MedidaRepository>();
            services.AddTransient<IIvaRepository, IvaRepository>();
            services.AddTransient<IClienteRepository, ClienteRepository>();
            services.AddTransient<IPostRepository, PostRepository>();
            services.AddTransient<IFileManager, FilesManager>();
            services.AddTransient<ICommentRepository, SubCommentRepository>();
            services.AddTransient<IProductoRepository,ProductoRepository>();
            services.AddTransient<ICombosHelper, CombosHelper>();
            services.AddTransient<IConverterHelper, ConverterHelper>();
           services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}

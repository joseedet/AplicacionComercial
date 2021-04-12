using AplicacionComercial.Interfaces.ProcedimientosAl;
using AplicacionComercial.Web.Data;
using AplicacionComercial.Web.Data.Entities;
using AplicacionComercial.Web.FileManager;
using AplicacionComercial.Web.Helpers;
using AplicacionComercial.Web.Interfaces;
using AplicacionComercial.Web.Repository;
using AplicacionComercial.Web.Repository.ProcedimientoAlmacenados;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
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

            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddIdentity<User, IdentityRole>(cfg =>
            {
                cfg.User.RequireUniqueEmail = true;
                cfg.Password.RequireDigit = false;
                cfg.Password.RequiredUniqueChars = 0;
                cfg.Password.RequireLowercase = false;
                cfg.Password.RequireNonAlphanumeric = false;
                cfg.Password.RequireUppercase = false;
            }).AddEntityFrameworkStores<DataContext>();
            services.AddAuthorization();
            services.AddTransient<SeedDb>();
            services.AddScoped<ITipoDocumento, TipoDocumentoRepository>();
            services.AddScoped<IBodega, BodegaRepository>();
            services.AddScoped<IDepartamentoRepository, DepartamentoRepository>();
            services.AddScoped<IConcepto, ConceptoRepository>();
            services.AddScoped<IMedidaRepository, MedidaRepository>();
            services.AddScoped<IIvaRepository, IvaRepository>();
            //services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IPostRepository, PostRepository>();
            services.AddScoped<IFileManager, FilesManager>();
            services.AddScoped<ICommentRepository, SubCommentRepository>();
            services.AddScoped<IProductoRepository, ProductoRepository>();
            services.AddScoped<ICombosHelper, CombosHelper>();
            services.AddScoped<IConverterHelper, ConverterHelper>();
            services.AddScoped<IBodegaProductoRepository, BodegaProductoRepository>();
            services.AddScoped<IImagenProducto, IImagenProductoRepository>();
            services.AddScoped<IBodega, BodegaRepository>();
            services.AddScoped<IAlmacenProducto, AlmacenProductoPARepository>();
            services.AddScoped<IUserHelper, UserHelper>();

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

            app.UseAuthentication();
            app.UseRouting();
            //app.UseAuthorization( );
            app.UseStaticFiles();
            
            app.UseCookiePolicy();
           
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapControllers();
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}

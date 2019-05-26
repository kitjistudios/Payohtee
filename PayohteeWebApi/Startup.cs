using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PayohteeWebApp.Data;

namespace PayohteeWebApi
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
            //add service for the payohtee app db context
            //pass connection string from the appsettings.json file
            //this will be the end point repository that is pointed to
            //regardless of what the dll in the web project is set to
#if DEBUG
            services.AddDbContext<PayohteeDbContext>(options =>
                           options.UseSqlServer(
                               Configuration.GetConnectionString("StageConn")));
#else
 services.AddDbContext<PayohteeDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("StageConn")));
#endif


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}

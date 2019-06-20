using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Payohtee.Data;

[assembly: HostingStartup(typeof(Payohtee.Areas.Identity.IdentityHostingStartup))]
namespace Payohtee.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
#if DEBUG
            builder.ConfigureServices((context, services) =>
            {
                services.AddDbContext<ApplicationUserContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("LocalConn")));
            });
#else
   builder.ConfigureServices((context, services) => {
                services.AddDbContext<ApplicationUserContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("LocalConn")));
            });
#endif

        }


    }
}
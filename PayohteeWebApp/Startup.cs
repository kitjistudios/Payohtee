using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Payohtee.Areas.Identity;
using Payohtee.Data;
using PayohteeWebApp.Data;
using System;
using System.Threading.Tasks;
using static Payohtee.Areas.Identity.PayohteeApplicationUser;

namespace PayohteeWebApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        //This method creates the system roles
        private async Task CreateRoles(IServiceProvider serviceprovider)
        {
            //adding custom roles
            var rolemanager = serviceprovider.GetRequiredService<RoleManager<IdentityRole>>();
            var usermanager = serviceprovider.GetRequiredService<UserManager<IdentityUser>>();
            var roles = Enum.GetValues(typeof(PayohteeRoles));
            IdentityResult roleresult;

            foreach (var rolename in roles)
            {
                //creating the roles and seeding them to the database
                //roles are listed in the ApplicationUser class
                var roleexist = await rolemanager.RoleExistsAsync(rolename.ToString());
                if (!roleexist)
                {
                    roleresult = await rolemanager.CreateAsync(new IdentityRole(rolename.ToString()));
                }
            }

            //creating a super user who could maintain the web app
            var poweruser = new PayohteeApplicationUser
            {
                UserName = Configuration.GetSection("UserSettings")["UserEmail"],
                Email = Configuration.GetSection("UserSettings")["UserEmail"]
            };
            var userpassword = Configuration.GetSection("UserSettings")["UserPassword"];
            var username = Configuration.GetSection("UserSettings")["UserName"];
            var user = await usermanager.FindByEmailAsync(username.ToString());

            if (user == null)
            {
                var createpoweruser = await usermanager.CreateAsync(poweruser, userpassword);
                if (createpoweruser.Succeeded)
                {
                    await usermanager.AddToRoleAsync(poweruser, "Admin");
                }
            }
        }


        //This method assigns the system role to a user
        private async Task CreateUserRoles(IServiceProvider serviceProvider)
        {
            var rolemanager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var usermanager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();

            IdentityResult roleResult;
            //Adding Admin Role
            var roleCheck = await rolemanager.RoleExistsAsync("Admin");
            if (!roleCheck)
            {
                //create the roles and seed them to the database
                roleResult = await rolemanager.CreateAsync(new IdentityRole("Admin"));
            }
            var useremail = Configuration.GetSection("UserSettings")["UserEmail"];
            //Assign Admin role to the main User here we have given our newly registered 
            //login id for Admin management
            IdentityUser user = await usermanager.FindByEmailAsync(useremail.ToString());
            if (user != null)
            {
                await usermanager.AddToRoleAsync(user, "Admin");
            }
        }

        //This method gets called by the runtime.Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
#if DEBUG
            services.AddDbContext<ApplicationDbContext>(options =>
                        options.UseSqlServer(
                            Configuration.GetConnectionString("LocalConn")));
            //add service for the payohtee app db context
            //pass connection string from the appsettings.json file
            services.AddDbContext<PayohteeDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("LocalConn")));
#else
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("LocalConn")));
      //add service for the payohtee app db context
            //pass connection string from the appsettings.json file
            services.AddDbContext<PayohteeDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("LocalConn")));
#endif

            services.AddIdentity<IdentityUser, IdentityRole>(options => { })
                .AddEntityFrameworkStores<ApplicationUserContext>()
                .AddRoles<IdentityRole>();

            services.Configure<IdentityOptions>(options =>
            {
                // Password settings.
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 8;
                options.Password.RequiredUniqueChars = 1;

                // Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(20);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                // User settings.
                options.User.AllowedUserNameCharacters =
                    "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = true;


            });

            services.ConfigureApplicationCookie(options =>
            {
                // Cookie settings
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(5);

                options.LoginPath = "/Identity/Account/Login";
                options.AccessDeniedPath = "/Identity/Account/AccessDenied";
                options.SlidingExpiration = true;
            });

            services.AddMvc();
            services.AddEntityFrameworkSqlServer();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider serviceprovider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseCookiePolicy();
            app.UseAuthentication();
            app.UseMvc();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            CreateRoles(serviceprovider).Wait();
            CreateUserRoles(serviceprovider).Wait();
        }
    }
}

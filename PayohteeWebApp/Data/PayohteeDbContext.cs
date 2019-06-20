using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Payohtee.Models.Customer;
using Payohtee.Models.GeoTracking;
using Payohtee.Models.Personnel.Customs;
using Payohtee.Models.Settings.Rates.Customs;
using PayohteeWebApp.Models.Banking;
using PayohteeWebApp.Models.Banking.Customs;
using PayohteeWebApp.Models.Intents;
using PayohteeWebApp.Models.Settings.Roles.Customs;
using PayohteeWebApp.Properties;

namespace PayohteeWebApp.Data
{
    public class PayohteeDbContext : DbContext
    {
        public PayohteeDbContext(DbContextOptions<PayohteeDbContext> options) : base(options)
        {

        }

        public IConfiguration Configuration { get; set; }
        public DbSet<Company> DbContextCompany { get; set; }
        public DbSet<Contact> DbContextContacts { get; set; }
        public DbSet<GeoLocate> DbContextGeo { get; set; }
        public DbSet<CustomsOfficer> DbContextCustomsOfficer { get; set; }
        public DbSet<CustomsBankAccount> DbContextCustomsBankAccount { get; set; }
        public DbSet<CustomsRoles> DbContextCustomsRoles { get; set; }
        public DbSet<CustomsRates> DbContextCustomsRates { get; set; }
        public DbSet<Intent> DbContextIntent { get; set; }

        //public DbSet<PolicePayment> DbContextPolicePayments { get; set; }
        //public DbSet<CustomsPayment> DbContextCustomsPayments { get; set; }
        //public DbSet<CustomsOfficer> DbContextCustomsOfficers { get; set; }
        //public DbSet<PoliceOfficer> DbConextPoliceOfficers { get; set; }
        //public DbSet<Equipment> DbContextEquipment { get; set; }
        //public DbSet<Service> DbContextService { get; set; }
        //public DbSet<Event> DbContextEvent { get; set; }
 

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //use this string to target local environment
                //this is not working for asynch calls 
                var connlocal = Resources.connlocal;
                //use this string to target remote environment
                var connremote = Resources.connremote;
#if DEBUG
                optionsBuilder.UseSqlServer(connlocal,
                               provideroptions => provideroptions.CommandTimeout(60))
                           .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
#else
                optionsBuilder.UseSqlServer(connlocal,
                               provideroptions => provideroptions.CommandTimeout(60))
                           .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
#endif


            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //builder.Entity<PoliceOfficer>().ToTable("PoliceOfficer");
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }

    public class ConnectionStrings
    {
        public string PayohteeDbContextConnection { get; set; }

    }
}

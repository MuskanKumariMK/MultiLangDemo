using Microsoft.EntityFrameworkCore;
using MultiLangDemo.Models;

namespace MultiLangDemo.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<LocalizationResource> LocalizationResources { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<LocalizationResource>()
                .HasData(

                new LocalizationResource
                {
                    Id = 1,
                    Key = "Welcome",
                    Culture = "en",
                    Value =
                    "Welcome to Database Localization"
                },

                new LocalizationResource
                {
                    Id = 2,
                    Key = "Description",
                    Culture = "en",
                    Value =
                    "Dynamic translations loaded from database."
                },

                new LocalizationResource
                {
                    Id = 3,
                    Key = "Welcome",
                    Culture = "hi",
                    Value =
                    "डेटाबेस लोकलाइजेशन में आपका स्वागत है"
                },

                new LocalizationResource
                {
                    Id = 4,
                    Key = "Description",
                    Culture = "hi",
                    Value =
                    "डेटाबेस से डायनामिक ट्रांसलेशन लोड किए गए हैं।"
                });
        }
    }
}

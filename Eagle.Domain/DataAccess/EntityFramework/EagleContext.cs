using Eagle.Core.Settings;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Eagle.Domain.DataAccess.EntityFramework
{
    public class EagleContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(EagleSettings.Instance.DatabaseSetting.EagleDbConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

    }
}

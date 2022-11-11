using Microsoft.EntityFrameworkCore;
using System.IO;

namespace mainModules
{
    public class databaseContext : DbContext
    {
        string DBDirectory = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory,"db");


        public DbSet<databaseAPI.Models.Sale> Sales { get; set; }
        public DbSet<databaseAPI.Models.Stock> Stock { get; set; }
        public DbSet<databaseAPI.Models.Faculty> Faculty { get; set; }
        public DbSet<databaseAPI.Models.Settings> Settings { get; set; }
        public DbSet<databaseAPI.Models.SystemAudit> SystemAudit { get; set; }

        protected override void OnConfiguring(
            DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(
                $"Data Source={Path.Combine(DBDirectory, "debttracker.db")}");
            optionsBuilder.UseLazyLoadingProxies();
        }

    }
}

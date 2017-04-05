using HistoryData.Core.Models;
using HistoryData.Persistence.EntityConfigurations;
using System.Data.Entity;

namespace HistoryData.Persistence
{
    public partial class WeatherDbContext : DbContext
    {
        public WeatherDbContext()
            : base("name=WeatherHistory")
        {
        }

        public virtual DbSet<History> Histories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new HistoryConfiguration());
        }
    }
}

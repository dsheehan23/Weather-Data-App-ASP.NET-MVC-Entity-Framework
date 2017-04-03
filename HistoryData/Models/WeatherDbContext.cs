namespace HistoryData.Models
{
    using System.Data.Entity;

    public partial class WeatherDbContext : DbContext
    {
        public WeatherDbContext()
            : base("name=WeatherHistory")
        {
        }

        public virtual DbSet<History> Histories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<History>()
                .Property(e => e.DAY);
            //.IsUnicode(false);

            modelBuilder.Entity<History>()
                .Property(e => e.PRECIP);

            modelBuilder.Entity<History>()
                .Property(e => e.SNOW);

            modelBuilder.Entity<History>()
                .Property(e => e.SNOWDEPTH);

            modelBuilder.Entity<History>()
                .Property(e => e.TMAX);

            modelBuilder.Entity<History>()
                .Property(e => e.TMIN);

            modelBuilder.Entity<History>()
                .Property(e => e.TMEAN);
        }
    }
}

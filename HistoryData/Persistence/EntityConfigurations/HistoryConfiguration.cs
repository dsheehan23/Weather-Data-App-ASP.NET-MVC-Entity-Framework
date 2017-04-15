using HistoryData.Core.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;

namespace HistoryData.Persistence.EntityConfigurations
{
    public class HistoryConfiguration : EntityTypeConfiguration<History>
    {
        public HistoryConfiguration()
        {
            ToTable("History");

            HasKey(e => e.Id);
            Property(e => e.Id)
                .IsRequired();
                
            Property(e => e.DAY)
                .IsRequired()
                .HasColumnAnnotation(
                    "Index",
                    new IndexAnnotation
                    (
                        new IndexAttribute("Unique Day") { IsUnique = true })
                    );

            Property(e => e.PRECIP);

            
            Property(e => e.SNOW);

            
            Property(e => e.SNOWDEPTH);

           
            Property(e => e.TMAX);

            
            Property(e => e.TMIN);

            
            Property(e => e.TMEAN);
        }
        
        
    }
}
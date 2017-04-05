using HistoryData.Core.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace HistoryData.Persistence
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("WeatherHistory", throwIfV1Schema: false)
        {

        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
       
    }
}
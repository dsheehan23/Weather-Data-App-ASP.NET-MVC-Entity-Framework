using HistoryData.Models;
using HistoryData.Repositories;

namespace HistoryData.Persistence
{
    public class UnitOfWork
    {
        private readonly WeatherDbContext _context;
        public RecordRepository Records { get; private set; }

        public UnitOfWork(WeatherDbContext context)
        {
            _context = context;
            Records = new RecordRepository(context);
        }

        public void Complete()
        {
            _context.SaveChanges();
        }
    }
}
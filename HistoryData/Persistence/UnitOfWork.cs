using HistoryData.Core;
using HistoryData.Core.Models;
using HistoryData.Core.Repositories;
using HistoryData.Persistence.Repositories;

namespace HistoryData.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly WeatherDbContext _context;
        public IRecordRepository Records { get; private set; }

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
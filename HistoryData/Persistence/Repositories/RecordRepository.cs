using HistoryData.Core.Models;
using HistoryData.Core.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace HistoryData.Persistence.Repositories
{
    public class RecordRepository : IRecordRepository
    {
        private readonly WeatherDbContext _context;

        public RecordRepository(WeatherDbContext context)
        {
            _context = context;
        }

        public IEnumerable<History> GetHolidayData(int day, int month)
        {
            return _context.Histories
                          .Where(b => b.DAY.Day == day && b.DAY.Month == month)
                          .ToList();
        }

        public History GetSingleRecord(int id)
        {
            return _context.Histories.SingleOrDefault(g => g.Id == id);
        }

        public IEnumerable<History> GetAllHistory()
        {
            return _context.Histories.ToList();
        }

        public void Add(History history)
        {
            _context.Histories.Add(history);
        }

        public void Remove(History history)
        {
            _context.Histories.Remove(history);
        }
    }
}
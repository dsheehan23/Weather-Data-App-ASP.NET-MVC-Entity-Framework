using HistoryData.Core.Models;
using System.Collections.Generic;

namespace HistoryData.Core.Repositories
{
    public interface IRecordRepository
    {
        IEnumerable<History> GetHolidayData(int day, int month);
        History GetSingleRecord(int id);
        IEnumerable<History> GetAllHistory();
        void Add(History history);
        void Remove(History history);
    }
}
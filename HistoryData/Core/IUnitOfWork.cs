using HistoryData.Core.Repositories;

namespace HistoryData.Core
{
    public interface IUnitOfWork
    {
        IRecordRepository Records { get; }
        void Complete();
    }
}
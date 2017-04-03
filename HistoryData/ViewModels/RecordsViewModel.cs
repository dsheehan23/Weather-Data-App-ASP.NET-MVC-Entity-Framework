using HistoryData.Models;
using System.Collections.Generic;

namespace HistoryData.ViewModels
{
    public class RecordsViewModel
    {
        public IEnumerable<History> Records { get; set; }
        public string Heading { get; set; }

        public RecordsViewModel()
        {

        }

        public RecordsViewModel(IEnumerable<History> recs, string head)
        {
            Records = recs;
            Heading = head;
        }
    }
}
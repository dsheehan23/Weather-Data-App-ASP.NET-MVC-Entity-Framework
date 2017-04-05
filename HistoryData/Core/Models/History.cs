using HistoryData.Core.ViewModels;
using System;

namespace HistoryData.Core.Models
{
    public partial class History
    {
        public int Id { get; set; }
        
        public DateTime DAY { get; set; }

        public float PRECIP { get; set; }

        public float SNOW { get; set; }

        public int SNOWDEPTH { get; set; }

        public int TMAX { get; set; }

        public int TMIN { get; set; }

        public float TMEAN { get; set; }

        public History()
        {

        }

        public History(NewRecordViewModel viewModel)
        {
            DAY = viewModel.DAY;
            PRECIP = viewModel.PRECIP;
            SNOW = viewModel.SNOW;
            SNOWDEPTH = viewModel.SNOWDEPTH;
            TMAX = viewModel.TMAX;
            TMIN = viewModel.TMIN;
            TMEAN = viewModel.TMEAN;
        }

        public void Modify (NewRecordViewModel rec)
        {
            DAY = rec.DAY;
            PRECIP = rec.PRECIP;
            SNOW = rec.SNOW;
            SNOWDEPTH = rec.SNOWDEPTH;
            TMAX = rec.TMAX;
            TMIN = rec.TMIN;
            TMEAN = rec.TMEAN;
        }
    }
}

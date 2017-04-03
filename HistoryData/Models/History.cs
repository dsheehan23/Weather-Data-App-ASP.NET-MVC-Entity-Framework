namespace HistoryData.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using ViewModels;

    [Table("History")]
    public partial class History
    {
        [Key]
        public int Id { get; set; }
        
        [Index(IsUnique = true)]
        [Display(Name = "Day")]
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode=true, DataFormatString="{0:MM/dd/yyyy}")]
        public DateTime DAY { get; set; }

        [Display(Name = "Daily Precipitation")]
        public float PRECIP { get; set; }

        [Display(Name = "Daily Snow")]
        public float SNOW { get; set; }

        [Display(Name = "Snowdepth")]
        public int SNOWDEPTH { get; set; }

        [Display(Name = "Max Temperature")]
        public int TMAX { get; set; }

        [Display(Name = "Min Temperature")]
        public int TMIN { get; set; }

        [Display(Name = "Mean Temperature")]
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

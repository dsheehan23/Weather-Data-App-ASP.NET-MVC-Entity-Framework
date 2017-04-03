using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HistoryData.Dtos
{
    public class HistoryDto
    {
        [Key]
        public int Id { get; set; }

        [Index(IsUnique = true)]
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode=true, DataFormatString="{0:MM/dd/yyyy}")]
        public DateTime DAY { get; set; }

        public float PRECIP { get; set; }

        public float SNOW { get; set; }

        public int SNOWDEPTH { get; set; }

        public int TMAX { get; set; }

        public int TMIN { get; set; }

        public float TMEAN { get; set; }
    }
}
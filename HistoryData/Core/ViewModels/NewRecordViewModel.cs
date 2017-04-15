using HistoryData.Controllers;
using HistoryData.Core.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq.Expressions;
using System.Web.Mvc;

namespace HistoryData.Core.ViewModels
{
    public class NewRecordViewModel
    {
        public int Id { get; set; }

        [Index(IsUnique = true)]
        [Display(Name = "Day")]
        [Required]
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

        public string Heading { get; set; }

        public string Action
        {
            get
            {
                Expression<Func<HistoryController, ActionResult>> edit =
                    (c => c.Update(this));

                Expression<Func<HistoryController, ActionResult>> create =
                    (c => c.Save(this));

                var action = (Id != 0) ? edit : create;
                return (action.Body as MethodCallExpression).Method.Name;
            }
        }

        public NewRecordViewModel()
        {

        }

        public NewRecordViewModel(string head)
        {
            Id = 0;
            Heading = head;
        }

        public NewRecordViewModel(History rec, string head) 
        {
            Id = rec.Id;
            DAY = rec.DAY;
            PRECIP = rec.PRECIP;
            SNOW = rec.SNOW;
            SNOWDEPTH = rec.SNOWDEPTH;
            TMAX = rec.TMAX;
            TMIN = rec.TMIN;
            TMEAN = rec.TMEAN;
            Heading = head;
        }
    }

    
}
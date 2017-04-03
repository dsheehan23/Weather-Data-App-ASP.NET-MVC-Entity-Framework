using HistoryData.Models;
using System.Web.Mvc;

namespace HistoryData.Controllers
{
    public class HomeController : Controller
    {
        private WeatherDbContext _context;

        public HomeController()
        {
            _context = new WeatherDbContext();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ForeDiscuss()
        {
            return View();
        }

        public ActionResult SevenDay()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult About2()
        {
            return View();
        }

    }
}
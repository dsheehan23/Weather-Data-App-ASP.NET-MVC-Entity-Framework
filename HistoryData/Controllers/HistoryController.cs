using HistoryData.Models;
using HistoryData.Persistence;
using HistoryData.ViewModels;
using System.Web.Mvc;

namespace HistoryData.Controllers
{
    public class HistoryController : Controller
    {
        private readonly WeatherDbContext _context;
        private readonly UnitOfWork _unitOfWork;
        private readonly int cEve = 24;
        private readonly int cDay = 25;
        private readonly int nEve = 31;
        private readonly int nDay = 1;
        private readonly int dec = 12;
        private readonly int jan = 24;

        public HistoryController()
        {
            _context = new WeatherDbContext();
            _unitOfWork = new UnitOfWork(_context);
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Records()
        {
            if (User.IsInRole(RecordManageRole.CanManageRecords))
                return View("Records");
          
            return View("ReadOnlyRecords");
        }

        public ActionResult ChristmasEve()
        {
            var viewModel = new RecordsViewModel(_unitOfWork.Records.GetHolidayData(cEve, dec), "Christmas Eve Data");

            return View("HolidayData", viewModel);
        }

        public ActionResult ChristmasDay()
        {
            var viewModel = new RecordsViewModel(_unitOfWork.Records.GetHolidayData(cDay, dec), "Christmas Day Data");

            return View("HolidayData", viewModel);
        }

        public ActionResult NewYearsEve()
        {
            var viewModel = new RecordsViewModel(_unitOfWork.Records.GetHolidayData(nEve, dec), "New Years Eve Data");

            return View("HolidayData", viewModel);
        }

        public ActionResult NewYearsDay()
        {
            var viewModel = new RecordsViewModel(_unitOfWork.Records.GetHolidayData(nDay, jan), "New Years Day Data");

            return View("HolidayData", viewModel);
        }

        [Authorize(Roles = RecordManageRole.CanManageRecords)]
        public ActionResult Create()
        {
            var viewModel = new NewRecordViewModel("Add a Record");

            return View("RecordForm", viewModel);
        }

        [Authorize(Roles = RecordManageRole.CanManageRecords)]
        public ActionResult Edit(int id)
        {
            var record = _unitOfWork.Records.GetSingleRecord(id);

            if (record == null)
                return HttpNotFound();

            var viewModel = new NewRecordViewModel(record, "Edit a Record");

            return View("RecordForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RecordManageRole.CanManageRecords)]
        public ActionResult Update(NewRecordViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("New", viewModel);
            }

            var record = _unitOfWork.Records.GetSingleRecord(viewModel.Id);

            if (record == null)
                return HttpNotFound();

            record.Modify(viewModel);

            _unitOfWork.Complete();
            return RedirectToAction("Records", "History");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize (Roles = RecordManageRole.CanManageRecords)]
        public ActionResult Save(NewRecordViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("New", viewModel);
            }

            if (viewModel.Id == 0)
            {
                var history = new History(viewModel);

                _unitOfWork.Records.Add(history);
            }

            _unitOfWork.Complete();
            return RedirectToAction("Index", "Home");
        }
    }
}

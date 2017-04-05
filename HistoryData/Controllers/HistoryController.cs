using HistoryData.Core;
using HistoryData.Core.Models;
using HistoryData.Core.ViewModels;
using HistoryData.Persistence;
using System.Web.Mvc;

namespace HistoryData.Controllers
{
    public class HistoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private const int CEve = 24;
        private const int CDay = 25;
        private const int NEve = 31;
        private const int NDay = 1;
        private const int Dec = 12;
        private const int Jan = 1;

        public HistoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        protected override void Dispose(bool disposing)
        {
            new WeatherDbContext().Dispose();
        }

        public ActionResult Records()
        {
            if (User.IsInRole(RecordManageRole.CanManageRecords))
                return View("Records");
          
            return View("ReadOnlyRecords");
        }

        public ActionResult ChristmasEve()
        {
            var viewModel = new RecordsViewModel(_unitOfWork.Records.GetHolidayData(CEve, Dec), "Christmas Eve Data");

            return View("HolidayData", viewModel);
        }

        public ActionResult ChristmasDay()
        {
            var viewModel = new RecordsViewModel(_unitOfWork.Records.GetHolidayData(CDay, Dec), "Christmas Day Data");

            return View("HolidayData", viewModel);
        }

        public ActionResult NewYearsEve()
        {
            var viewModel = new RecordsViewModel(_unitOfWork.Records.GetHolidayData(NEve, Dec), "New Years Eve Data");

            return View("HolidayData", viewModel);
        }

        public ActionResult NewYearsDay()
        {
            var viewModel = new RecordsViewModel(_unitOfWork.Records.GetHolidayData(NDay, Jan), "New Years Day Data");

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
                return View("RecordForm", viewModel);
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
                return View("RecordForm", viewModel);
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

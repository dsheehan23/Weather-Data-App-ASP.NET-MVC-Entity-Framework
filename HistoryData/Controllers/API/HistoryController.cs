using AutoMapper;
using HistoryData.Dtos;
using HistoryData.Models;
using HistoryData.Persistence;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace HistoryData.Controllers.API
{
    public class HistoryController : ApiController
    {
        private readonly WeatherDbContext _context;
        private readonly UnitOfWork _unitOfWork;

        public HistoryController()
        {
            _context = new WeatherDbContext();
            _unitOfWork = new UnitOfWork(_context);
        }

        // GET /api/history
        public IEnumerable<HistoryDto> GetAllHistory()
        {
            return _unitOfWork.Records.GetAllHistory().Select(Mapper.Map<History, HistoryDto>);
        }

        // DELETE /api/history/1
        [HttpDelete]
        [Authorize(Roles = RecordManageRole.CanManageRecords)]
        public void DeleteHistory(int id)
        {
            var historyInDb = _unitOfWork.Records.GetSingleRecord(id);

            if (historyInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _unitOfWork.Records.Remove(historyInDb);
            _unitOfWork.Complete();
        }
    }
}


//// PUT /api/history/1
//[HttpPut]
//[Authorize(Roles = RecordManageRole.CanManageRecords)]
//public void UpdateHistory(DateTime day, HistoryDto historyDto)
//{
//    if (!ModelState.IsValid)
//        throw new HttpResponseException(HttpStatusCode.BadRequest);

//    var historyInDb = _context.Histories.SingleOrDefault(h => h.DAY == day);

//    if (historyInDb == null)
//        throw new HttpResponseException(HttpStatusCode.NotFound);

//    Mapper.Map(historyDto, historyInDb);

//    _context.SaveChanges();

//}

//// POST /api/history
//[HttpPost]
//[Authorize(Roles = RecordManageRole.CanManageRecords)]
//public IHttpActionResult CreateHistory(HistoryDto historyDto)
//{
//    if (!ModelState.IsValid)
//        return BadRequest();

//    var history = Mapper.Map<HistoryDto, History>(historyDto);
//    _context.Histories.Add(history);
//    _context.SaveChanges();

//    historyDto.Id = history.Id;

//    return Created(new Uri(Request.RequestUri + "/" + history.Id), historyDto);
//}

//// GET /api/history/1
//public IHttpActionResult GetSingleHistory(DateTime day)
//{
//    var history = _context.Histories.SingleOrDefault(h => h.DAY == day);

//    if (history == null)
//        throw new HttpResponseException(HttpStatusCode.NotFound);

//    return Ok(Mapper.Map<History, HistoryDto>(history));
//}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrackingSystemAPI.Models;
using TrackingSystemAPI.Repositories.RequestStatusRepositories;

namespace TrackingSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestStatusController : ControllerBase
    {
        private readonly IRequestStatusRepository _requestStatusRepository;

        public RequestStatusController(IRequestStatusRepository requestStatusRepository)
        {
            _requestStatusRepository = requestStatusRepository;
        }

        // GET: api/RequestStatus
        [HttpGet]
        public IEnumerable<RequestStatus> GetrequestStatuses()
        {
            return _requestStatusRepository.GetAll();
        }

        // GET: api/RequestStatus/5
        [HttpGet("{id}")]
        public ActionResult<RequestStatus> GetRequestStatus(int id)
        {
            var requestStatus = _requestStatusRepository.GetById(id);

            if (requestStatus == null)
            {
                return NotFound();
            }

            return requestStatus;
        }

        // PUT: api/RequestStatus/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public IActionResult PutRequestStatus(int id, RequestStatus requestStatus)
        {
            if (id != requestStatus.Id)
            {
                return BadRequest();
            }

            _requestStatusRepository.Update(requestStatus);

            try
            {
                _requestStatusRepository.Save();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                string msg = ex.Message;
            }

            return NoContent();
        }

        // POST: api/RequestStatus
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public ActionResult<RequestStatus> PostRequestStatus(RequestStatus requestStatus)
        {
            _requestStatusRepository.Add(requestStatus);
            _requestStatusRepository.Save();

            return CreatedAtAction("GetRequestStatus", new { id = requestStatus.Id }, requestStatus);
        }

        // DELETE: api/RequestStatus/5
        [HttpDelete("{id}")]
        public ActionResult<RequestStatus> DeleteRequestStatus(int id)
        {
            var requestStatus = _requestStatusRepository.Find(id);
            if (requestStatus == null)
            {
                return NotFound();
            }

            _requestStatusRepository.Delete(id);
            _requestStatusRepository.Save();

            return Ok();
        }
    }
}

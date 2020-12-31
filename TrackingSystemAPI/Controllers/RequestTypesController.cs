using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrackingSystemAPI.Repositories.RequestTypeRepositories;
using TrackingSystemAPI.Models;

namespace TrackingSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestTypesController : ControllerBase
    {
        private readonly IRequestTypeRepository _requestTypeRepository;

        public RequestTypesController(IRequestTypeRepository requestTypeRepository)
        {
            _requestTypeRepository = requestTypeRepository;
        }
        // GET: api/RequestTypes
        [HttpGet]
        public IEnumerable<RequestType> GetrequestTypes()
        {
            return _requestTypeRepository.GetAll();

        }

        // GET: api/RequestTypes/5
        [HttpGet("{id}")]
        public ActionResult<RequestType> GetRequestType(int id)
        {
            var requestType = _requestTypeRepository.GetById(id);

            if (requestType == null)
            {
                return NotFound();
            }

            return requestType;
        }

        // PUT: api/RequestTypes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRequestType(int id, RequestType requestType)
        {
            if (id != requestType.Id)
            {
                return BadRequest();
            }

            _requestTypeRepository.Update(requestType);

            try
            {
                _requestTypeRepository.Save();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                string msg = ex.Message;
            }

            return NoContent();
        }

        // POST: api/RequestTypes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public ActionResult<RequestType> PostRequestType(RequestType requestType)
        {
            _requestTypeRepository.Add(requestType);
            _requestTypeRepository.Save();
            return CreatedAtAction("GetRequestType", new { id = requestType.Id }, requestType);
        }

        // DELETE: api/RequestTypes/5
        [HttpDelete("{id}")]
        public ActionResult<RequestType> DeleteRequestType(int id)
        {
            var requestType = _requestTypeRepository.Find(id);
            if (requestType == null)
            {
                return NotFound();
            }

            _requestTypeRepository.Delete(id);
            _requestTypeRepository.Save();

            return requestType;
        }
    }
}

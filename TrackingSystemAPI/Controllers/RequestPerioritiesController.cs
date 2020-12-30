using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrackingSystemAPI.Models;
using TrackingSystemAPI.Repositories.RequestPeriorityRepositories;

namespace TrackingSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestPerioritiesController : ControllerBase
    {
        private readonly IRequestPeriorityRepository _requestPeriorityRepository;

        public RequestPerioritiesController(IRequestPeriorityRepository requestPeriorityRepository)
        {
            _requestPeriorityRepository = requestPeriorityRepository;
        }

        // GET: api/RequestPeriorities
        [HttpGet]
        public IEnumerable<RequestPeriority> GetrequestPeriorities()
        {
            return _requestPeriorityRepository.GetAll();
        }

        // GET: api/RequestPeriorities/5
        [HttpGet("{id}")]
        public ActionResult<RequestPeriority> GetRequestPeriority(int id)
        {
            var requestPeriority = _requestPeriorityRepository.GetById(id);

            if (requestPeriority == null)
            {
                return NotFound();
            }

            return requestPeriority;
        }

        // PUT: api/RequestPeriorities/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public IActionResult PutRequestPeriority(int id, RequestPeriority requestPeriority)
        {
            if (id != requestPeriority.Id)
            {
                return BadRequest();
            }

            _requestPeriorityRepository.Update(requestPeriority);

            try
            {
                _requestPeriorityRepository.Save();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                string msg = ex.Message;
            }

            return NoContent();
        }

        // POST: api/RequestPeriorities
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public ActionResult<RequestPeriority> PostRequestPeriority(RequestPeriority requestPeriority)
        {
            _requestPeriorityRepository.Add(requestPeriority);
            _requestPeriorityRepository.Save();

            return CreatedAtAction("GetRequestPeriority", new { id = requestPeriority.Id }, requestPeriority);
        }

        // DELETE: api/RequestPeriorities/5
        [HttpDelete("{id}")]
        public ActionResult<RequestPeriority> DeleteRequestPeriority(int id)
        {
            var requestPeriority = _requestPeriorityRepository.Find(id);
            if (requestPeriority == null)
            {
                return NotFound();
            }

            _requestPeriorityRepository.Delete(id);
            _requestPeriorityRepository.Save();

            return Ok();
        }
    }
}

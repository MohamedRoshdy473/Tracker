using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrackingSystemAPI.Models;
using TrackingSystemAPI.Repositories.RequestModeRepositories;

namespace TrackingSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestModesController : ControllerBase
    {
        private readonly IRequestModeRepository _requestModeRepository;
        public RequestModesController(IRequestModeRepository requestModeRepository)
        {
            _requestModeRepository = requestModeRepository;
        }

        // GET: api/RequestModes
        [HttpGet]
        public IEnumerable<RequestMode> GetrequestModes()
        {
            return _requestModeRepository.GetAll();
        }

        // GET: api/RequestModes/5
        [HttpGet("{id}")]
        public ActionResult<RequestMode> GetRequestMode(int id)
        {
            var requestMode = _requestModeRepository.GetById(id);

            if (requestMode == null)
            {
                return NotFound();
            }

            return requestMode;
        }

        // PUT: api/RequestModes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public IActionResult PutRequestMode(int id, RequestMode requestMode)
        {
            if (id != requestMode.Id)
            {
                return BadRequest();
            }

            _requestModeRepository.Update(requestMode);

            try
            {
                _requestModeRepository.Save();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                string msg = ex.Message;
            }

            return NoContent();
        }

        // POST: api/RequestModes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public ActionResult<RequestMode> PostRequestMode(RequestMode requestMode)
        {
            _requestModeRepository.Add(requestMode);
            _requestModeRepository.Save();

            return CreatedAtAction("GetRequestMode", new { id = requestMode.Id }, requestMode);
        }

        // DELETE: api/RequestModes/5
        [HttpDelete("{id}")]
        public ActionResult<RequestMode> DeleteRequestMode(int id)
        {
            var requestMode = _requestModeRepository.Find(id);
            if (requestMode == null)
            {
                return NotFound();
            }

            _requestModeRepository.Delete(id);
            _requestModeRepository.Save();

            return requestMode;
        }
    }
}

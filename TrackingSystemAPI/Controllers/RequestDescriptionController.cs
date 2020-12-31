using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrackingSystemAPI.DTO;
using TrackingSystemAPI.Models;
using TrackingSystemAPI.Repositories.RequestDescriptionRepositories;

namespace TrackingSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestDescriptionController : ControllerBase
    {
        private readonly IRequestDescriptionRepository _requestDescriptionRepository;

        public RequestDescriptionController(IRequestDescriptionRepository requestDescriptionRepository)
        {
            _requestDescriptionRepository = requestDescriptionRepository;
        }

        // GET: api/RequestDescription
        [HttpGet]
        public IEnumerable<RequestDescriptionDTO> GetRequestDescriptionDTO()
        {
            return _requestDescriptionRepository.GetAll();
        }

        // GET: api/RequestDescription/5
        [HttpGet("{id}")]
        public ActionResult<RequestDescriptionDTO> GetRequestDescriptionDTO(int id)
        {
            var requestDescriptionDTO = _requestDescriptionRepository.GetById(id);

            if (requestDescriptionDTO == null)
            {
                return NotFound();
            }

            return requestDescriptionDTO;
        }

        // PUT: api/RequestDescription/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public IActionResult PutRequestDescriptionDTO(int id, RequestDescriptionDTO requestDescriptionDTO)
        {
            if (id != requestDescriptionDTO.Id)
            {
                return BadRequest();
            }

            _requestDescriptionRepository.Update(requestDescriptionDTO);

            try
            {
                _requestDescriptionRepository.Save();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                string msg = ex.Message;
            }

            return NoContent();
        }

        // POST: api/RequestDescription
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public ActionResult<RequestDescriptionDTO> PostRequestDescriptionDTO(RequestDescriptionDTO requestDescriptionDTO)
        {
            _requestDescriptionRepository.Add(requestDescriptionDTO);
            _requestDescriptionRepository.Save();

            return CreatedAtAction("GetRequestDescriptionDTO", new { id = requestDescriptionDTO.Id }, requestDescriptionDTO);
        }

        // DELETE: api/RequestDescription/5
        [HttpDelete("{id}")]
        public ActionResult<RequestDescriptionDTO> DeleteRequestDescriptionDTO(int id)
        {
            var requestDescriptionDTO = _requestDescriptionRepository.Find(id);
            if (requestDescriptionDTO == null)
            {
                return NotFound();
            }

            _requestDescriptionRepository.Delete(id);
            _requestDescriptionRepository.Save();

            return Ok();
        }
    }
}

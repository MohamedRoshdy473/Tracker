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
        private readonly IRequestDescriptionRepository _requestDescriptionrepository;

        public RequestDescriptionController(IRequestDescriptionRepository requestDescriptionrepository)
        {
            _requestDescriptionrepository = requestDescriptionrepository;
        }

        // GET: api/RequestDescription
        [HttpGet]
        public IEnumerable<RequestDescriptionDTO> GetRequestDescriptionDTO()
        {
            return _requestDescriptionrepository.GetAll();
        }

        // GET: api/RequestDescription/5
        [HttpGet("{id}")]
        public ActionResult<RequestDescriptionDTO> GetRequestDescriptionDTO(int id)
        {
            var requestDescriptionDTO = _requestDescriptionrepository.GetById(id);

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

            _requestDescriptionrepository.Update(requestDescriptionDTO);

            try
            {
                _requestDescriptionrepository.Save();
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
            _requestDescriptionrepository.Add(requestDescriptionDTO);
            _requestDescriptionrepository.Save();

            return CreatedAtAction("GetRequestDescriptionDTO", new { id = requestDescriptionDTO.Id }, requestDescriptionDTO);
        }

        // DELETE: api/RequestDescription/5
        [HttpDelete("{id}")]
        public ActionResult<RequestDescription> DeleteRequestDescriptionDTO(int id)
        {
            var requestDescriptionDTO = _requestDescriptionrepository.Find(id);
            if (requestDescriptionDTO == null)
            {
                return NotFound();
            }

            _requestDescriptionrepository.Delete(id);
            _requestDescriptionrepository.Save();

            return Ok();
        }
    }
}

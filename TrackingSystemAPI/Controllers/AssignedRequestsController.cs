using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrackingSystemAPI.DTO;
using TrackingSystemAPI.Models;
using TrackingSystemAPI.Repositories.AssignedRequestsRepositories;
using TrackingSystemAPI.Repositories.RequestDescriptionRepositories;

namespace TrackingSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignedRequestsController : ControllerBase
    {
        private readonly IAssignedRequestsRepository _assignedRequestsRepository;
        private readonly IRequestDescriptionRepository _requestDescriptionRepository;

        public AssignedRequestsController(IAssignedRequestsRepository assignedRequestsRepository, IRequestDescriptionRepository requestDescriptionRepository)
        {
            _assignedRequestsRepository = assignedRequestsRepository;
            _requestDescriptionRepository = requestDescriptionRepository;
        }

        // GET: api/AssignedRequests
        [HttpGet]
        public IEnumerable<AssignedRequestsDTO> GetAssignedRequestsDTO()
        {
            return _assignedRequestsRepository.GetAll();
        }

        // GET: api/AssignedRequests/5
        [HttpGet("{id}")]
        public ActionResult<AssignedRequestsDTO> GetAssignedRequestsDTO(int id)
        {
            var assignedRequestsDTO = _assignedRequestsRepository.GetById(id);

            if (assignedRequestsDTO == null)
            {
                return NotFound();
            }

            return assignedRequestsDTO;
        }

        // PUT: api/AssignedRequests/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public IActionResult PutAssignedRequestsDTO(int id, AssignedRequestsDTO assignedRequestsDTO)
        {
            if (id != assignedRequestsDTO.Id)
            {
                return BadRequest();
            }

            _assignedRequestsRepository.Add(assignedRequestsDTO);

            try
            {
                _assignedRequestsRepository.Save();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                string msg = ex.Message;
            }

            return NoContent();
        }

        // POST: api/AssignedRequests
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public ActionResult<AssignedRequestsDTO> PostAssignedRequestsDTO(AssignedRequestsDTO assignedRequestsDTO)
        {
           _assignedRequestsRepository.Add(assignedRequestsDTO);
            _assignedRequestsRepository.Save();

            return CreatedAtAction("GetAssignedRequestsDTO", new { id = assignedRequestsDTO.Id }, assignedRequestsDTO);
        }

        // DELETE: api/AssignedRequests/5
        [HttpDelete("{id}")]
        public ActionResult<AssignedRequests> DeleteAssignedRequestsDTO(int id)
        {
            var assignedRequestsDTO = _assignedRequestsRepository.Find(id);
            if (assignedRequestsDTO == null)
            {
                return NotFound();
            }

            _assignedRequestsRepository.Delete(id);
            _assignedRequestsRepository.Save();

            return Ok();
        }
    }
}

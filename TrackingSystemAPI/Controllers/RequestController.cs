using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrackingSystemAPI.DTO;
using TrackingSystemAPI.Models;
using TrackingSystemAPI.Repositories.RequestRepositories;

namespace TrackingSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestController : ControllerBase
    {
        private readonly IRequestRepository _requestRepository;

        public RequestController(IRequestRepository requestRepository)
        {
            _requestRepository = requestRepository;
        }

        // GET: api/Request
        [HttpGet]
        public IEnumerable<RequestDTO> GetRequestDTO()
        {
            return _requestRepository.GetAll();
        }

        [HttpGet]
        [Route("GetAllRequestByClientId/{ClientId}")]
        public IEnumerable<RequestDTO> GetAllRequestByClientId(int ClientId)
        {
            return _requestRepository.GetAllRequestByClientId(ClientId);
        }
        [HttpPost]
        [Route("GetAllRequestByProjectTeamId")]
        public List<RequestDTO> GetAllRequestByProjectTeamId(ProjectTeamVM model)
        {
            return _requestRepository.GetAllRequestByProjectTeamId(model);
        }

        // GET: api/Request/5
        [HttpGet("{id}")]
        public ActionResult<RequestDTO> GetRequestDTO(int id)
        {
            var requestDTO = _requestRepository.GetById(id);

            if (requestDTO == null)
            {
                return NotFound();
            }

            return requestDTO;
        }

        // PUT: api/Request/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public IActionResult PutRequestDTO(int id, RequestDTO requestDTO)
        {
            if (id != requestDTO.Id)
            {
                return BadRequest();
            }

            _requestRepository.Update(requestDTO);

            try
            {
                _requestRepository.Save();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                string msg = ex.Message;
            }

            return NoContent();
        }

        // POST: api/Request
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public int PostRequestDTO(RequestDTO requestDTO)
        {
            return _requestRepository.Add(requestDTO);
            // _requestRepository.Save();
  
            //return CreatedAtAction("GetRequestDTO", new { id = requestDTO.Id }, requestDTO);
        }

        // DELETE: api/Request/5
        [HttpDelete("{id}")]
        public ActionResult<RequestDTO> DeleteRequestDTO(int id)
        {
            var requestDTO = _requestRepository.Find(id);
            if (requestDTO == null)
            {
                return NotFound();
            }

            _requestRepository.Delete(id);
            _requestRepository.Save();

            return Ok();
        }
        [HttpGet]
        [Route("GetAllRequestByRequestStatus/{requestStatusId}")]
        public List<RequestDTO> GetAllRequestByRequestStatus(int requestStatusId)
        {
            return _requestRepository.GetAllRequestByRequestStatus(requestStatusId);
        }
        [HttpGet]
        [Route("GetAllRequestByRequestStatusAndProjectTeamId/{requestStatusId}/{ProjectTeamId}")]
        public ActionResult<RequestDTO> GetAllRequestByRequestStatusAndProjectTeamId(int requestStatusId, int ProjectTeamId)
        {
            return _requestRepository.GetAllRequestByRequestStatusAndProjectTeamId(requestStatusId, ProjectTeamId);
        }



        [Route("CountProjects/{ProjectId}")]
        public int CountProjects(int ProjectId)
        {
            return _requestRepository.CountProjects(ProjectId);
        }

        [Route("CountInProgressProjects/{ProjectId}")]
        public int CountInProgressProjects(int ProjectId)
        {
            return _requestRepository.CountInProgressProjects(ProjectId);
        }

        [Route("CountOpenProjects/{ProjectId}")]
        public int CountOpenProjects(int ProjectId)
        {
            return _requestRepository.CountOpenProjects(ProjectId);
        }

        [Route("CountClosedProjects/{ProjectId}")]
        public int CountClosedProjects(int ProjectId)
        {
            return _requestRepository.CountClosedProjects(ProjectId);
        }
    }
}

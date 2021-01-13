using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrackingSystemAPI.DTO;
using TrackingSystemAPI.Models;
using TrackingSystemAPI.Repositories.RequestProblemsRepositories;

namespace TrackingSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestProblemsController : ControllerBase
    {
        private readonly IRequestProblemRepository _requestProblemRepository;

        public RequestProblemsController(IRequestProblemRepository requestProblemRepository)
        {
            _requestProblemRepository = requestProblemRepository;
        }

        // GET: api/RequestProblems
        [HttpGet]
        public IEnumerable<RequestProblemsDTO> GetRequestProblemsDTO()
        {
            return _requestProblemRepository.GetAll();
        }

        // GET: api/RequestProblems/5
        [HttpGet("{id}")]
        public ActionResult<RequestProblemsDTO> GetRequestProblemsDTO(int id)
        {
            var requestProblemsDTO = _requestProblemRepository.GetById(id);

            if (requestProblemsDTO == null)
            {
                return NotFound();
            }

            return requestProblemsDTO;
        }
        [HttpGet]
        [Route("GetProblemByEmployeeIdAndRequestId/{EmployeeId}/{RequestId}")]
        public RequestProblemsDTO GetProblemByEmployeeIdAndRequestId(int EmployeeId, int RequestId)
        {
            return _requestProblemRepository.GetProblemByEmployeeIdAndRequestId(EmployeeId, RequestId);
        }

        [HttpGet]
        [Route("GetAllRequestByProblemId/{ProblemId}")]
        public IEnumerable<RequestProblemsDTO> GetAllRequestByProblemId(int ProblemId)
        {
            return _requestProblemRepository.GetAllRequestByProblemId(ProblemId);
        }
        // PUT: api/RequestProblems/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public IActionResult PutRequestProblemsDTO(int id, RequestProblems requestProblems)
        {
            if (id != requestProblems.Id)
            {
                return BadRequest();
            }

            _requestProblemRepository.Update(requestProblems);

            try
            {
                _requestProblemRepository.Save();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                string msg = ex.Message;
            }

            return NoContent();
        }

        // POST: api/RequestProblems
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public ActionResult<RequestProblemsDTO> PostRequestProblemsDTO(RequestProblems requestProblems)
        {
            _requestProblemRepository.Add(requestProblems);
            _requestProblemRepository.Save();

            return CreatedAtAction("GetRequestProblemsDTO", new { id = requestProblems.Id }, requestProblems);
        }

        // DELETE: api/RequestProblems/5
        [HttpDelete("{id}")]
        public ActionResult<RequestProblems> DeleteRequestProblemsDTO(int id)
        {
            var requestProblemsDTO = _requestProblemRepository.Find(id);
            if (requestProblemsDTO == null)
            {
                return NotFound();
            }

            _requestProblemRepository.Delete(id);
            _requestProblemRepository.Save();

            return Ok();
        }
    }
}

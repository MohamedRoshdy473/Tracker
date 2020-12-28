using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrackingSystemAPI.DTO;
using TrackingSystemAPI.Models;
using TrackingSystemAPI.Repositories.RequestCategoryRepositories;

namespace TrackingSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestCategoryController : ControllerBase
    {
        private readonly IRequestCategoryRepository _requestCategoryRepository;

        public RequestCategoryController(IRequestCategoryRepository requestCategoryRepository)
        {
            _requestCategoryRepository = requestCategoryRepository;
        }

        // GET: api/RequestCategory
        [HttpGet]
        public IEnumerable<RequestCategoryDTO> GetRequestCategoryDTO()
        {
            return _requestCategoryRepository.GetAll();
        }

        // GET: api/RequestCategory/5
        [HttpGet("{id}")]
        public ActionResult<RequestCategoryDTO> GetRequestCategoryDTO(int id)
        {
            var requestCategoryDTO = _requestCategoryRepository.GetById(id);

            if (requestCategoryDTO == null)
            {
                return NotFound();
            }

            return requestCategoryDTO;
        }

        // PUT: api/RequestCategory/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public IActionResult PutRequestCategoryDTO(int id, RequestCategoryDTO requestCategoryDTO)
        {
            if (id != requestCategoryDTO.Id)
            {
                return BadRequest();
            }

            _requestCategoryRepository.Update(requestCategoryDTO);

            try
            {
                _requestCategoryRepository.Save();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                string msg = ex.Message;
            }

            return NoContent();
        }

        // POST: api/RequestCategory
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public ActionResult<RequestCategoryDTO> PostRequestCategoryDTO(RequestCategoryDTO requestCategoryDTO)
        {
            _requestCategoryRepository.Add(requestCategoryDTO);
            _requestCategoryRepository.Save();

            return CreatedAtAction("GetRequestCategoryDTO", new { id = requestCategoryDTO.Id }, requestCategoryDTO);
        }

        // DELETE: api/RequestCategory/5
        [HttpDelete("{id}")]
        public ActionResult<RequestCategoryDTO> DeleteRequestCategoryDTO(int id)
        {
            var requestCategoryDTO = _requestCategoryRepository.Find(id);
            if (requestCategoryDTO == null)
            {
                return NotFound();
            }

            _requestCategoryRepository.Delete(id);
            _requestCategoryRepository.Save();

            return Ok();
        }

        //private bool RequestCategoryDTOExists(int id)
        //{
        //    return _context.RequestCategoryDTO.Any(e => e.Id == id);
        //}
    }
}

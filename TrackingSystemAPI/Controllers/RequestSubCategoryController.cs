using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrackingSystemAPI.DTO;
using TrackingSystemAPI.Models;
using TrackingSystemAPI.Repositories.RequestSubCategoryRepositories;

namespace TrackingSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestSubCategoryController : ControllerBase
    {
        private readonly IRequestSubCategoryRepository _requestSubCategoryRepository;

        public RequestSubCategoryController(IRequestSubCategoryRepository requestSubCategoryRepository)
        {
            _requestSubCategoryRepository = requestSubCategoryRepository;
        }

        // GET: api/RequestSubCategory
        [HttpGet]
        public IEnumerable<RequestSubCategoryDTO> GetRequestSubCategoryDTO()
        {
            return _requestSubCategoryRepository.GetAll();
    }

        // GET: api/RequestSubCategory/5
        [HttpGet("{id}")]
        public ActionResult<RequestSubCategoryDTO> GetRequestSubCategoryDTO(int id)
        {
            var requestSubCategoryDTO = _requestSubCategoryRepository.GetById(id);

            if (requestSubCategoryDTO == null)
            {
                return NotFound();
            }

            return requestSubCategoryDTO;
        }

        // PUT: api/RequestSubCategory/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public IActionResult PutRequestSubCategoryDTO(int id, RequestSubCategoryDTO requestSubCategoryDTO)
        {
            if (id != requestSubCategoryDTO.Id)
            {
                return BadRequest();
            }

            _requestSubCategoryRepository.Update(requestSubCategoryDTO);

            try
            {
                _requestSubCategoryRepository.Save();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                string msg = ex.Message;
            }

            return NoContent();
        }

        // POST: api/RequestSubCategory
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public ActionResult<RequestSubCategoryDTO> PostRequestSubCategoryDTO(RequestSubCategoryDTO requestSubCategoryDTO)
        {
            _requestSubCategoryRepository.Add(requestSubCategoryDTO);
            _requestSubCategoryRepository.Save();

            return CreatedAtAction("GetRequestSubCategoryDTO", new { id = requestSubCategoryDTO.Id }, requestSubCategoryDTO);
        }

        // DELETE: api/RequestSubCategory/5
        [HttpDelete("{id}")]
        public ActionResult<RequestSubCategory> DeleteRequestSubCategoryDTO(int id)
        {
            var requestSubCategoryDTO = _requestSubCategoryRepository.Find(id);
            if (requestSubCategoryDTO == null)
            {
                return NotFound();
            }

            _requestSubCategoryRepository.Delete(id);
            _requestSubCategoryRepository.Save();

            return Ok();
        }

        //private bool RequestSubCategoryDTOExists(int id)
        //{
        //    return _context.RequestSubCategoryDTO.Any(e => e.Id == id);
        //}
    }
}

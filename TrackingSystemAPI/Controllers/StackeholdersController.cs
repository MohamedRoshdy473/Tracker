using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrackingSystemAPI.DTO;
using TrackingSystemAPI.Models;
using TrackingSystemAPI.Repositories.StackeholdersRepositories;

namespace TrackingSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StackeholdersController : ControllerBase
    {
        private readonly IStackeholdersRepository _stackeholdersRepository;
        public StackeholdersController(IStackeholdersRepository stackeholdersRepository)
        {
            _stackeholdersRepository = stackeholdersRepository;
        }

        // GET: api/Stackeholders
        [HttpGet]
        public IEnumerable<StackeholdersDTO> GetStackeholdersDTO()
        {
            return _stackeholdersRepository.GetAll();
        }
        [HttpGet]
        [Route("GetStackeholdersByProjectId/{ProjectId}")]
        public IEnumerable<StackeholdersDTO> GetStackeholdersByProjectId(int ProjectId)
        {
            return _stackeholdersRepository.GetStackeholdersByProjectId(ProjectId);
        }
        // GET: api/Stackeholders/50
        [HttpGet("{id}")]
        public ActionResult<StackeholdersDTO> GetStackeholdersDTO(int id)
        {
            var stackeholdersDTO = _stackeholdersRepository.GetById(id);

            if (stackeholdersDTO == null)
            {
                return NotFound();
            }

            return stackeholdersDTO;
        }

        // PUT: api/Stackeholders/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public IActionResult PutStackeholdersDTO(int id, StackeholdersDTO stackeholdersDTO)
        {
            if (id != stackeholdersDTO.Id)
            {
                return BadRequest();
            }

            _stackeholdersRepository.Update(stackeholdersDTO);

            try
            {
                _stackeholdersRepository.Save();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                string message = ex.Message;
            }

            return NoContent();
        }

        // POST: api/Stackeholders
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public ActionResult<StackeholdersDTO> PostStackeholdersDTO(List<StackeholdersDTO> stackeholdersDTO)
        {
            _stackeholdersRepository.Add(stackeholdersDTO);
            _stackeholdersRepository.Save();

            return CreatedAtAction("GetStackeholdersDTO", new { id = stackeholdersDTO.Count() }, stackeholdersDTO);
        }

        // DELETE: api/Stackeholders/5
        [HttpDelete("{id}")]
        public ActionResult<Stackeholders> DeleteStackeholdersDTO(int id)
        {
            var stackeholdersDTO = _stackeholdersRepository.Find(id);
            if (stackeholdersDTO == null)
            {
                return NotFound();
            }
            _stackeholdersRepository.Delete(id);
            _stackeholdersRepository.Save();

            return Ok();
        }

        //private bool StackeholdersDTOExists(int id)
        //{
        //    return _context.StackeholdersDTO.Any(e => e.Id == id);
        //}
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrackingSystemAPI.DTO;
using TrackingSystemAPI.Models;
using TrackingSystemAPI.Repositories.ProjectDocumentRepositories;

namespace TrackingSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectDocumentController : ControllerBase
    {
        private readonly IProjectDocumentRepository _projectDocumentRepository;

        public ProjectDocumentController(IProjectDocumentRepository projectDocumentRepository)
        {
            _projectDocumentRepository = projectDocumentRepository;
        }

        // GET: api/ProjectDocument
        [HttpGet]
        public  IEnumerable<ProjectDocumentDTO> GetProjectDocumentDTO()
        {
            return _projectDocumentRepository.GetAll();
        }

        // GET: api/ProjectDocument/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectDocumentDTO>> GetProjectDocumentDTO(int id)
        {
            var projectDocumentDTO = _projectDocumentRepository.GetById(id);
            if (projectDocumentDTO == null)
            {
                return NotFound();
            }
            return projectDocumentDTO;
        }

        // PUT: api/ProjectDocument/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProjectDocumentDTO(int id, ProjectDocumentDTO projectDocumentDTO)
        {
            if (id != projectDocumentDTO.Id)
            {
                return BadRequest();
            }

            _projectDocumentRepository.Update(projectDocumentDTO);

            try
            {
                _projectDocumentRepository.Save();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                string message = ex.Message;
            }

            return NoContent();
        }

        // POST: api/ProjectDocument
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ProjectDocumentDTO>> PostProjectDocumentDTO(ProjectDocumentDTO projectDocumentDTO)
        {
            _projectDocumentRepository.Add(projectDocumentDTO);
            _projectDocumentRepository.Save();

            return CreatedAtAction("GetProjectDocumentDTO", new { id = projectDocumentDTO.Id }, projectDocumentDTO);
        }

        // DELETE: api/ProjectDocument/5
        [HttpDelete("{id}")]
        public  ActionResult<ProjectDocument> DeleteProjectDocumentDTO(int id)
        {
            var projectDocumentDTO = _projectDocumentRepository.Find(id);
            if (projectDocumentDTO == null)
            {
                return NotFound();
            }

            
            _projectDocumentRepository.Delete(id);
            _projectDocumentRepository.Save();

            return Ok();
        }

       
    }
}

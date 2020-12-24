using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
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
        [HttpPost, DisableRequestSizeLimit]
        [Route("uploadfile")]
        public IActionResult Upload()
        {
            try
            {
                var file = Request.Form.Files[0];
                var folderName = Path.Combine("wwwroot", "images");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

                if (file.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = Path.Combine(folderName, fileName);

                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }

                    return Ok(new { dbPath });
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }

        // POST: api/ProjectDocument
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public ActionResult<ProjectDocumentDTO>PostProjectDocumentDTO(List<ProjectDocumentDTO> projectDocumentDTO)
        {
            _projectDocumentRepository.Add(projectDocumentDTO);
            _projectDocumentRepository.Save();

            return CreatedAtAction("GetProjectDocumentDTO", new { id = projectDocumentDTO.Count() }, projectDocumentDTO);
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

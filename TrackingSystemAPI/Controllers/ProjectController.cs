using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrackingSystemAPI.DTO;
using TrackingSystemAPI.Models;
using TrackingSystemAPI.Repositories.ProjectRepository;

namespace TrackingSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectRepository _projectRepository;
        
        public ProjectController(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        // GET: api/Project
        [HttpGet]
        public IEnumerable<ProjectDTO> GetProjectDTO()
        {
            return  _projectRepository.GetAll();
        }

        // GET: api/Project/5
        [HttpGet("{id}")]
        public ActionResult<ProjectDTO> GetProjectDTO(int id)
        {
            var projectDTO = _projectRepository.GetById(id); //await _context.ProjectDTO.FindAsync(id);

            if (projectDTO == null)
            {
                return NotFound();
            }

            return projectDTO;
        }

        // PUT: api/Project/5
        [HttpPut("{id}")]
        public IActionResult PutProjectDTO(int id, ProjectDTO projectDTO)
        {
            //var project = _projectRepository.GetById(id);
            if (id != projectDTO.Id)
            {
                return BadRequest();
            }
                _projectRepository.Update(projectDTO);
            try
            {
                _projectRepository.Save();
                // await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                string message = ex.Message;
            }

            return Ok();
        }

        // POST: api/Project
        [HttpPost]
        public int PostProjectDTO(ProjectDTO projectDTO)
        {
           return  _projectRepository.Add(projectDTO);
          
           // return CreatedAtAction("GetProjectDTO", new { id = projectDTO.Id }, projectDTO);
        }
        // DELETE: api/Project/5
        [HttpDelete("{id}")]
        public ActionResult<Project> DeleteProjectDTO(int id)
        {
            var projectDTO = _projectRepository.Find(id);
            if (projectDTO == null)
            {
                return NotFound();
            }
            _projectRepository.Delete(id);
            _projectRepository.Save();

            return Ok();
        }
    }
}

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
        private readonly ApplicationDbContext _context;
        private readonly IProjectRepository _projectRepository;

        public ProjectController(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        // GET: api/Project
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProjectDTO>>> GetProjectDTO()
        {
            return await _context.ProjectDTO.ToListAsync();
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
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public IActionResult PutProjectDTO(int id, ProjectDTO projectDTO)
        {
            //var project = _projectRepository.GetById(id);
            if (id != projectDTO.Id)
            {
                return BadRequest();
            }
                _projectRepository.Update(projectDTO);
            //_context.Entry(projectDTO).State = EntityState.Modified;
            try
            {

                _projectRepository.Save();
                // await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                string message = ex.Message;
            }

            return NoContent();
        }

        // POST: api/Project
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public ActionResult<ProjectDTO> PostProjectDTO(ProjectDTO projectDTO)
        {
            _projectRepository.Add(projectDTO);
             _projectRepository.Save();

            return CreatedAtAction("GetProjectDTO", new { id = projectDTO.Id }, projectDTO);
        }

        // DELETE: api/Project/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProjectDTO>> DeleteProjectDTO(int id)
        {
            var projectDTO = await _context.ProjectDTO.FindAsync(id);
            if (projectDTO == null)
            {
                return NotFound();
            }

            _context.ProjectDTO.Remove(projectDTO);
            await _context.SaveChangesAsync();

            return projectDTO;
        }

        //private bool ProjectDTOExists(int id)
        //{
        //    return _context.ProjectDTO.Any(e => e.Id == id);
        //}
    }
}

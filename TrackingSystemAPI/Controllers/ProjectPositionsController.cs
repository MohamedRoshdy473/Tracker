using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrackingSystemAPI.Models;
using TrackingSystemAPI.Repositories.ProjectPositionRepositories;

namespace TrackingSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectPositionsController : ControllerBase
    {
        private readonly IProjectPositionRepository _projectPositionRepository;

        public ProjectPositionsController(IProjectPositionRepository projectPositionRepository)
        {
            _projectPositionRepository = projectPositionRepository;
        }

        // GET: api/ProjectPositions
        [HttpGet]
        public IEnumerable<ProjectPosition> GetprojectPositions()
        {
            return _projectPositionRepository.GetAll();
        }

        // GET: api/ProjectPositions/5
        [HttpGet("{id}")]
        public ActionResult<ProjectPosition> GetProjectPosition(int id)
        {
            var projectPosition = _projectPositionRepository.Find(id);

            if (projectPosition == null)
            {
                return NotFound();
            }

            return projectPosition;
        }

        // PUT: api/ProjectPositions/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProjectPosition(int id, ProjectPosition projectPosition)
        {
            if (id != projectPosition.Id)
            {
                return BadRequest();
            }

            _projectPositionRepository.Update(projectPosition);

            try
            {
                _projectPositionRepository.Save();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                string msg = ex.Message;
            }

            return NoContent();
        }

        // POST: api/ProjectPositions
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public ActionResult<ProjectPosition> PostProjectPosition(ProjectPosition projectPosition)
        {
            _projectPositionRepository.Add(projectPosition);
            _projectPositionRepository.Save();

            return CreatedAtAction("GetProjectPosition", new { id = projectPosition.Id }, projectPosition);
        }

        // DELETE: api/ProjectPositions/5
        [HttpDelete("{id}")]
        public ActionResult<ProjectPosition> DeleteProjectPosition(int id)
        {
            var projectPosition = _projectPositionRepository.Find(id);
            if (projectPosition == null)
            {
                return NotFound();
            }

            _projectPositionRepository.Delete(id);
            _projectPositionRepository.Save();

            return projectPosition;
        }

        //private bool ProjectPositionExists(int id)
        //{
        //    return _context.projectPositions.Any(e => e.Id == id);
        //}
    }
}

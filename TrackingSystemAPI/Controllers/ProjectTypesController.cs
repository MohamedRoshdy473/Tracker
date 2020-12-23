using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrackingSystemAPI.Models;
namespace TrackingSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectTypesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProjectTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ProjectTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProjectType>>> GetprojectTypes()
        {
            return await _context.projectTypes.ToListAsync();
        }

        // GET: api/ProjectTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectType>> GetProjectType(int id)
        {
            var projectType = await _context.projectTypes.FindAsync(id);

            if (projectType == null)
            {
                return NotFound();
            }

            return projectType;
        }

        // PUT: api/ProjectTypes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProjectType(int id, ProjectType projectType)
        {
            if (id != projectType.Id)
            {
                return BadRequest();
            }

            _context.Entry(projectType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectTypeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ProjectTypes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ProjectType>> PostProjectType(ProjectType projectType)
        {
            _context.projectTypes.Add(projectType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProjectType", new { id = projectType.Id }, projectType);
        }

        // DELETE: api/ProjectTypes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProjectType>> DeleteProjectType(int id)
        {
            var projectType = await _context.projectTypes.FindAsync(id);
            if (projectType == null)
            {
                return NotFound();
            }

            _context.projectTypes.Remove(projectType);
            await _context.SaveChangesAsync();

            return projectType;
        }

        private bool ProjectTypeExists(int id)
        {
            return _context.projectTypes.Any(e => e.Id == id);
        }
    }
}

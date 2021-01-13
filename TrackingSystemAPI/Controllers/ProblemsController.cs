using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrackingSystemAPI.Models;
using TrackingSystemAPI.Repositories.ProblemsRepositories;

namespace TrackingSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProblemsController : ControllerBase
    {
        private readonly IProblemsRepository _problemsRepository;

        public ProblemsController(IProblemsRepository problemsRepository)
        {
            _problemsRepository = problemsRepository;
        }

        // GET: api/Problems
        [HttpGet]
        public IEnumerable<Problems> GetrequestTypes()
        {
            return _problemsRepository.GetAll();
        }

        // GET: api/Problems/5
        [HttpGet("{id}")]
        public ActionResult<Problems> GetProblems(int id)
        {
            return _problemsRepository.GetById(id); 
        }

        // PUT: api/Problems/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public IActionResult PutProblems(int id, Problems problems)
        {
            if (id != problems.Id)
            {
                return BadRequest();
            }

            _problemsRepository.Update(problems);

            try
            {
                _problemsRepository.Save();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                string msg = ex.Message;
            }

            return NoContent();
        }

        // POST: api/Problems
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public ActionResult<Problems> PostProblems(Problems problems)
        {
            _problemsRepository.Add(problems);
            _problemsRepository.Save();

            return CreatedAtAction("GetProblems", new { id = problems.Id }, problems);
        }

        // DELETE: api/Problems/5
        [HttpDelete("{id}")]
        public ActionResult<Problems> DeleteProblems(int id)
        {
            var problems = _problemsRepository.Find(id);
            if (problems == null)
            {
                return NotFound();
            }

            _problemsRepository.Delete(id);
            _problemsRepository.Save();

            return problems;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrackingSystemAPI.Models;
using TrackingSystemAPI.Repositories.OrganizationRepositories;

namespace TrackingSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrganizationsController : ControllerBase
    {
        private readonly IOrganizationRepository _organizationRepository;

        public OrganizationsController(IOrganizationRepository organizationRepository)
        {
            _organizationRepository = organizationRepository;
        }

        // GET: api/Organizations
        [HttpGet]
        public IEnumerable<Organization> Getorganizations()
        {
            return  _organizationRepository.GetAll();
        }

        // GET: api/Organizations/5
        [HttpGet("{id}")]
        public ActionResult<Organization> GetOrganization(int id)
        {
            var organization =_organizationRepository.GetById(id);

            if (organization == null)
            {
                return NotFound();
            }

            return organization;
        }

        // PUT: api/Organizations/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public IActionResult PutOrganization(int id, Organization organization)
        {
            if (id != organization.Id)
            {
                return BadRequest();
            }

            _organizationRepository.Update(organization);

            try
            {
                _organizationRepository.Save();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                string message = ex.Message;
            }

            return NoContent();
        }

        // POST: api/Organizations
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public  ActionResult<Organization> PostOrganization(Organization organization)
        {
            _organizationRepository.Add(organization);
           _organizationRepository.Save();

            return CreatedAtAction("GetOrganization", new { id = organization.Id }, organization);
        }

        // DELETE: api/Organizations/5
        [HttpDelete("{id}")]
        public ActionResult<Organization> DeleteOrganization(int id)
        {
            var organization = _organizationRepository.Find(id);
            if (organization == null)
            {
                return NotFound();
            }

            _organizationRepository.Delete(id);
            _organizationRepository.Save();

            return Ok();
        }

        //private bool OrganizationExists(int id)
        //{
        //    return _context.organizations.Any(e => e.Id == id);
        //}
    }
}

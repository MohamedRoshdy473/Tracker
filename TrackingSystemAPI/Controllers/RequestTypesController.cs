using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrackingSystemAPI.Repositories.RequestTypeRepositories;
using TrackingSystemAPI.Models;

namespace TrackingSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestTypesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IRequestTypeRepository _requestTypeRepository;

        public RequestTypesController(IRequestTypeRepository requestTypeRepository)
        {
            _requestTypeRepository = requestTypeRepository;
        }
        //public RequestTypesController(ApplicationDbContext context)
        //{
        //    _context = context;
        //}

        // GET: api/RequestTypes
        [HttpGet]
        public IEnumerable<RequestType> GetrequestTypes()
        {
            return _requestTypeRepository.GetAll();

        }

        // GET: api/RequestTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RequestType>> GetRequestType(int id)
        {
            var requestType = await _context.requestTypes.FindAsync(id);

            if (requestType == null)
            {
                return NotFound();
            }

            return requestType;
        }

        // PUT: api/RequestTypes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRequestType(int id, RequestType requestType)
        {
            if (id != requestType.Id)
            {
                return BadRequest();
            }

            _context.Entry(requestType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RequestTypeExists(id))
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

        // POST: api/RequestTypes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<RequestType>> PostRequestType(RequestType requestType)
        {
            _context.requestTypes.Add(requestType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRequestType", new { id = requestType.Id }, requestType);
        }

        // DELETE: api/RequestTypes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<RequestType>> DeleteRequestType(int id)
        {
            var requestType = await _context.requestTypes.FindAsync(id);
            if (requestType == null)
            {
                return NotFound();
            }

            _context.requestTypes.Remove(requestType);
            await _context.SaveChangesAsync();

            return requestType;
        }

        private bool RequestTypeExists(int id)
        {
            return _context.requestTypes.Any(e => e.Id == id);
        }
    }
}

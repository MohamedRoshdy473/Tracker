using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrackingSystemAPI.DTO;
using TrackingSystemAPI.Models;
using TrackingSystemAPI.Repositories.RequestImageRepositories;

namespace TrackingSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestImagesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        private readonly IRequestImageRepositories _requestImageRepositories;

        public RequestImagesController(IRequestImageRepositories requestImageRepositories)
        {
            _requestImageRepositories = requestImageRepositories;
        }
        

        // GET: api/RequestImages
        [HttpGet]
        public IEnumerable<requestImages> GetRequestImageDTO()
        {
            return _requestImageRepositories.GetAll();

        }

        // GET: api/RequestImages/5
        [HttpGet("{id}")]
        public ActionResult<requestImages> GetRequestImageDTO(int id)
        {
            var requestimage = _requestImageRepositories.GetById(id);

            if (requestimage == null)
            {
                return NotFound();
            }

            return requestimage;
        }

        // PUT: api/RequestImages/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRequestImageDTO(int id, requestImages requestImages)
        {
            if (id != requestImages.Id)
            {
                return BadRequest();
            }

            _context.Entry(requestImages).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                string msg = ex.Message;

            }

            return NoContent();
        }

        // POST: api/RequestImages
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public void PostRequestImageDTO(List<RequestImageDTO> requestImageDTOs)
        {
            _requestImageRepositories.Add(requestImageDTOs);
            _requestImageRepositories.Save();

        }

        // DELETE: api/RequestImages/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<RequestImageDTO>> DeleteRequestImageDTO(int id)
        {
            var requestImageDTO = await _context.RequestImageDTO.FindAsync(id);
            if (requestImageDTO == null)
            {
                return NotFound();
            }

            _context.RequestImageDTO.Remove(requestImageDTO);
            await _context.SaveChangesAsync();

            return requestImageDTO;
        }


       
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrackingSystemAPI.DTO;
using TrackingSystemAPI.Models;
using TrackingSystemAPI.Repositories.ClientRepositories;

namespace TrackingSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        private readonly IClientRepository _clientRepository;

        public ClientsController(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        // GET: api/Clients
        [HttpGet]
        public IEnumerable<ClientDTO> GetClientDTO()
        {
            return  _clientRepository.GetAll();

        }

        // GET: api/Clients/5
        [HttpGet("{id}")]
        public ActionResult<ClientDTO> GetClientDTO(int id)
        {
            var clientDTO =  _context.ClientDTO.Find(id);

            if (clientDTO == null)
            {
                return NotFound();
            }

            return clientDTO;
        }

        // PUT: api/Clients/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public IActionResult PutClientDTO(int id, ClientDTO clientDTO)
        {
            if (id != clientDTO.Id)
            {
                return BadRequest();
            }

                _clientRepository.Update(clientDTO);


            try
            {
                _clientRepository.Save();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                string message = ex.Message;
            }

            return NoContent();
        }

        // POST: api/Clients
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public ActionResult<ClientDTO> PostClientDTO(ClientDTO clientDTO)
        {
            _clientRepository.Add(clientDTO);
            _clientRepository.Save();            

            return CreatedAtAction("GetClientDTO", new { id = clientDTO.Id }, clientDTO);
        }

        // DELETE: api/Clients/5
        [HttpDelete("{id}")]
        public ActionResult<Client> DeleteClientDTO(int id)
        {
            var clienDTo = _clientRepository.Find(id);
            if (clienDTo == null)
            {
                return NotFound();
            }
            _clientRepository.Delete(id);
            _clientRepository.Save();

            return Ok();
        }

        private bool ClientDTOExists(int id)
        {
            return _context.ClientDTO.Any(e => e.Id == id);
        }
    }
}

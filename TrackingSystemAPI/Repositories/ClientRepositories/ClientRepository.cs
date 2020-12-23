using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrackingSystemAPI.DTO;
using TrackingSystemAPI.Models;

namespace TrackingSystemAPI.Repositories.ClientRepositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly ApplicationDbContext _context;
        public ClientRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Add(ClientDTO clientDTO)
        {
            var client = new Client();
            client.Id = clientDTO.Id;
            client.Address = clientDTO.Address;
            client.ClientCode = clientDTO.ClientCode;
            client.ClientName = clientDTO.ClientName;
            client.Email = clientDTO.Email;
            client.gender = clientDTO.gender;
            client.OrganizationId = clientDTO.OrganizationId;
            client.Phone = clientDTO.Phone;
            _context.clients.Add(client);
        }

        public void Delete(int id)
        {
            Client client = Find(id);
            _context.clients.Remove(client);
        }

        public Client Find(int id)
        {
            return _context.clients.Find(id);

        }

        public IEnumerable<ClientDTO> GetAll()
        {
            var client = _context.clients.Select(e => new ClientDTO
            {
                Id = e.Id,
                ClientName=e.ClientName,
                Phone=e.Phone,
                OrganizationId=e.OrganizationId,
                Address=e.Address,
                ClientCode=e.ClientCode,
                Email=e.Email,
                gender=e.gender,
                OrganizationName=e.Organization.OrganizationName
              
            }).ToList();
            return client;
        }

        public ClientDTO GetById(int id)
        {
        var client = _context.clients.Include(c => c.Organization).FirstOrDefault(e => e.Id == id);
            var clientDTO = new ClientDTO
            {
                Id = client.Id,
                ClientName = client.ClientName,
                Phone = client.Phone,
                OrganizationId = client.OrganizationId,
                Address = client.Address,
                ClientCode = client.ClientCode,
                Email = client.Email,
                gender = client.gender,
                OrganizationName = client.Organization.OrganizationName
            };
            if (client == null)
            {
                return null;
            }

            return clientDTO;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(ClientDTO clientDTO)
        {
            var client = new Client();
            client.Id = clientDTO.Id;
            client.Address = clientDTO.Address;
            client.ClientCode = clientDTO.ClientCode;
            client.ClientName = clientDTO.ClientName;
            client.Email = clientDTO.Email;
            client.gender = clientDTO.gender;
            client.OrganizationId = clientDTO.OrganizationId;
            client.Phone = clientDTO.Phone;
            _context.Entry(client).State = EntityState.Modified;

        }
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

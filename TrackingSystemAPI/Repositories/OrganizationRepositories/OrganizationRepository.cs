using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrackingSystemAPI.Models;

namespace TrackingSystemAPI.Repositories.OrganizationRepositories
{
    public class OrganizationRepository : IOrganizationRepository
    {
        private readonly ApplicationDbContext _context;
        public OrganizationRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Add(Organization organization)
        {
            _context.organizations.Add(organization);
        }

        public void Delete(int id)
        {
            Organization organization = Find(id);
            _context.organizations.Remove(organization);
        }

        public Organization Find(int id)
        {
            return _context.organizations.Find(id);
        }

        public IEnumerable<Organization> GetAll()
        {
           return _context.organizations.ToList();
        }

        public Organization GetById(int id)
        {
            Organization organization = _context.organizations.Where(o => o.Id == id).FirstOrDefault();
            return organization;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Organization organization)
        {
            _context.Entry(organization).State = EntityState.Modified;
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

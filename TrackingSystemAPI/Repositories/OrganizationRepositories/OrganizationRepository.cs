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
            Organization org = new Organization();
            org.Id = organization.Id;
            org.OrganizationName = organization.OrganizationName;
            org.OrganizationCode = organization.OrganizationCode;
            org.Mobile = organization.Mobile;
            org.Phone = organization.Phone;
            org.Address = organization.Address;
            org.ResponsiblePerson = organization.ResponsiblePerson;
            org.lat = organization.lat;
            org.lng = organization.lng;
            org.IsDeleted = false;
            _context.organizations.Add(org);
        }

        public void Delete(Organization organization)
        {
            // Organization organization = Find(id);
            Organization org = new Organization();
            org.Id = organization.Id;
            org.OrganizationName = organization.OrganizationName;
            org.OrganizationCode = organization.OrganizationCode;
            org.Mobile = organization.Mobile;
            org.Phone = organization.Phone;
            org.Address = organization.Address;
            org.ResponsiblePerson = organization.ResponsiblePerson;
            org.lat = organization.lat;
            org.lng = organization.lng;
            org.IsDeleted = true;
            _context.Entry(org).State = EntityState.Modified;
            //_context.organizations.Remove(organization);
        }

        public Organization Find(int id)
        {
            return _context.organizations.Find(id);
        }

        public IEnumerable<Organization> GetAll()
        {
            var Orgs = _context.organizations.Where(o => o.IsDeleted == false).Select(organization => new Organization
            {
                Id = organization.Id,
                OrganizationName = organization.OrganizationName,
                OrganizationCode = organization.OrganizationCode,
                Mobile = organization.Mobile,
                Phone = organization.Phone,
                Address = organization.Address,
                ResponsiblePerson = organization.ResponsiblePerson,
                lat = organization.lat,
                lng = organization.lng,
            }).ToList();
           return Orgs;
        }

        public Organization GetById(int id)
        {
            return _context.organizations.Find(id);// _context.organizations.Where(o => o.Id == id).FirstOrDefault();
             
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

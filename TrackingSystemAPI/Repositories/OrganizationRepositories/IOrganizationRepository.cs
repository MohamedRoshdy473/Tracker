using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrackingSystemAPI.Models;

namespace TrackingSystemAPI.Repositories.OrganizationRepositories
{
    interface IOrganizationRepository : IDisposable
    {
        IEnumerable<Organization> GetAll();
        Organization GetById(int id);
        Organization Find(int id);
        void Add(Organization organization);
        void Update(Organization organization);
        void Delete(int id);
        void Save();
    }
}

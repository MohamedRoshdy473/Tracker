using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrackingSystemAPI.Models;
using TrackingSystemAPI.Repositories.RequestStatusRepositories;

namespace TrackingSystemAPI.Repositories.RequestStatusRepositories
{
    public class RequestStatusRepository : IRequestStatusRepository
    {
        private readonly ApplicationDbContext _context;
        public RequestStatusRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Add(RequestStatus requestStatus)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
        public RequestStatus Find(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<RequestStatus> GetAll()
        {
            throw new NotImplementedException();
        }

        public RequestStatus GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(RequestStatus requestStatus)
        {
            throw new NotImplementedException();
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

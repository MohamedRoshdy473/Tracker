using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrackingSystemAPI.Models;

namespace TrackingSystemAPI.Repositories.RequestTypeRepositories
{
    public class RequestTypeRepository : IRequestTypeRepository
    {
        private readonly ApplicationDbContext _context;
        public RequestTypeRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Add(RequestType requestType)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
        public RequestType Find(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<RequestType> GetAll()
        {
            throw new NotImplementedException();
        }

        public RequestType GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(RequestType requestType)
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

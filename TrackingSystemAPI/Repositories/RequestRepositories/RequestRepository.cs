using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrackingSystemAPI.DTO;
using TrackingSystemAPI.Models;

namespace TrackingSystemAPI.Repositories.RequestRepositories
{
    public class RequestRepository : IRequestRepository
    {
        private readonly ApplicationDbContext _context;
        public RequestRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Add(Request request)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
        public Request Find(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<RequestDTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public RequestDTO GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(Request request)
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

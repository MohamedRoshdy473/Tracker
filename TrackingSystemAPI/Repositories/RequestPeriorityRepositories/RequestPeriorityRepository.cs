using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrackingSystemAPI.Models;

namespace TrackingSystemAPI.Repositories.RequestPeriorityRepositories
{
    public class RequestPeriorityRepository : IRequestPeriorityRepository
    {
        private readonly ApplicationDbContext _context;
        public RequestPeriorityRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Add(RequestPeriority requestPeriority)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
        public RequestPeriority Find(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<RequestPeriority> GetAll()
        {
            throw new NotImplementedException();
        }

        public RequestPeriority GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(RequestPeriority requestPeriority)
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

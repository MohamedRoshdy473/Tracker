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
            _context.requestPeriorities.Add(requestPeriority);
        }

        public void Delete(int id)
        {
            RequestPeriority requestPeriority = Find(id);
            _context.requestPeriorities.Remove(requestPeriority);
        }
        public RequestPeriority Find(int id)
        {
           return _context.requestPeriorities.Find(id);
        }

        public IEnumerable<RequestPeriority> GetAll()
        {
           return _context.requestPeriorities.ToList();
        }

        public RequestPeriority GetById(int id)
        {
            return _context.requestPeriorities.Where(rp => rp.Id == id).FirstOrDefault();
        }

        public void Save()
        {
            _context.SaveChanges();
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

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
            _context.requestTypes.Add(requestType);
        }

        public void Delete(int id)
        {
            RequestType requestType = Find(id);
            _context.requestTypes.Remove(requestType);
        }
        public RequestType Find(int id)
        {
            return _context.requestTypes.Find(id);
        }

        public IEnumerable<RequestType> GetAll()
        {
            return _context.requestTypes.ToList();

        }

        public RequestType GetById(int id)
        {
           return _context.requestTypes.Where(r => r.Id == id).FirstOrDefault();
        }

        public void Save()
        {
            _context.SaveChanges();
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

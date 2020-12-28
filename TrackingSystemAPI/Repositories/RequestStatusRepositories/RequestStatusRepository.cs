using Microsoft.EntityFrameworkCore;
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
            _context.requestStatuses.Add(requestStatus);
        }

        public void Delete(int id)
        {
            RequestStatus requestStatus = Find(id);
            _context.requestStatuses.Remove(requestStatus);
        }
        public RequestStatus Find(int id)
        {
           return _context.requestStatuses.Find(id);
        }

        public IEnumerable<RequestStatus> GetAll()
        {
           return _context.requestStatuses.ToList();
        }

        public RequestStatus GetById(int id)
        {
            return _context.requestStatuses.Where(s => s.Id == id).FirstOrDefault();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(RequestStatus requestStatus)
        {
            _context.Entry(requestStatus).State = EntityState.Modified;
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

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrackingSystemAPI.Models;

namespace TrackingSystemAPI.Repositories.RequestModeRepositories
{
    public class RequestModeRepository
    {
        private readonly ApplicationDbContext _context;
        public RequestModeRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Add(RequestMode RequestMode)
        {
            _context.requestModes.Add(RequestMode);
        }

        public void Delete(int id)
        {
            RequestMode RequestMode = Find(id);
            _context.requestModes.Remove(RequestMode);
        }
        public RequestMode Find(int id)
        {
            return _context.requestModes.Find(id);
        }

        public IEnumerable<RequestMode> GetAll()
        {
            return _context.requestModes.ToList();
        }

        public RequestMode GetById(int id)
        {
            return _context.requestModes.Where(d => d.Id == id).FirstOrDefault();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(RequestMode RequestMode)
        {
            _context.Entry(RequestMode).State = EntityState.Modified;
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

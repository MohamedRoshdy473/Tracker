using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrackingSystemAPI.Models;

namespace TrackingSystemAPI.Repositories.RequestImageRepositories
{
    public class RequestImageRepositories : IRequestImageRepositories
    {
        private readonly ApplicationDbContext _context;
        public RequestImageRepositories(ApplicationDbContext context)
        {
            _context = context;
        }
       

        public void Add(requestImages requestImages)
        {
            _context.requestImages.Add(requestImages);

        }
        IEnumerable<requestImages> IRequestImageRepositories.GetAll()
        {
            return _context.requestImages.ToList();

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

        public void Save()
        {
            _context.SaveChanges();

        }

        public requestImages GetById(int id)
        {
            return _context.requestImages.Where(a => a.Id == id).FirstOrDefault();

        }

        public requestImages Find(int id)
        {
            return _context.requestImages.Find(id);

        }
    }
}

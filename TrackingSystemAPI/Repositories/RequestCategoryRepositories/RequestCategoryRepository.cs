using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrackingSystemAPI.DTO;
using TrackingSystemAPI.Models;

namespace TrackingSystemAPI.Repositories.RequestCategoryRepositories
{
    public class RequestCategoryRepository : IRequestCategoryRepository
    {
        private readonly ApplicationDbContext _context;
        public RequestCategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Add(RequestCategory requestCategory)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
        public RequestCategory Find(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<RequestCategoryDTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public RequestCategoryDTO GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(RequestCategory requestCategory)
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

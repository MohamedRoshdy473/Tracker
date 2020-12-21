using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrackingSystemAPI.DTO;
using TrackingSystemAPI.Models;

namespace TrackingSystemAPI.Repositories.RequestSubCategoryRepositories
{
    public class RequestSubCategoryRepository : IRequestSubCategoryRepository
    {
        private readonly ApplicationDbContext _context;
        public RequestSubCategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Add(RequestSubCategory requestSubCategory)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
        public RequestSubCategory Find(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<RequestSubCategoryDTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public RequestSubCategoryDTO GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(RequestSubCategory requestSubCategory)
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

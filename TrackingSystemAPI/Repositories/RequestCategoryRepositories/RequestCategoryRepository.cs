using Microsoft.EntityFrameworkCore;
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
        public void Add(RequestCategoryDTO requestCategoryDTO)
        {
            var requestCategory = new RequestCategory();
            requestCategory.DepartmentId = requestCategoryDTO.DepartmentId;
            requestCategory.CategoryName = requestCategoryDTO.CategoryName;
            _context.requestCategories.Add(requestCategory);
        }

        public void Delete(int id)
        {
            var requestCategory = Find(id);
            _context.requestCategories.Remove(requestCategory);
        }
        public RequestCategory Find(int id)
        {
            return _context.requestCategories.Find(id);
        }

        public IEnumerable<RequestCategoryDTO> GetAll()
        {
            return _context.requestCategories.Select(cat => new RequestCategoryDTO
            {
                Id = cat.Id,
                CategoryName = cat.CategoryName,
                DepartmentId = cat.DepartmentId,
                DepartmentName = cat.Department.Name
            }).ToList();
        }

        public RequestCategoryDTO GetById(int id)
        {
            var cat= _context.requestCategories.Include(c => c.Department).Where(cat => cat.Id == id).FirstOrDefault();
            var category = new RequestCategoryDTO
            {
                Id = cat.Id,
                CategoryName = cat.CategoryName,
                DepartmentId = cat.DepartmentId,
                DepartmentName = cat.Department.Name
            };
            return category;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(RequestCategoryDTO requestCategoryDTO)
        {
            var requestCategory = new RequestCategory();
            requestCategory.DepartmentId = requestCategoryDTO.DepartmentId;
            requestCategory.CategoryName = requestCategoryDTO.CategoryName;
            _context.Entry(requestCategoryDTO).State = EntityState.Modified;
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

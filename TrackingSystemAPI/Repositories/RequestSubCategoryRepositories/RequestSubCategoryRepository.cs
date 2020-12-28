using Microsoft.EntityFrameworkCore;
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
        public void Add(RequestSubCategoryDTO requestSubCategoryDTO)
        {
            var requestSubCategory = new RequestSubCategory();
            //requestSubCategory.Id = requestSubCategoryDTO.Id;
            requestSubCategory.RequestCategoryId = requestSubCategoryDTO.RequestCategoryId;
            requestSubCategory.SubCategoryName = requestSubCategoryDTO.SubCategoryName;
            _context.requestSubCategories.Add(requestSubCategory);
        }

        public void Delete(int id)
        {
            var requestSubCategory = Find(id);
            _context.requestSubCategories.Remove(requestSubCategory);
        }
        public RequestSubCategory Find(int id)
        {
           return _context.requestSubCategories.Find(id);
        }

        public IEnumerable<RequestSubCategoryDTO> GetAll()
        {
            return _context.requestSubCategories.Select(sub => new RequestSubCategoryDTO
            {
                Id = sub.Id,
                SubCategoryName = sub.SubCategoryName,
                RequestCategoryId = sub.RequestCategoryId,
                RequestCategoryName = sub.RequestCategory.CategoryName
            }).ToList();
        }

        public RequestSubCategoryDTO GetById(int id)
        {
            var sub = _context.requestSubCategories.Include(sub => sub.RequestCategory).Where(s => s.Id == id).FirstOrDefault();
            var requestSubCategory = new RequestSubCategoryDTO
            {
                Id = sub.Id,
                SubCategoryName = sub.SubCategoryName,
                RequestCategoryId = sub.RequestCategoryId,
                RequestCategoryName = sub.RequestCategory.CategoryName
            };
            return requestSubCategory;

        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(RequestSubCategoryDTO requestSubCategoryDTO)
        {
            var requestSubCategory = new RequestSubCategory();
            requestSubCategory.Id = requestSubCategoryDTO.Id;
            requestSubCategory.RequestCategoryId = requestSubCategoryDTO.RequestCategoryId;
            requestSubCategory.SubCategoryName = requestSubCategoryDTO.SubCategoryName;
            _context.Entry(requestSubCategory).State = EntityState.Modified;
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

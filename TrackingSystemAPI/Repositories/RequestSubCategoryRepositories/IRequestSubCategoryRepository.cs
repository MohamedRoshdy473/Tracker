using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrackingSystemAPI.DTO;
using TrackingSystemAPI.Models;

namespace TrackingSystemAPI.Repositories.RequestSubCategoryRepositories
{
   public interface IRequestSubCategoryRepository : IDisposable
    {
        IEnumerable<RequestSubCategoryDTO> GetAll();
        RequestSubCategoryDTO GetById(int id);
        RequestSubCategory Find(int id);
        void Add(RequestSubCategoryDTO requestSubCategoryDTO);
        void Update(RequestSubCategoryDTO requestSubCategoryDTO);
        void Delete(int id);
        void Save();
    }
}

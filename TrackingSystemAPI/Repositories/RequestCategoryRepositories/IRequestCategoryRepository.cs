using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrackingSystemAPI.DTO;
using TrackingSystemAPI.Models;

namespace TrackingSystemAPI.Repositories.RequestCategoryRepositories
{
   public interface IRequestCategoryRepository : IDisposable
    {
        IEnumerable<RequestCategoryDTO> GetAll();
        RequestCategoryDTO GetById(int id);
        RequestCategory Find(int id);
        void Add(RequestCategory requestCategory);
        void Update(RequestCategory requestCategory);
        void Delete(int id);
        void Save();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrackingSystemAPI.Models;

namespace TrackingSystemAPI.Repositories.RequestTypeRepositories
{
   public interface IRequestTypeRepository : IDisposable
    {
        IEnumerable<RequestType> GetAll();
        RequestType GetById(int id);
        RequestType Find(int id);
        void Add(RequestType requestType);
        void Update(RequestType requestType);
        void Delete(int id);
        void Save();
    }
}

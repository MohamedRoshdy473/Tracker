using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrackingSystemAPI.DTO;
using TrackingSystemAPI.Models;

namespace TrackingSystemAPI.Repositories.RequestRepositories
{
   public interface IRequestRepository : IDisposable
    {
        IEnumerable<RequestDTO> GetAll();
        RequestDTO GetById(int id);
        Request Find(int id);
        void Add(Request request);
        void Update(Request request);
        void Delete(int id);
        void Save();
    }
}

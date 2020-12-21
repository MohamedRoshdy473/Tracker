using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrackingSystemAPI.Models;

namespace TrackingSystemAPI.Repositories.RequestStatusRepositories
{
   public interface IRequestStatusRepository : IDisposable
    {
        IEnumerable<RequestStatus> GetAll();
        RequestStatus GetById(int id);
        RequestStatus Find(int id);
        void Add(RequestStatus requestStatus);
        void Update(RequestStatus requestStatus);
        void Delete(int id);
        void Save();
    }
}

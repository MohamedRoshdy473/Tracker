using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrackingSystemAPI.Models;

namespace TrackingSystemAPI.Repositories.RequestPeriorityRepositories
{
  public  interface IRequestPeriorityRepository : IDisposable
    {
        IEnumerable<RequestPeriority> GetAll();
        RequestPeriority GetById(int id);
        RequestPeriority Find(int id);
        void Add(RequestPeriority requestPeriority);
        void Update(RequestPeriority requestPeriority);
        void Delete(int id);
        void Save();
    }
}

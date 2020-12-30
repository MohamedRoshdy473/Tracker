using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrackingSystemAPI.Models;

namespace TrackingSystemAPI.Repositories.RequestModeRepositories
{
   public interface IRequestModeRepository: IDisposable
    {
        IEnumerable<RequestMode> GetAll();
        RequestMode GetById(int id);
        RequestMode Find(int id);
        void Add(RequestMode RequestMode);
        void Update(RequestMode RequestMode);
        void Delete(int id);
        void Save();
    }
}

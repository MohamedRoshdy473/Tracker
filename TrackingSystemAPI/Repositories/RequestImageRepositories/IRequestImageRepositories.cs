using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrackingSystemAPI.Models;
using TrackingSystemAPI.DTO;

namespace TrackingSystemAPI.Repositories.RequestImageRepositories
{
    public interface IRequestImageRepositories : IDisposable
    {
        IEnumerable<requestImages> GetAll();
        requestImages GetById(int id);
        IEnumerable<RequestImageDTO> GetRequestImageByRequestId(int requestID);

        requestImages Find(int id);
        void Add(List<RequestImageDTO> request);
        void Save();
    }
}

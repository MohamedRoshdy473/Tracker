using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrackingSystemAPI.DTO;
using TrackingSystemAPI.Models;

namespace TrackingSystemAPI.Repositories.RequestDescriptionRepositories
{
    public interface IRequestDescriptionRepository : IDisposable
    {
        IEnumerable<RequestDescriptionDTO> GetAll();
        RequestDescriptionDTO GetById(int id);
        RequestDescription Find(int id);
        void Add(RequestDescriptionDTO requestDescriptionDTO);
        void Update(RequestDescriptionDTO requestDescriptionDTO);
        void Delete(int id);
        void Save();
    }
}

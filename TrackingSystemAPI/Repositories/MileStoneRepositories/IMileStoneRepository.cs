using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrackingSystemAPI.DTO;
using TrackingSystemAPI.Models;

namespace TrackingSystemAPI.Repositories.MileStoneRepositories
{
  public  interface IMileStoneRepository : IDisposable
    {
        IEnumerable<MileStoneDTO> GetAll();
        MileStoneDTO GetById(int id);
        MileStone Find(int id);
        void Add(List<MileStoneDTO> mileStone);
        void Update(MileStoneDTO mileStone);
        void Delete(int id);
        void Save();
    }
}

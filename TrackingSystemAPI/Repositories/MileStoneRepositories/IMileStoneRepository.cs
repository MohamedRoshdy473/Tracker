using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrackingSystemAPI.DTO;
using TrackingSystemAPI.Models;

namespace TrackingSystemAPI.Repositories.MileStoneRepositories
{
    interface IMileStoneRepository : IDisposable
    {
        IEnumerable<MileStoneDTO> GetAll();
        MileStoneDTO GetById(int id);
        MileStone Find(int id);
        void Add(MileStone mileStone);
        void Update(MileStone mileStone);
        void Delete(int id);
        void Save();
    }
}

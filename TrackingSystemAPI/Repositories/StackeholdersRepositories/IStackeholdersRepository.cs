using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrackingSystemAPI.DTO;
using TrackingSystemAPI.Models;

namespace TrackingSystemAPI.Repositories.StackeholdersRepositories
{
    interface IStackeholdersRepository : IDisposable
    {
        IEnumerable<StackeholdersDTO> GetAll();
        StackeholdersDTO GetById(int id);
        Stackeholders Find(int id);
        void Add(Stackeholders stackeholders);
        void Update(Stackeholders stackeholders);
        void Delete(int id);
        void Save();
    }
}

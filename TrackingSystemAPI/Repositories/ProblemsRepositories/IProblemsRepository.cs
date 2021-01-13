using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrackingSystemAPI.Models;

namespace TrackingSystemAPI.Repositories.ProblemsRepositories
{
   public interface IProblemsRepository : IDisposable
    {
        IEnumerable<Problems> GetAll();
        Problems GetById(int id);
        Problems Find(int id);
        void Add(Problems problems);
        void Update(Problems problems);
        void Delete(int id);
        void Save();
    }
}

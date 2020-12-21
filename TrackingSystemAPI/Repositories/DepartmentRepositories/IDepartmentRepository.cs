using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrackingSystemAPI.Models;

namespace TrackingSystemAPI.Repositories.DepartmentRepositories
{
   public interface IDepartmentRepository : IDisposable
    {
        IEnumerable<Department> GetAll();
        Department GetById(int id);
        Department Find(int id);
        void Add(Department department);
        void Update(Department department);
        void Delete(int id);
        void Save();
    }
}

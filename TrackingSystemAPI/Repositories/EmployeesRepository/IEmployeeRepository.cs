using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrackingSystemAPI.DTO;
using TrackingSystemAPI.Models;

namespace TrackingSystemAPI.Repositories.EmployeesRepository
{
   public interface IEmployeeRepository : IDisposable
    {
        IEnumerable<EmployeeDTO> GetAll();
        EmployeeDTO GetById(int id);
        Employee Find(int id);
        void Add(Employee employee);
        void Update(Employee employee);
        void Delete(int id);
        void Save();
    }
}

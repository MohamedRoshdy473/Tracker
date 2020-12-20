using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrackingSystemAPI.DTO;
using TrackingSystemAPI.Models;

namespace TrackingSystemAPI.Repositories.EmployeesRepository
{
    public class EmployeeRepository:IEmployeeRepository
    {
        private readonly ApplicationDbContext _context;
        //public EmployeeRepository()
        //{
        //    _context = new ApplicationDbContext();
        //}
        public EmployeeRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<EmployeeDTO> GetAll()
        {
            var emps = _context.Employees.Select(e => new EmployeeDTO
            {
                ID = e.Id,
                Name = e.Name,
                DepartmentName = e.Department.Name,
                GraduatioYear = e.GraduatioYear,
                Address = e.Address,
                Code = e.Code,
                DateOfBirth = e.DateOfBirth,
                Email = e.Email,
                gender = e.gender,
                HiringDateHiringDate = e.HiringDateHiringDate,
                MaritalStatus = e.MaritalStatus,
                Phone = e.Phone,
                RelevantPhone = e.RelevantPhone,
                Photo = e.Photo
            }).ToList();
            return emps;
        }
        public void Add(Employee employee)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
        public Employee Find(int id)
        {
            throw new NotImplementedException();
        }
        public Employee GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Employee employee)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

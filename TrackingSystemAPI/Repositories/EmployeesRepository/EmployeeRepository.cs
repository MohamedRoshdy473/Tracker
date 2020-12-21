using Microsoft.EntityFrameworkCore;
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
        public EmployeeRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<EmployeeDTO> GetAll()
        {
            var emps = _context.Employees.Select(e => new EmployeeDTO
            {
                ID = e.Id,
                Name = e.EmployeeName,
                DepartmentName = e.Department.Name,
                Address = e.Address,
                Code = e.EmployeeCode,
               // DateOfBirth = e.DateOfBirth,
                Email = e.Email,
                gender = e.gender,
                //HiringDateHiringDate = e.HiringDateHiringDate,
                MaritalStatus = e.MaritalStatus,
                Phone = e.Phone,
                Mobile = e.Mobile,
                Photo = e.Photo
            }).ToList();
            return emps;
        }
        public EmployeeDTO GetById(int id)
        {
            var e = _context.Employees.Include(e => e.Department).FirstOrDefault(e => e.Id == id);
            var emp = new EmployeeDTO
            {
                ID = e.Id,
                Name = e.EmployeeName,
                DepartmentName = e.Department.Name,
                DepartmentId = e.DepartmentId,
                Address = e.Address,
                Code = e.EmployeeCode,
               // DateOfBirth = e.DateOfBirth,
                Email = e.Email,
                gender = e.gender,
               //HiringDateHiringDate = e.HiringDateHiringDate,
                MaritalStatus = e.MaritalStatus,
                Phone = e.Phone,
                Mobile = e.Mobile,
                Photo = e.Photo
            };
            if (emp == null)
            {
                return null;
            }

            return emp;
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

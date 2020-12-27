using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrackingSystemAPI.Models;

namespace TrackingSystemAPI.Repositories.DepartmentRepositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly ApplicationDbContext _context;
        public DepartmentRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Add(Department department)
        {
            _context.departments.Add(department);
        }

        public void Delete(int id)
        {
            Department department = Find(id);
            _context.departments.Remove(department);
        }
        public Department Find(int id)
        {
            return _context.departments.Find(id);
        }

        public IEnumerable<Department> GetAll()
        {
          return  _context.departments.ToList();
        }

        public Department GetById(int id)
        {
            return _context.departments.Where(d => d.Id == id).FirstOrDefault();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Department department)
        {
            _context.Entry(department).State = EntityState.Modified;
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

        public Department GetDepartmentByEmployeeId(int EmployeeId)
        {
            var dep = _context.Employees.Where(e => e.Id == EmployeeId).Select(d => new Department
            {
                Id = d.Department.Id,
                Name = d.Department.Name
            });
            return dep.FirstOrDefault();
        }
    }
}

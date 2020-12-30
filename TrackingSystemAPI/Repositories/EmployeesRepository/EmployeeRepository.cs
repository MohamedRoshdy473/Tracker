﻿using Microsoft.EntityFrameworkCore;
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
                Id = e.Id,
                EmployeeName = e.EmployeeName,
                DepartmentName = e.Department.Name,
                Position = e.Position,
                Address = e.Address,
                EmployeeCode = e.EmployeeCode,
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
                Id = e.Id,
                EmployeeName = e.EmployeeName,
                DepartmentName = e.Department.Name,
                DepartmentId = e.DepartmentId,
                Address = e.Address,
                Position=e.Position,
                EmployeeCode = e.EmployeeCode,
                Email = e.Email,
                gender = e.gender,
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
        public void Add(EmployeeDTO employeeDTO)
        {
            var emp = new Employee();
            emp.EmployeeName = employeeDTO.EmployeeName;
            emp.Position = employeeDTO.Position;
            emp.DepartmentId = employeeDTO.DepartmentId;
            emp.EmployeeCode = employeeDTO.EmployeeCode;
            emp.gender = employeeDTO.gender;
            emp.Address = employeeDTO.Address;
            emp.MaritalStatus = employeeDTO.MaritalStatus;
            emp.Phone = employeeDTO.Phone;
            emp.Mobile = employeeDTO.Mobile;
            emp.Email = employeeDTO.Email;
            emp.Photo = employeeDTO.Photo;
            _context.Employees.Add(emp);
        }

        public void Delete(int id)
        {
            Employee employee = Find(id);
            _context.Employees.Remove(employee);
        }
        public Employee Find(int id)
        {
           return _context.Employees.Find(id);
        }
        public void Update(EmployeeDTO employeeDTO)
        {
            var emp = new Employee();
            emp.Id = employeeDTO.Id;
            emp.EmployeeName = employeeDTO.EmployeeName;
            emp.Position = employeeDTO.Position;
            emp.DepartmentId = employeeDTO.DepartmentId;
            emp.EmployeeCode = employeeDTO.EmployeeCode;
            emp.gender = employeeDTO.gender;
            emp.Address = employeeDTO.Address;
            emp.MaritalStatus = employeeDTO.MaritalStatus;
            emp.Phone = employeeDTO.Phone;
            emp.Mobile = employeeDTO.Mobile;
            emp.Email = employeeDTO.Email;
            emp.Photo = employeeDTO.Photo;
            _context.Entry(emp).State = EntityState.Modified;
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrackingSystemAPI.Models;
using TrackingSystemAPI.Repositories.DepartmentRepositories;

namespace TrackingSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentsController(IDepartmentRepository departmentRepository)
        {
            _departmentRepository=departmentRepository;
        }

        // GET: api/Departments
        [HttpGet]
        public IEnumerable<Department> Getdepartments()
        {
            return _departmentRepository.GetAll();        }

        // GET: api/Departments/5
        [HttpGet("{id}")]
        public ActionResult<Department> GetDepartment(int id)
        {
            var department =  _departmentRepository.Find(id);

            if (department == null)
            {
                return NotFound();
            }

            return department;
        }

        // PUT: api/Departments/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public IActionResult PutDepartment(int id, Department department)
        {
            if (id != department.Id)
            {
                return BadRequest();
            }

            _departmentRepository.Update(department);

            try
            {
                _departmentRepository.Save();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                string msg = ex.Message;
            }

            return NoContent();
        }

        // POST: api/Departments
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public ActionResult<Department> PostDepartment(Department department)
        {
            _departmentRepository.Add(department);
            _departmentRepository.Save();

            return CreatedAtAction("GetDepartment", new { id = department.Id }, department);
        }

        // DELETE: api/Departments/5
        [HttpDelete("{id}")]
        public ActionResult<Department> DeleteDepartment(int id)
        {
            var department = _departmentRepository.Find(id);
            if (department == null)
            {
                return NotFound();
            }

            _departmentRepository.Delete(id);
            _departmentRepository.Save();

            return department;
        }
        [HttpGet("GetDepartmentByEmployeeId/{EmployeeId}")]
        public Department GetDepartmentByEmployeeId(int EmployeeId)
        {
           return _departmentRepository.GetDepartmentByEmployeeId(EmployeeId);
        }
        //private bool DepartmentExists(int id)
        //{
        //    return _context.departments.Any(e => e.Id == id);
        //}
    }
}

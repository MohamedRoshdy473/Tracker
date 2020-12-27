using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TrackingSystemAPI.DTO;
using TrackingSystemAPI.Models;
using TrackingSystemAPI.Repositories.EmployeesRepository;

namespace TrackingSystemAPI.Controllers
{
    //[Authorize(AuthenticationSchemes =
    //JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private IEmployeeRepository _employeeRepository;
        //private readonly ApplicationDbContext _context;
        //private readonly IWebHostEnvironment hostingEnvironment;
        //private readonly UserManager<ApplicationUser> userManager;
        //public EmployeesController()
        //{
        //  _employeeRepository = new EmployeeRepository(new ApplicationDbContext());
        //}
        public EmployeesController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        [HttpGet]
        public IEnumerable<EmployeeDTO> GetEmployees()
        {
            return _employeeRepository.GetAll();
        }
        [HttpGet("{id}")]
        public EmployeeDTO GetEmployee(int id)
        {
            return _employeeRepository.GetById(id);
        }
    }
}
 
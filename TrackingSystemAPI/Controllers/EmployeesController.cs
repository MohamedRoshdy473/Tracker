using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        [HttpPost]
        public ActionResult<EmployeeDTO> PostEmployee(EmployeeDTO employeeDTO)
        {
            _employeeRepository.Add(employeeDTO);
            _employeeRepository.Save();
            return CreatedAtAction("GetEmployee", new { id = employeeDTO.Id }, employeeDTO);
        }
        [HttpPost]
        [Route("api/dashboard/UploadImage")]
        public ActionResult UploadFile(IFormFile file)
        {
            var ImagesTypes = new List<string>() { "image/jpg", "image/jpeg", "image/png" };
            string path;
            if (ImagesTypes.Contains(file.ContentType))
            {
                path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/", file.FileName);
                using (Stream stream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

            }
            else
            {
                return BadRequest();
            }
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpGet]
        [Route("getImage/{ImageName}")]
        public IActionResult ImageGet(string ImageName)
        {
            if (ImageName == null)
                return Content("filename not present");

            var path = Path.Combine(
                           Directory.GetCurrentDirectory(),
                           "wwwroot/images", ImageName);
            var memory = new MemoryStream();
            var ext = System.IO.Path.GetExtension(path);
            using (var stream = new FileStream(path, FileMode.Open))
            {
                stream.CopyTo(memory);
            }
            memory.Position = 0;
            var contentType = "APPLICATION/octet-stream";
            return File(memory, contentType, Path.GetFileName(path));
        }
        public IActionResult getFile(string FName)
        {
            if (FName == null)
                return Content("filename not present");

            var path = Path.Combine(
                           Directory.GetCurrentDirectory(),
                           "wwwroot/images/", FName);

            var memory = new MemoryStream();
            var ext = System.IO.Path.GetExtension(path);
            using (var stream = new FileStream(path, FileMode.Open))
            {
                stream.CopyTo(memory);
            }
            memory.Position = 0;
            var contentType = "APPLICATION/pdf";
            //return File(Path.GetFileName(path), contentType, FName);
            return File(memory, contentType, Path.GetFileName(path));
        }


        [HttpPut("{id}")]
        public IActionResult PutEmployee(int id, EmployeeDTO employeeDTO)
        {
            if (id != employeeDTO.Id)
            {
                return BadRequest();
            }

            _employeeRepository.Update(employeeDTO);

            try
            {
                _employeeRepository.Save();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                string msg = ex.Message;
            }

            return NoContent();
        }
        [HttpDelete("{id}")]
        public ActionResult<Employee> DeleteEmployee(int id)
        {
            var EmployeeDTo = _employeeRepository.Find(id);
            if (EmployeeDTo == null)
            {
                return NotFound();
            }
            _employeeRepository.Delete(id);
            _employeeRepository.Save();

            return Ok();
        }

    }
}
 
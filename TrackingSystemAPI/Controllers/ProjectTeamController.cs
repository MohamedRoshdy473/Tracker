using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrackingSystemAPI.DTO;
using TrackingSystemAPI.Models;
using TrackingSystemAPI.Repositories.ProjectTeamRepositories;
using TrackingSystemAPI.ViewModels;

namespace TrackingSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectTeamController : ControllerBase
    {
        private readonly IProjectTeamRepository _projectTeamRepository;

        public ProjectTeamController(IProjectTeamRepository projectTeamRepository)
        {
            _projectTeamRepository = projectTeamRepository;
        }
        // GET: api/ProjectTeam
        [HttpGet]
        public IEnumerable<ProjectTeamDTO> GetProjectTeamDTO()
        {
            return _projectTeamRepository.GetAll();
        }

        // GET: api/ProjectTeam/5
        [HttpGet("{id}")]
        public ActionResult<ProjectTeamDTO> GetProjectTeamDTO(int id)
        {
            var projectTeamDTO = _projectTeamRepository.GetById(id);

            if (projectTeamDTO == null)
            {
                return NotFound();
            }

            return projectTeamDTO;
        }
        [HttpGet]
        [Route("GetProjectTeamsByProjectId/{ProjectId}")]
        public IEnumerable<ProjectTeamDTO> GetProjectTeamsByProjectId(int ProjectId)
        {
            return _projectTeamRepository.GetProjectTeamsByProjectId(ProjectId);
        }
        [HttpGet]
        [Route("GetProjectTeamsByProjectPositionId/{ProjectPositionId}")]
        public IEnumerable<ProjectTeamDTO> GetProjectTeamsByProjectPositionId(int ProjectPositionId)

        {
            return _projectTeamRepository.GetProjectTeamsByProjectPositionId(ProjectPositionId);
        }

        [HttpGet]
        [Route("GetEmployeessByTeamId/{TeamId}/{PositionId}")]
        public IEnumerable<ProjectTeamDTO> GetEmployeessByTeamId(int TeamId, int PositionId)

        {
            return _projectTeamRepository.GetEmployeessByTeamId(TeamId,PositionId);
        }
        [HttpGet]
        
        [Route("GetProjectTeamByProjectIdAndTeamIdAndProjectPositionId/{ProjectId}/{TeamId}/{ProjectPositionId}")]
        public ProjectTeamDTO GetProjectTeamByProjectIdAndTeamIdAndProjectPositionId(int ProjectId, int TeamId, int ProjectPositionId)
        {
            return _projectTeamRepository.GetProjectTeamByProjectIdAndTeamIdAndProjectPositionId(ProjectId, TeamId, 1);
        }
        [HttpGet]
        [Route("GetProjectTeamByProjectPositionIdAndEmployeeId/{ProjectPositionId}/{EmployeeId}")]
        public IEnumerable<ProjectTeamDTO> GetProjectTeamByProjectPositionIdAndEmployeeId(int ProjectPositionId, int EmployeeId)
        {
            return _projectTeamRepository.GetProjectTeamByProjectPositionIdAndEmployeeId(ProjectPositionId, EmployeeId);
        }
        [HttpPost]
        [Route("GetAllProjectTeamsByProjectIds")]
        public List<ProjectTeamDTO> GetAllProjectTeamsByProjectIds(ProjectsVM model)
        {
            return _projectTeamRepository.GetAllProjectTeamsByProjectIds(model);
        }

        // PUT: api/ProjectTeam/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public IActionResult PutProjectTeamDTO(int id, ProjectTeamDTO projectTeamDTO)
        {
            if (id != projectTeamDTO.ID)
            {
                return BadRequest();
            }

            _projectTeamRepository.Update(projectTeamDTO);

            try
            {
                _projectTeamRepository.Save();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                string message = ex.Message;
            }

            return NoContent();
        }

        //update by id
        [HttpPut("{id}")]
        [Route("updateteamsByProjectId/{id}")]
        public IActionResult PutteamssDTOByProjectId(int id, List<ProjectTeamDTO> projectTeamDTOs)
        {


            _projectTeamRepository.UpdateByProjectId(id, projectTeamDTOs);

            try
            {
                _projectTeamRepository.Save();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                string message = ex.Message;
            }

            return Ok();
        }

        // POST: api/ProjectTeam
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public void PostProjectTeamDTO(List<ProjectTeamDTO> projectTeamDTO)
        {
            _projectTeamRepository.Add(projectTeamDTO);
            _projectTeamRepository.Save();

            // return CreatedAtAction("GetProjectTeamDTO", new { id = projectTeamDTO.Count() }, projectTeamDTO);
        }

        // DELETE: api/ProjectTeam/5
        [HttpDelete("{id}")]
        public ActionResult<ProjectTeam> DeleteProjectTeamDTO(int id)
        {
            var projectTeamDTO = _projectTeamRepository.Find(id);
            if (projectTeamDTO == null)
            {
                return NotFound();
            }

            _projectTeamRepository.Delete(id);
            _projectTeamRepository.Save();

            return Ok();
        }

    }
}

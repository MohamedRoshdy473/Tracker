﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrackingSystemAPI.DTO;
using TrackingSystemAPI.Models;
using TrackingSystemAPI.Repositories.ProjectTeamRepositories;

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

        //private bool ProjectTeamDTOExists(int id)
        //{
        //    return _context.ProjectTeamDTO.Any(e => e.Id == id);
        //}
    }
}

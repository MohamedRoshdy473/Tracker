using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using TrackingSystemAPI.DTO;
using TrackingSystemAPI.Models;

namespace TrackingSystemAPI.Repositories.ProjectRepository
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly ApplicationDbContext _context;
        public ProjectRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public int Add(ProjectDTO projectDTO)
        {

            var project = new Project();
            project.ProjectName = projectDTO.ProjectName;
            project.ProjectCode = projectDTO.ProjectCode;
            project.ProjectTypeId = projectDTO.ProjectTypeId;
            project.Cost = projectDTO.Cost;
            project.ProjectPeriod = projectDTO.ProjectPeriod;
            project.PlanndedStartDate = projectDTO.PlanndedStartDate;
            project.ActualStartDate = projectDTO.ActualStartDate;
            project.PlanndedEndDate = projectDTO.PlanndedEndDate;
            project.ActualEndDate = projectDTO.ActualEndDate;
            project.Description = projectDTO.Description;
            project.OrganizationId = projectDTO.OrganizationId;
            project.EmployeeId = projectDTO.EmployeeId;
            project.ClientId = projectDTO.ClientId;
            _context.projects.Add(project);
            _context.SaveChanges();
            return project.Id;
        }

        public void Delete(int id)
        {
            Project project = Find(id);
            _context.projects.Remove(project);
        }

        public Project Find(int id)
        {
            return _context.projects.Find(id);
        }

        public IEnumerable<ProjectDTO> GetAll()
        {
            var proj = _context.projects.Select(e => new ProjectDTO
            {
                Id = e.Id,
                ProjectName = e.ProjectName,
                ProjectCode = e.ProjectCode,
                Cost = e.Cost,
                ProjectTypeId = e.ProjectTypeId,
                ProjectTypeName=e.ProjectType.TypeName,
                ProjectPeriod = e.ProjectPeriod,
                PlanndedStartDate = e.PlanndedStartDate,
                PlanndedEndDate = e.PlanndedEndDate,
                ActualStartDate = e.ActualStartDate,
                ActualEndDate = e.ActualEndDate,
                Description = e.Description,
                OrganizationId = e.OrganizationId,
                OrganizationName = e.Organization.OrganizationName,
                EmployeeId = e.EmployeeId,
                EmployeeName = e.Employee.EmployeeName,
                ClientId = e.ClientId,
                ClientName = e.Client.ClientName,
                ClientMobile=e.Client.Phone
            }).ToList();
            return proj;
        }

        public ProjectDTO GetById(int id)
        {
            var project = _context.projects.Include(p => p.Organization).Include(p => p.Employee).Include(p => p.Client).FirstOrDefault(e => e.Id == id);
            var projectDTO = new ProjectDTO
            {
                Id = project.Id,
                ProjectName = project.ProjectName,
                ProjectCode = project.ProjectCode,
                ProjectTypeId = project.ProjectTypeId,
                ProjectTypeName = project.ProjectType.TypeName,
                Cost = project.Cost,
                ProjectPeriod = project.ProjectPeriod,
                PlanndedStartDate = project.PlanndedStartDate,
                ActualStartDate = project.ActualStartDate,
                PlanndedEndDate = project.PlanndedEndDate,
                ActualEndDate = project.ActualEndDate,
                Description = project.Description,
                OrganizationId = project.OrganizationId,
                OrganizationName = project.Organization.OrganizationName,
                EmployeeId = project.EmployeeId,
                EmployeeName = project.Employee.EmployeeName,
                ClientId = project.ClientId,
                ClientName = project.Client.ClientName
            };
            if (project == null)
            {
                return null;
            }

            return projectDTO;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(ProjectDTO projectDTO)
        {
            var project = new Project();
            project.Id = projectDTO.Id;
            project.ProjectName = projectDTO.ProjectName;
            project.ProjectCode = projectDTO.ProjectCode;
            project.ProjectTypeId = project.ProjectTypeId;
            project.Cost = projectDTO.Cost;
            project.ProjectPeriod = projectDTO.ProjectPeriod;
            project.PlanndedStartDate = projectDTO.PlanndedStartDate;
            project.ActualStartDate = projectDTO.ActualStartDate;
            project.PlanndedEndDate = projectDTO.PlanndedEndDate;
            project.ActualEndDate = projectDTO.ActualEndDate;
            project.Description = projectDTO.Description;
            project.OrganizationId = projectDTO.OrganizationId;
            project.EmployeeId = projectDTO.EmployeeId;
            project.ClientId = projectDTO.ClientId;
            _context.Entry(project).State = EntityState.Modified;
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

        public IEnumerable<ProjectDTO> GetProjectsByClientId(int ClientId)
        {
            var pro = _context.projects.Where(p => p.ClientId == ClientId).Select(project => new ProjectDTO
            {
                ProjectName = project.ProjectName,
                ProjectCode = project.ProjectCode
            }).ToList();
            return pro;
        }
    }
}

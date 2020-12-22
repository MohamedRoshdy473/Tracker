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
        public void Add(ProjectDTO projectDTO)
        {
            var project = new Project();
            project.Id = projectDTO.Id;
            project.ProjectName = projectDTO.ProjectName;
            project.ProjectCode = projectDTO.ProjectCode;
            project.Type = projectDTO.Type;
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
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Project Find(int id)
        {
            return _context.projects.Find(id);
        }

        public IEnumerable<ProjectDTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public ProjectDTO GetById(int id)
        {
            var project = _context.projects.Include(p => p.Organization).Include(p => p.Employee).Include(p => p.Client).FirstOrDefault(e => e.Id == id);
            var projectDTO = new ProjectDTO
            {
                Id = project.Id,
                ProjectName = project.ProjectName,
                ProjectCode = project.ProjectCode,
                Type = project.Type,
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
            project.Type = projectDTO.Type;
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
    }
}

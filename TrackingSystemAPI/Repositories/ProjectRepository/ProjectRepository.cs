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
        public void Add(Project project)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Project Find(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProjectDTO> GetAll()
        {
            var proj = _context.projects.Select(e => new ProjectDTO
            {
                Id = e.Id,
                ProjectName = e.ProjectName,
                ProjectCode = e.ProjectCode,
                Cost = e.Cost,
                Type = e.Type,
                ProjectPeriod = e.ProjectPeriod,
                PlanndedStartDate = e.PlanndedStartDate,
                PlanndedEndDate = e.PlanndedEndDate,
                ActualStartDate = e.ActualStartDate,
                ActualEndDate = e.ActualEndDate,
                Description = e.Description,
                OrganizationId = e.OrganizationId,
                OrganizationName = e.Organization.OrganizationName,
                EmployeeId = e.EmployeeId,
                EmployeeName=e.Employee.EmployeeName,
                ClientId=e.ClientId,
                ClientName=e.Client.ClientName,
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
                Type = project.Type,
                Cost = project.Cost,
                ProjectPeriod = project.ProjectPeriod,
                PlanndedStartDate = project.PlanndedStartDate,
                ActualStartDate = project.ActualStartDate,
                PlanndedEndDate=project.PlanndedEndDate,
                ActualEndDate=project.ActualEndDate,
                Description=project.Description,
                OrganizationId=project.OrganizationId,
                OrganizationName=project.Organization.OrganizationName,
                EmployeeId=project.EmployeeId,
                EmployeeName=project.Employee.EmployeeName,
                ClientId=project.ClientId,
                ClientName=project.Client.ClientName
            };
            if (project == null)
            {
                return null;
            }

            return projectDTO;
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(Project project)
        {
            throw new NotImplementedException();
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

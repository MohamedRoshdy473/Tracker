﻿using Microsoft.EntityFrameworkCore;
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
            project.IsDeleted = false;
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

        public void SoftDelete(ProjectDTO projectDTO)
        {
            var project = new Project();
            project.Id = projectDTO.Id;
            project.ProjectName = projectDTO.ProjectName;
            project.ProjectCode = projectDTO.ProjectCode;
            project.ProjectTypeId = projectDTO.ProjectTypeId;
            project.Cost = projectDTO.Cost;
            project.IsDeleted = true;
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

        public Project Find(int id)
        {
            return _context.projects.Find(id);
        }

        public IEnumerable<ProjectDTO> GetAll()
        {
            var proj = _context.projects.Where(e=>e.IsDeleted==false).Select(e => new ProjectDTO
            {
                Id = e.Id,
                ProjectName = e.ProjectName,
                ProjectCode = e.ProjectCode,
                Cost = e.Cost,
                ProjectTypeId = e.ProjectTypeId,
                ProjectTypeName=e.ProjectType.TypeName,
               // IsDeleted=e.IsDeleted,
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
            var project = _context.projects.Include(p => p.Organization).Include(p => p.Employee).Include(p => p.Client).Include(p=>p.ProjectType).FirstOrDefault(e => e.Id == id);
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
                IsDeleted=project.IsDeleted,
                ActualStartDate = project.ActualStartDate,
                PlanndedEndDate = project.PlanndedEndDate,
                ActualEndDate = project.ActualEndDate,
                Description = project.Description,
                OrganizationId = project.OrganizationId,
                OrganizationName = project.Organization.OrganizationName,
                EmployeeId = project.EmployeeId,
                EmployeeName = project.Employee.EmployeeName,
                ClientId = project.ClientId,
                ClientName = project.Client.ClientName,
                ClientMobile=project.Client.Phone
                
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
            project.ProjectTypeId = projectDTO.ProjectTypeId;
            project.Cost = projectDTO.Cost;
            project.IsDeleted = projectDTO.IsDeleted;
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
            var pro = _context.projects.Where(p => p.ClientId == ClientId && p.IsDeleted==false).Select(project => new ProjectDTO
            {
                ProjectName = project.ProjectName,
                ProjectCode = project.ProjectCode
            }).ToList();
            return pro;
        }
        public IEnumerable<ClientDTO> GetClientByProjectId(int ProjectId)
        {
            var clientDTO = _context.projects.Where(c => c.Id == ProjectId && c.IsDeleted==false).Select(client => new ClientDTO
            {
                ClientName = client.Client.ClientName,
                Id = client.ClientId
            }).ToList();
            return clientDTO;
        }

        public IEnumerable<ProjectDTO> GetAllProjectsByEmployeeId(int EmployeeId)
        {
            var proj = _context.projects.Where(e => e.IsDeleted == false&&e.EmployeeId==EmployeeId).
                Include(p => p.Organization).
                Include(p => p.Employee).
                Include(p => p.Client).
                Include(p => p.ProjectType).
                Select(e => new ProjectDTO
            {
                Id = e.Id,
                ProjectName = e.ProjectName,
                ProjectCode = e.ProjectCode,
                Cost = e.Cost,
                ProjectTypeId = e.ProjectTypeId,
                ProjectTypeName = e.ProjectType.TypeName,
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
                ClientMobile = e.Client.Phone
            }).ToList();
            return proj;
        }

        public IEnumerable<ProjectDTO> GetClientsByEmployeeId(int EmployeeId)
        {
            var proj = _context.projects.Where(e => e.IsDeleted == false && e.EmployeeId == EmployeeId).
                Include(p => p.Organization).
                Include(p => p.Client).
                Select(e => new ProjectDTO
                { ClientCode=e.Client.ClientCode,
                Address=e.Client.Address,
                    Email=e.Client.Email,
                    Phone=e.Client.Phone,
                    Gender=e.Client.gender,
                    OrganizationId = e.OrganizationId,
                    OrganizationName = e.Organization.OrganizationName,
                    EmployeeId = e.EmployeeId,
                    EmployeeName = e.Employee.EmployeeName,
                    ClientId = e.ClientId,
                    ClientName = e.Client.ClientName,
                }).ToList();
            return proj;
        }

        public List<ProjectDTO> GetAllProjectsByProjectTypeId(int ProjectTypeId)
        {
            var project = _context.projects.Where(e => e.ProjectTypeId == ProjectTypeId && e.IsDeleted==false).Select(e => new ProjectDTO
            {
                ProjectTypeId = e.ProjectTypeId,
                ActualEndDate = e.ActualEndDate,
                ClientId = e.ClientId,
                ProjectName = e.ProjectName,
                EmployeeId = e.EmployeeId,
                Id = e.Id,
                IsDeleted = e.IsDeleted,
                OrganizationId = e.OrganizationId,
                OrganizationName = e.Organization.OrganizationName,
                EmployeeName = e.Employee.EmployeeName,
                PlanndedEndDate = e.PlanndedEndDate,
                PlanndedStartDate = e.PlanndedStartDate
            }).ToList();
            return project;
        }
    }
}

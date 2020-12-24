using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrackingSystemAPI.DTO;
using TrackingSystemAPI.Models;

namespace TrackingSystemAPI.Repositories.ProjectTeamRepositories
{
    public class ProjectTeamRepository : IProjectTeamRepository
    {
        private readonly ApplicationDbContext _context;
        public ProjectTeamRepository(ApplicationDbContext context)
        {
            _context = context;
        }
     

        public void Add(List<ProjectTeamDTO> projectTeamDTO)
        {
            foreach (var item in projectTeamDTO)
            {
                ProjectTeam projectTeam = new ProjectTeam();
                projectTeam.EmployeeId = item.EmployeeId;
                projectTeam.ProjectId = item.ProjectId;
                projectTeam.DepartmentId = item.DepartmentId;
                projectTeam.ProjectPositionId = item.ProjectPositionId;
                _context.projectTeams.Add(projectTeam);
            }
        }
        public void Delete(int id)
        {
            ProjectTeam projectTeam = Find(id);
            _context.projectTeams.Remove(projectTeam);
        }
        public ProjectTeam Find(int id)
        {
            return _context.projectTeams.Find(id);
        }

        public IEnumerable<ProjectTeamDTO> GetAll()
        {

            var projectTeam = _context.projectTeams.Select(Pteam => new ProjectTeamDTO
            {
                EmployeeId = Pteam.EmployeeId,
                EmployeeName = Pteam.Employee.EmployeeName,
                ProjectId = Pteam.ProjectId,
                ProjectName = Pteam.Project.ProjectName,
                DepartmentId = Pteam.DepartmentId,
                DepartmentName = Pteam.Department.Name,
                ProjectPositionId = Pteam.ProjectPositionId,
                ProjectPositionName = Pteam.ProjectPosition.PositionName,
            }).ToList();
            return projectTeam;
        }

        public ProjectTeamDTO GetById(int id)
        {
            var projectTeam = _context.projectTeams
                              .Include(p => p.Employee).Include(p => p.Department)
                              .Include(p => p.ProjectId).Include(p => p.ProjectPosition)
                              .FirstOrDefault(predicate => predicate.Id == id);
            ProjectTeamDTO projectTeamDTO= new ProjectTeamDTO
            {
                EmployeeId = projectTeam.EmployeeId,
                EmployeeName = projectTeam.Employee.EmployeeName,
                ProjectId = projectTeam.ProjectId,
                ProjectName = projectTeam.Project.ProjectName,
                DepartmentId = projectTeam.DepartmentId,
                DepartmentName = projectTeam.Department.Name,
                ProjectPositionId = projectTeam.ProjectPositionId,
                ProjectPositionName = projectTeam.ProjectPosition.PositionName,
            };
            return projectTeamDTO;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(ProjectTeamDTO projectTeamDTO)
        {
            ProjectTeam projectTeam = new ProjectTeam();
            projectTeam.Id = projectTeamDTO.Id;
            projectTeam.EmployeeId = projectTeamDTO.EmployeeId;
            projectTeam.ProjectId = projectTeamDTO.ProjectId;
            projectTeam.DepartmentId = projectTeamDTO.DepartmentId;
            projectTeam.ProjectPositionId = projectTeamDTO.ProjectPositionId;
            _context.Entry(projectTeam).State = EntityState.Modified;
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

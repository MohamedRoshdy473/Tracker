using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrackingSystemAPI.DTO;
using TrackingSystemAPI.Models;

namespace TrackingSystemAPI.Repositories.AssignedRequestsRepositories
{
    public class AssignedRequestsRepository : IAssignedRequestsRepository
    {
        private readonly ApplicationDbContext _context;

        public AssignedRequestsRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Add(AssignedRequestsDTO assignedRequestsDTO)
        {
            AssignedRequests assignedRequests = new AssignedRequests();
            assignedRequests.ProjectTeamId = assignedRequestsDTO.ProjectTeamId;
            assignedRequests.RequestId = assignedRequestsDTO.RequestId;
            _context.assignedRequests.Add(assignedRequests);
        }

        public void Delete(int id)
        {
            AssignedRequests assignedRequests = Find(id);
            _context.assignedRequests.Remove(assignedRequests);
        }
        public AssignedRequests Find(int id)
        {
            return _context.assignedRequests.Find(id);
        }

        public IEnumerable<AssignedRequestsDTO> GetAll()
        {
            var AssignedRequests = _context.assignedRequests.Include(a => a.ProjectPosition).Include(a => a.ProjectTeam).Include(a => a.Request)
                 .Select(assign => new AssignedRequestsDTO
                 {
                     Id = assign.Id,
                     EmployeeId = assign.ProjectTeam.EmployeeId,
                     EmployeeName = assign.ProjectTeam.Employee.EmployeeName,
                     ProjectId = assign.Request.ProjectId,
                     ProjectName = assign.Request.Project.ProjectName,
                     ProjectTeamId = assign.ProjectTeamId,
                     //ProjectTeamName = assign.ProjectTeam.teamName,
                     ProjectPositionId = assign.ProjectPositionId,
                     ProjectPositionName = assign.ProjectPosition.PositionName,
                     RequestId = assign.RequestId,
                     RequestName = assign.Request.RequestName
                 }).ToList();
            return AssignedRequests;
        }

        public AssignedRequestsDTO GetById(int id)
        {
            var assign = _context.assignedRequests.Include(a => a.ProjectPosition)
                                .Include(a => a.ProjectTeam).Include(a => a.Request)
                                .Where(a => a.Id == id).FirstOrDefault();
            var assignedRequestsDTO = new AssignedRequestsDTO
            {
                Id = assign.Id,
                EmployeeId = assign.ProjectTeam.EmployeeId,
                EmployeeName = assign.ProjectTeam.Employee.EmployeeName,
                ProjectId = assign.Request.ProjectId,
                ProjectName = assign.Request.Project.ProjectName,
                ProjectTeamId = assign.ProjectTeamId,
              //  ProjectTeamName = assign.ProjectTeam.teamName,
                ProjectPositionId = assign.ProjectPositionId,
                ProjectPositionName = assign.ProjectPosition.PositionName,
                RequestId = assign.RequestId,
                RequestName = assign.Request.RequestName
            };
            return assignedRequestsDTO;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(AssignedRequestsDTO assignedRequestsDTO)
        {
            AssignedRequests assignedRequests = new AssignedRequests();
            assignedRequests.ProjectTeamId = assignedRequestsDTO.ProjectTeamId;
            assignedRequests.RequestId = assignedRequestsDTO.RequestId;
            _context.Entry(assignedRequests).State = EntityState.Modified;
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

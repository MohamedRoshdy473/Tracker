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
            assignedRequests.TeamId = assignedRequestsDTO.TeamId;
            assignedRequests.EmployeeId = assignedRequestsDTO.EmployeeId;
            assignedRequests.ProjectPositionId = assignedRequestsDTO.ProjectPositionId;
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
            var AssignedRequests = _context.assignedRequests.Include(a => a.ProjectPosition).Include(a => a.Team).Include(a => a.Request)
                 .Select(assign => new AssignedRequestsDTO
                 {
                     Id = assign.Id,
                     EmployeeId = assign.EmployeeId,
                     EmployeeName = assign.Employee.EmployeeName,
                     ProjectName = assign.Request.Project.ProjectName,
                     TeamId = assign.TeamId,
                     TeamName = assign.Team.Name,
                     ProjectPositionId = assign.ProjectPositionId,
                     ProjectPositionName = assign.ProjectPosition.PositionName,
                     RequestId = assign.RequestId,
                     RequestName = assign.Request.RequestName
                 }).ToList();
            return AssignedRequests;
        }

        public AssignedRequestsDTO GetById(int id)
        {
            var assign = _context.assignedRequests.Include(a => a.ProjectPosition).Include(a=>a.Employee)
                                .Include(a => a.Team).Include(a => a.Request)
                                .Where(a => a.Id == id).FirstOrDefault();
            var assignedRequestsDTO = new AssignedRequestsDTO
            {
                Id = assign.Id,
                EmployeeId = assign.EmployeeId,
                EmployeeName = assign.Employee.EmployeeName,
                ProjectName = assign.Request.Project.ProjectName,
                TeamId = assign.TeamId,
                TeamName = assign.Team.Name,
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
            assignedRequests.TeamId = assignedRequestsDTO.TeamId;
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

        public IEnumerable<RequestDTO> GetAllRequestByEmployeeId(int EmployeeId)
        {
            var requests = _context.assignedRequests.Where(r => r.EmployeeId == EmployeeId).Include(r => r.Employee).Include(r => r.ProjectPosition)
                      .Include(r => r.Request).Include(r => r.Team)
                      .Include(r => r.Request.Project).Include(r => r.Request.RequestPeriority)
                                             .Include(r => r.Request.RequestStatus).Include(r => r.Request.RequestSubCategory)
                                             .Include(r => r.Request.RequestType).Include(r => r.Request.RequestMode)
                      .Select(req => new RequestDTO
                      {
                          Id = req.RequestId,
                          RequestName = req.Request.RequestName,
                          RequestCode = req.Request.RequestCode,
                          Description = req.Request.Description,
                          RequestDate = req.Request.RequestDate,
                          RequestTime = (req.Request.RequestTime.Value.Hours + ":" + req.Request.RequestTime.Value.Minutes.ToString().PadLeft(2, '0')).ToString(),
                          Photo = req.Request.Photo,
                          RequestModeId = req.Request.RequestModeId,
                          RequestMode = req.Request.RequestMode.Mode,
                          AssetId = req.Request.AssetId,
                          AssetCode = req.Request.Asset.AssetCode,
                          ClientId = req.Request.ClientId,
                          ClientName = req.Request.Client.ClientName,
                          RequestSubCategoryId = req.Request.RequestSubCategoryId,
                          RequestSubCategoryName = req.Request.RequestSubCategory.SubCategoryName,
                          ProjectId = req.Request.ProjectId,
                          ProjectName = req.Request.Project.ProjectName,
                          RequestStatusId = req.Request.RequestStatusId,
                          RequestStatus = req.Request.RequestStatus.status,
                          RequestPeriorityId = req.Request.RequestPeriorityId,
                          RequestPeriority = req.Request.RequestPeriority.periorty,
                          RequestTypeId = req.Request.RequestTypeId,
                          RequestTypeName = req.Request.RequestType.RequestTypeName
                      }).ToList();
            return requests;
        }
    }
}

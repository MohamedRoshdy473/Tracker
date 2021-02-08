using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrackingSystemAPI.DTO;
using TrackingSystemAPI.Models;

namespace TrackingSystemAPI.Repositories.RequestRepositories
{
    public class RequestRepository : IRequestRepository
    {
        private readonly ApplicationDbContext _context;
        public RequestRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public int Add(RequestDTO requestDTO)
        {
            var dtStartTime = DateTime.Parse(requestDTO.RequestTime).ToString("HH:mm:ss");
            Request request = new Request();
            string Req = "Req";
            string requestCode = "";
            var lstIds = _context.requests.ToList();
            if (lstIds.Count > 0)
            {
                var code = lstIds.LastOrDefault().Id;
                requestCode = Req + code + 1;
            }
            else
            {
                requestCode = Req + 1;
            }
            request.IsAssigned = false;
            request.IsSolved = false;
            request.RequestName = requestDTO.RequestName;
            request.RequestCode = requestCode;
            request.Description = requestDTO.Description;
            request.RequestDate = requestDTO.RequestDate;
            request.RequestTime = TimeSpan.Parse(dtStartTime);
            
            request.RequestModeId = requestDTO.RequestModeId;
            request.AssetId = requestDTO.AssetId;
            request.RequestSubCategoryId = requestDTO.RequestSubCategoryId;
            request.ProjectTeamId = requestDTO.ProjectTeamId;
            request.ClientId = requestDTO.ClientId;
            request.RequestStatusId = requestDTO.RequestStatusId;
            request.RequestPeriorityId = requestDTO.RequestPeriorityId;
            _context.requests.Add(request);
            _context.SaveChanges();
            return request.Id;

        }
        public void Delete(int id)
        {
            Request request = Find(id);
            _context.requests.Remove(request);
        }
        public Request Find(int id)
        {
            return _context.requests.Find(id);
        }

        public IEnumerable<RequestDTO> GetAll()
        {
            var request = _context.requests.Include(r => r.ProjectTeam).Include(r => r.RequestPeriority)
                                             .Include(r => r.RequestStatus).Include(r => r.RequestSubCategory)
                                             .Include(r => r.RequestMode)
                                             .Include(r => r.Asset).Select(req => new RequestDTO
                                             {
                                                 Id = req.Id,
                                                 IsSolved = req.IsSolved,
                                                 IsAssigned = req.IsAssigned,
                                                 RequestName = req.RequestName,
                                                 RequestCode = req.RequestCode,
                                                 Description = req.Description,
                                                 RequestDate = req.RequestDate,
                                                 RequestTime = (req.RequestTime).ToString(),                                           
                                                 RequestModeId = req.RequestModeId,
                                                 RequestMode = req.RequestMode.Mode,
                                                 AssetId = req.AssetId,
                                                 AssetCode = req.Asset.AssetCode,
                                                 ClientId = req.ClientId,
                                                 ClientName = req.Client.ClientName,
                                                 RequestSubCategoryId = req.RequestSubCategoryId,
                                                 RequestSubCategoryName = req.RequestSubCategory.SubCategoryName,
                                                 ProjectTeamId = req.ProjectTeamId,
                                                 ProjectName=req.ProjectTeam.Project.ProjectName,
                                                 TeamName=req.ProjectTeam.Team.Name,
                                                 RequestStatusId = req.RequestStatusId,
                                                 RequestStatus = req.RequestStatus.status,
                                                 RequestPeriorityId = req.RequestPeriorityId,
                                                 RequestPeriority = req.RequestPeriority.periorty,
                                             }).ToList();
            return request;
        }

        public RequestDTO GetById(int id)
        {
            var request = _context.requests.Include(p => p.Client).Include(p => p.ProjectTeam).
               Include(p => p.Asset).
               Include(p => p.RequestMode).
               Include(p => p.RequestPeriority).Include(p => p.RequestStatus).
               Include(p => p.RequestSubCategory).
               FirstOrDefault(e => e.Id == id);
            var requestDTO = new RequestDTO
            {
                Id = request.Id,
                RequestName = request.RequestName,
                RequestStatus = request.RequestStatus.status,
                AssetCode = request.Asset.AssetCode,
                AssetId = request.AssetId,
                ClientId = request.ClientId,
                ClientName = request.Client.ClientName,
                Description = request.Description,
                IsAssigned = request.IsAssigned,
                IsSolved = request.IsSolved,
                ProjectTeamId = request.ProjectTeamId,
                RequestCode = request.RequestCode,
                RequestDate = request.RequestDate,
                RequestMode = request.RequestMode.Mode,
                RequestModeId = request.RequestModeId,
                RequestPeriority = request.RequestPeriority.periorty,
                RequestPeriorityId = request.RequestPeriorityId,
                RequestStatusId = request.RequestStatusId,
                RequestSubCategoryId = request.RequestSubCategoryId,
                RequestSubCategoryName = request.RequestSubCategory.SubCategoryName,
                RequestTime = request.RequestTime.ToString()
            };
            if (request == null)
            {
                return null;
            }

            return requestDTO;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(RequestDTO requestDTO)
        {
            Request request = new Request();
            request.Id = requestDTO.Id;
            request.IsSolved = requestDTO.IsSolved;
            request.IsAssigned = requestDTO.IsAssigned;
            request.RequestName = requestDTO.RequestName;
            request.RequestCode = requestDTO.RequestCode;
            request.Description = requestDTO.Description;
            request.RequestDate = requestDTO.RequestDate;
            request.RequestTime = TimeSpan.Parse(requestDTO.RequestTime);
           
            request.RequestModeId = requestDTO.RequestModeId;
            request.AssetId = requestDTO.AssetId;
            request.RequestSubCategoryId = requestDTO.RequestSubCategoryId;
            request.ProjectTeamId = requestDTO.ProjectTeamId;
            request.ClientId = requestDTO.ClientId;
            request.RequestStatusId = requestDTO.RequestStatusId;
            request.RequestPeriorityId = requestDTO.RequestPeriorityId;
            _context.Entry(request).State = EntityState.Modified;
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

        public IEnumerable<RequestDTO> GetProjectTeamsByProjectId(int ProjectId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<RequestDTO> GetAllRequestByClientId(int ClientId)
        {
            var requests = _context.requests.Where(r => r.ClientId == ClientId).Include(r => r.ProjectTeam).Include(r => r.RequestPeriority)
                                             .Include(r => r.RequestStatus).Include(r => r.RequestSubCategory)
                                             .Include(r => r.RequestMode)
                                             .Include(r => r.Asset).Select(req => new RequestDTO
                                             {
                                                 Id = req.Id,
                                                 IsSolved = req.IsSolved,
                                                 IsAssigned = req.IsAssigned,
                                                 RequestName = req.RequestName,
                                                 RequestCode = req.RequestCode,
                                                 Description = req.Description,
                                                 RequestDate = req.RequestDate,
                                                 RequestTime = (req.RequestTime.Value.Hours + ":" + req.RequestTime.Value.Minutes.ToString().PadLeft(2, '0')).ToString(),
                                                
                                                 RequestModeId = req.RequestModeId,
                                                 RequestMode = req.RequestMode.Mode,
                                                 AssetId = req.AssetId,
                                                 AssetCode = req.Asset.AssetCode,
                                                 ClientId = req.ClientId,
                                                 ClientName = req.Client.ClientName,
                                                 RequestSubCategoryId = req.RequestSubCategoryId,
                                                 RequestSubCategoryName = req.RequestSubCategory.SubCategoryName,
                                                 ProjectTeamId = req.ProjectTeamId,
                                                 ProjectName = req.ProjectTeam.Project.ProjectName,
                                                 TeamName = req.ProjectTeam.Team.Name,
                                                 RequestStatusId = req.RequestStatusId,
                                                 RequestStatus = req.RequestStatus.status,
                                                 RequestPeriorityId = req.RequestPeriorityId,
                                                 RequestPeriority = req.RequestPeriority.periorty
                                             }).ToList();
            return requests;
        }

        public List<RequestDTO> GetAllRequestByProjectTeamId(ProjectTeamVM model)
        {
            List<RequestDTO> requestDTO =new List<RequestDTO>();
            var Ids = model.ProjectTeamIds.Split(",");
            string[] lstIds = Ids;
            foreach (var item in lstIds)
            {
                int id = int.Parse(item);
                var request = _context.requests.Where(r => r.ProjectTeamId == id)
                                            .Include(r => r.ProjectTeam).Include(r => r.RequestPeriority)
                                            .Include(r => r.RequestStatus).Include(r => r.RequestSubCategory)
                                            .Include(r => r.RequestMode)
                                            .Include(r => r.Asset).Select(req => new RequestDTO
                                            {
                                                Id = req.Id,
                                                IsSolved = req.IsSolved,
                                                IsAssigned = req.IsAssigned,
                                                RequestName = req.RequestName,
                                                RequestCode = req.RequestCode,
                                                Description = req.Description,
                                                RequestDate = req.RequestDate,
                                                RequestTime = (req.RequestTime).ToString(),
                                               
                                                RequestModeId = req.RequestModeId,
                                                RequestMode = req.RequestMode.Mode,
                                                AssetId = req.AssetId,
                                                AssetCode = req.Asset.AssetCode,
                                                ClientId = req.ClientId,
                                                ClientName = req.Client.ClientName,
                                                RequestSubCategoryId = req.RequestSubCategoryId,
                                                RequestSubCategoryName = req.RequestSubCategory.SubCategoryName,
                                                ProjectTeamId = req.ProjectTeamId,
                                                ProjectName = req.ProjectTeam.Project.ProjectName,
                                                TeamName = req.ProjectTeam.Team.Name,
                                                RequestStatusId = req.RequestStatusId,
                                                RequestStatus = req.RequestStatus.status,
                                                RequestPeriorityId = req.RequestPeriorityId,
                                                RequestPeriority = req.RequestPeriority.periorty,
                                            }).ToList();

                foreach (var item2 in request)
                {
                    requestDTO.Add(item2);
                }            
            }
            return requestDTO;
        }
        
        public List<RequestDTO> GetAllRequestByRequestStatus(int requestStatusId)
        {
            var request = _context.requests.Where(e => e.RequestStatusId == requestStatusId).Select(req => new RequestDTO
            {
                RequestStatusId = req.RequestStatusId,
                Id = req.Id,
                AssetId = req.AssetId,
                RequestName = req.RequestName
            }).ToList();
            return request;
        }

        public RequestDTO GetAllRequestByRequestStatusAndProjectTeamId(int requestStatusId, int ProjectTeamId)
        {
            var request = _context.requests.Include(p => p.Client).Include(p => p.ProjectTeam).
               Include(p => p.Asset).
               Include(p => p.RequestMode).
               Include(p => p.RequestPeriority).Include(p => p.RequestStatus).
               Include(p => p.RequestSubCategory).
               FirstOrDefault(e => e.RequestStatusId == requestStatusId&&e.ProjectTeamId==ProjectTeamId);
            var requestDTO = new RequestDTO
            {
                Id = request.Id,
                RequestName = request.RequestName,
                RequestStatus = request.RequestStatus.status,
                AssetCode = request.Asset.AssetCode,
                AssetId = request.AssetId,
                ClientId = request.ClientId,
                ClientName = request.Client.ClientName,
                Description = request.Description,
                IsAssigned = request.IsAssigned,
                IsSolved = request.IsSolved,
                ProjectTeamId = request.ProjectTeamId,
                RequestCode = request.RequestCode,
                RequestDate = request.RequestDate,
                RequestMode = request.RequestMode.Mode,
                RequestModeId = request.RequestModeId,
                RequestPeriority = request.RequestPeriority.periorty,
                RequestPeriorityId = request.RequestPeriorityId,
                RequestStatusId = request.RequestStatusId,
                RequestSubCategoryId = request.RequestSubCategoryId,
                RequestSubCategoryName = request.RequestSubCategory.SubCategoryName,
                RequestTime = request.RequestTime.ToString()
            };
            if (request == null)
            {
                return null;
            }

            return requestDTO;
        }

        public int CountProjects(int projectId)
        {
         return   (from req in _context.requests
             join projectteam in _context.projectTeams on req.ProjectTeamId equals projectteam.Id
             join proj in _context.projects on projectteam.ProjectId equals proj.Id
             where proj.Id == projectId
                   select proj).ToList().Count;
        }


        public int CountClosedProjects(int projectId)
        {
            return (from req in _context.requests
                    join projectteam in _context.projectTeams on req.ProjectTeamId equals projectteam.Id
                    join proj in _context.projects on projectteam.ProjectId equals proj.Id
                    where req.RequestStatusId == 2
                    where proj.Id == projectId
                    select proj).ToList().Count;
        }

        public int CountOpenProjects(int projectId)
        {
            return (from req in _context.requests
                    join projectteam in _context.projectTeams on req.ProjectTeamId equals projectteam.Id
                    join proj in _context.projects on projectteam.ProjectId equals proj.Id
                    where req.RequestStatusId == 1
                    where proj.Id == projectId
                    select proj).ToList().Count;
        }
        public int CountInProgressProjects(int projectId)
        {
            return (from req in _context.requests
                    join projectteam in _context.projectTeams on req.ProjectTeamId equals projectteam.Id
                    join proj in _context.projects on projectteam.ProjectId equals proj.Id
                    where req.RequestStatusId == 3
                    where proj.Id == projectId
                    select proj).ToList().Count;
        }
    }
}

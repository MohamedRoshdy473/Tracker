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
            request.Photo = requestDTO.Photo;
            request.RequestModeId = requestDTO.RequestModeId;
            request.AssetId = requestDTO.AssetId;
            request.RequestSubCategoryId = requestDTO.RequestSubCategoryId;
            request.ProjectId = requestDTO.ProjectId;
            request.ClientId = requestDTO.ClientId;
            request.RequestStatusId = requestDTO.RequestStatusId;
            request.RequestPeriorityId = requestDTO.RequestPeriorityId;
            request.RequestTypeId = requestDTO.RequestTypeId;
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
            var request = _context.requests.Include(r => r.Project).Include(r => r.RequestPeriority)
                                             .Include(r => r.RequestStatus).Include(r => r.RequestSubCategory)
                                             .Include(r => r.RequestType).Include(r => r.RequestMode)
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
                                                 Photo = req.Photo,
                                                 RequestModeId = req.RequestModeId,
                                                 RequestMode = req.RequestMode.Mode,
                                                 AssetId = req.AssetId,
                                                 AssetCode = req.Asset.AssetCode,
                                                 ClientId = req.ClientId,
                                                 ClientName = req.Client.ClientName,
                                                 RequestSubCategoryId = req.RequestSubCategoryId,
                                                 RequestSubCategoryName = req.RequestSubCategory.SubCategoryName,
                                                 ProjectId = req.ProjectId,
                                                 ProjectName = req.Project.ProjectName,
                                                 RequestStatusId = req.RequestStatusId,
                                                 RequestStatus = req.RequestStatus.status,
                                                 RequestPeriorityId = req.RequestPeriorityId,
                                                 RequestPeriority = req.RequestPeriority.periorty,
                                                 RequestTypeId = req.RequestTypeId,
                                                 RequestTypeName = req.RequestType.RequestTypeName
                                             }).ToList();
            return request;
        }

        public RequestDTO GetById(int id)
        {
            var req = _context.requests.Include(r => r.Project).Include(r => r.RequestPeriority)
                                       .Include(r => r.RequestStatus).Include(r => r.RequestSubCategory)
                                       .Include(r => r.RequestType).Include(r => r.RequestMode)
                                       .Include(r => r.Asset).Where(r => r.Id == id).FirstOrDefault();
            var requestDTO = new RequestDTO
            {
                Id = req.Id,
                IsSolved = req.IsSolved,
                IsAssigned = req.IsAssigned,
                RequestName = req.RequestName,
                RequestCode = req.RequestCode,
                Description = req.Description,
                RequestDate = req.RequestDate,
                RequestTime = req.RequestTime.ToString(),
                Photo = req.Photo,
                RequestModeId = req.RequestModeId,
                RequestMode = req.RequestMode.Mode,
                AssetId = req.AssetId,
                AssetCode = req.Asset.AssetCode,
                ClientId = req.ClientId,
                ClientName = req.Client.ClientName,
                RequestSubCategoryId = req.RequestSubCategoryId,
                RequestSubCategoryName = req.RequestSubCategory.SubCategoryName,
                ProjectId = req.ProjectId,
                ProjectName = req.Project.ProjectName,
                RequestStatusId = req.RequestStatusId,
                RequestStatus = req.RequestStatus.status,
                RequestPeriorityId = req.RequestPeriorityId,
                RequestPeriority = req.RequestPeriority.periorty,
                RequestTypeId = req.RequestTypeId,
                RequestTypeName = req.RequestType.RequestTypeName
            };
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
            request.Photo = requestDTO.Photo;
            request.RequestModeId = requestDTO.RequestModeId;
            request.AssetId = requestDTO.AssetId;
            request.RequestSubCategoryId = requestDTO.RequestSubCategoryId;
            request.ProjectId = requestDTO.ProjectId;
            request.ClientId = requestDTO.ClientId;
            request.RequestStatusId = requestDTO.RequestStatusId;
            request.RequestPeriorityId = requestDTO.RequestPeriorityId;
            request.RequestTypeId = requestDTO.RequestTypeId;
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
            var requests = _context.requests.Where(r => r.ClientId == ClientId).Include(r => r.Project).Include(r => r.RequestPeriority)
                                             .Include(r => r.RequestStatus).Include(r => r.RequestSubCategory)
                                             .Include(r => r.RequestType).Include(r => r.RequestMode)
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
                                                 Photo = req.Photo,
                                                 RequestModeId = req.RequestModeId,
                                                 RequestMode = req.RequestMode.Mode,
                                                 AssetId = req.AssetId,
                                                 AssetCode = req.Asset.AssetCode,
                                                 ClientId = req.ClientId,
                                                 ClientName = req.Client.ClientName,
                                                 RequestSubCategoryId = req.RequestSubCategoryId,
                                                 RequestSubCategoryName = req.RequestSubCategory.SubCategoryName,
                                                 ProjectId = req.ProjectId,
                                                 ProjectName = req.Project.ProjectName,
                                                 RequestStatusId = req.RequestStatusId,
                                                 RequestStatus = req.RequestStatus.status,
                                                 RequestPeriorityId = req.RequestPeriorityId,
                                                 RequestPeriority = req.RequestPeriority.periorty,
                                                 RequestTypeId = req.RequestTypeId,
                                                 RequestTypeName = req.RequestType.RequestTypeName
                                             }).ToList();
            return requests;
        }
}
}

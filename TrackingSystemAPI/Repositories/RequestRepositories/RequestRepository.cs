﻿using Microsoft.EntityFrameworkCore;
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
        public void Add(RequestDTO requestDTO)
        {
            Request request = new Request();
            request.RequestName = requestDTO.RequestName;
            request.RequestCode = requestDTO.RequestCode;
            request.Description = requestDTO.Description;
            request.RequestSubCategoryId = requestDTO.RequestSubCategoryId;
            request.ProjectId = requestDTO.ProjectId;
            request.RequestStatusId = requestDTO.RequestStatusId;
            request.RequestPeriorityId = requestDTO.RequestPeriorityId;
            request.RequestTypeId = requestDTO.RequestTypeId;
            _context.requests.Add(request);
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
                                             .Include(r => r.RequestType).Select(req => new RequestDTO
                                             {
                                                 Id = req.Id,
                                                 RequestName = req.RequestName,
                                                 RequestCode = req.RequestCode,
                                                 Description = req.Description,
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
                                     .Include(r => r.RequestType).Where(r => r.Id == id).FirstOrDefault();
            var requestDTO = new RequestDTO
            {
                Id=req.Id,
                RequestName = req.RequestName,
                RequestCode = req.RequestCode,
                Description = req.Description,
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
        request.RequestName = requestDTO.RequestName;
        request.RequestCode = requestDTO.RequestCode;
        request.Description = requestDTO.Description;
        request.RequestSubCategoryId = requestDTO.RequestSubCategoryId;
        request.ProjectId = requestDTO.ProjectId;
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
}
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrackingSystemAPI.DTO;
using TrackingSystemAPI.Models;

namespace TrackingSystemAPI.Repositories.RequestDescriptionRepositories
{
    public class RequestDescriptionRepository : IRequestDescriptionRepository
    {
        private readonly ApplicationDbContext _context;

        public RequestDescriptionRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Add(RequestDescriptionDTO requestDescriptionDTO)
        {
            RequestDescription requestDescription = new RequestDescription();
            requestDescription.Description = requestDescriptionDTO.Description;
            requestDescription.RequestId = requestDescriptionDTO.RequestId;
            requestDescription.UserId = requestDescriptionDTO.UserId;
            _context.requestDescriptions.Add(requestDescription);
        }

        public void Delete(int id)
        {
            RequestDescription requestDescription = Find(id);
            _context.requestDescriptions.Remove(requestDescription);
        }
        public RequestDescription Find(int id)
        {
           return _context.requestDescriptions.Find(id);
        }

        public IEnumerable<RequestDescriptionDTO> GetAll()
        {
            var requestDescription = _context.requestDescriptions
                                     .Include(r => r.Request).Include(r => r.User)
                                     .Select(req => new RequestDescriptionDTO
            {
                Id = req.Id,
                Description = req.Description,
                RequestId = req.RequestId,
                RequestName = req.Request.RequestName,
                UserId = req.UserId,
                UserName = req.User.UserName
            }).ToList();
            return requestDescription;
        }

        public RequestDescriptionDTO GetById(int id)
        {
            var req = _context.requestDescriptions.Where(r => r.Id == id).Include(r => r.Request).Include(r => r.User).FirstOrDefault();
            var requestDescriptionDTO = new RequestDescriptionDTO
                          {
                              Id = req.Id,
                              Description = req.Description,
                              RequestId = req.RequestId,
                              RequestName = req.Request.RequestName,
                              UserId = req.UserId,
                              UserName = req.User.UserName
                          };
            return requestDescriptionDTO;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(RequestDescriptionDTO requestDescriptionDTO)
        {
            RequestDescription requestDescription = new RequestDescription();
            requestDescription.Description = requestDescriptionDTO.Description;
            requestDescription.RequestId = requestDescriptionDTO.RequestId;
            requestDescription.UserId = requestDescriptionDTO.UserId;
            _context.Entry(requestDescription).State = EntityState.Modified;
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

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrackingSystemAPI.DTO;
using TrackingSystemAPI.Models;

namespace TrackingSystemAPI.Repositories.RequestImageRepositories
{
    public class RequestImageRepositories : IRequestImageRepositories
    {
        private readonly ApplicationDbContext _context;
        public RequestImageRepositories(ApplicationDbContext context)
        {
            _context = context;
        }
       

        public void Add(List<RequestImageDTO> requestImageDTOs)
        {

            foreach (var item in requestImageDTOs)
            {
                requestImages requestImages = new requestImages();
                requestImages.Id = item.Id;
                requestImages.requestId = item.requestId;
                requestImages.imageName = item.imageName;
             
                _context.Add(requestImages);
            }

        }
        IEnumerable<requestImages> IRequestImageRepositories.GetAll()
        {
            return _context.requestImages.ToList();

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

        public void Save()
        {
            _context.SaveChanges();

        }

        public requestImages GetById(int id)
        {
            return _context.requestImages.Where(a => a.Id == id).FirstOrDefault();

        }

        public requestImages Find(int id)
        {
            return _context.requestImages.Find(id);

        }

        public IEnumerable<RequestImageDTO> GetRequestImageByRequestId(int requestID)
        {
            var requestImage = _context.requestImages.Where(d => d.requestId == requestID).Select(requestImage =>
                new RequestImageDTO()
                {
                   Id=requestImage.Id,
                   imageName=requestImage.imageName,
                   requestId=requestImage.requestId
                }).ToList();
            return requestImage;
        }
    }
}

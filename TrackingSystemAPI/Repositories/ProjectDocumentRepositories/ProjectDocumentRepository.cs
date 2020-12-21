using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrackingSystemAPI.DTO;
using TrackingSystemAPI.Models;

namespace TrackingSystemAPI.Repositories.ProjectDocumentRepositories
{
    public class ProjectDocumentRepository : IProjectDocumentRepository
    {
        private readonly ApplicationDbContext _context;
        public ProjectDocumentRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Add(ProjectDocument projectDocument)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
        public ProjectDocument Find(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProjectDocumentDTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public ProjectDocumentDTO GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(ProjectDocument projectDocument)
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

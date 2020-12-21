using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrackingSystemAPI.Models;

namespace TrackingSystemAPI.Repositories.ProjectPositionRepositories
{
    public class ProjectPositionRepository : IProjectPositionRepository
    {
        private readonly ApplicationDbContext _context;
        public ProjectPositionRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Add(ProjectPosition projectPosition)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
        public ProjectPosition Find(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProjectPosition> GetAll()
        {
            throw new NotImplementedException();
        }

        public ProjectPosition GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(ProjectPosition projectPosition)
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

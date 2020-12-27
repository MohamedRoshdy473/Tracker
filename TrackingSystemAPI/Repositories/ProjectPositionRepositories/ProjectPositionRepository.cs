using Microsoft.EntityFrameworkCore;
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
            _context.projectPositions.Add(projectPosition);
        }

        public void Delete(int id)
        {
            ProjectPosition projectPosition = Find(id);
            _context.projectPositions.Remove(projectPosition);
        }
        public ProjectPosition Find(int id)
        {
           return _context.projectPositions.Find(id);
        }

        public IEnumerable<ProjectPosition> GetAll()
        {
           return _context.projectPositions.ToList();
        }

        public ProjectPosition GetById(int id)
        {
            return _context.projectPositions.Where(p => p.Id == id).FirstOrDefault();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(ProjectPosition projectPosition)
        {
            _context.Entry(projectPosition).State = EntityState.Modified;
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

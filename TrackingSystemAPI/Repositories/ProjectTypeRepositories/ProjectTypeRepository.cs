using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrackingSystemAPI.Models;

namespace TrackingSystemAPI.Repositories.ProjectTypeRepositories
{

    public class ProjectTypeRepository : IProjectTypeRepository
    {
        private readonly ApplicationDbContext _context;
        public ProjectTypeRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Add(ProjectType projectType)
        {
            _context.projectTypes.Add(projectType);
        }

        public void Delete(int id)
        {
            ProjectType projectType = Find(id);
            _context.projectTypes.Remove(projectType);
        }

        public ProjectType Find(int id)
        {
            return _context.projectTypes.Find(id);
        }

        public IEnumerable<ProjectType> GetAll()
        {
            return _context.projectTypes.ToList();
        }

        public ProjectType GetById(int id)
        {
            ProjectType projectType = _context.projectTypes.Where(o => o.Id == id).FirstOrDefault();
            return projectType;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(ProjectType projectType)
        {
            _context.Entry(projectType).State = EntityState.Modified;
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

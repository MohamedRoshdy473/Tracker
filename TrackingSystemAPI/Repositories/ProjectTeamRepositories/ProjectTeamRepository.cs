using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrackingSystemAPI.DTO;
using TrackingSystemAPI.Models;

namespace TrackingSystemAPI.Repositories.ProjectTeamRepositories
{
    public class ProjectTeamRepository : IProjectTeamRepository
    {
        private readonly ApplicationDbContext _context;
        public ProjectTeamRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Add(ProjectTeam projectTeam)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
        public ProjectTeam Find(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProjectTeamDTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public ProjectTeamDTO GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(ProjectTeam projectTeam)
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

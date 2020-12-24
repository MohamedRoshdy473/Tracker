using Microsoft.EntityFrameworkCore;
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
        public void Add(ProjectDocumentDTO projectDocumentDTO)
        {
            ProjectDocument projectDocument = new ProjectDocument();
            projectDocument.Id = projectDocumentDTO.Id;
            projectDocument.ProjectId = projectDocumentDTO.ProjectId;
            projectDocument.Description = projectDocumentDTO.Description;
            _context.Add(projectDocument);    
        }

        public void Delete(int id)
        {
            ProjectDocument projectDocument = Find(id);
        }
        public ProjectDocument Find(int id)
        {
            return _context.projectDocuments.Find(id);
        }

        public IEnumerable<ProjectDocumentDTO> GetAll()
        {
            var ProjectDocuments = _context.projectDocuments.Select(e => new ProjectDocumentDTO
            {
                Id = e.Id,
                ProjectId = e.ProjectId,
                Description = e.Description
                
            }).ToList();
            return ProjectDocuments;
        }

        public ProjectDocumentDTO GetById(int id)
        {
            var projectDocument = _context.projectDocuments.Include(d => d.Project).FirstOrDefault(d => d.Id == id);
            var projectDocumentDTO = new ProjectDocumentDTO()
            {
                Id = projectDocument.Id,
                Description= projectDocument.Description,
                ProjectId=projectDocument.ProjectId,
                ProjectName = projectDocument.Project.ProjectName
            };
            return projectDocumentDTO;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(ProjectDocumentDTO projectDocumentDTO)
        {
            ProjectDocument projectDocument = new ProjectDocument();
            projectDocument.Id = projectDocumentDTO.Id;
            projectDocument.ProjectId = projectDocumentDTO.ProjectId;
            projectDocument.Description = projectDocumentDTO.Description;
            _context.Entry(projectDocument).State = EntityState.Modified;
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

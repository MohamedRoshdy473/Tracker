using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrackingSystemAPI.DTO;
using TrackingSystemAPI.Models;

namespace TrackingSystemAPI.Repositories.ProjectDocumentRepositories
{
    public interface IProjectDocumentRepository : IDisposable
    {
        IEnumerable<ProjectDocumentDTO> GetAll();
        ProjectDocumentDTO GetById(int id);
        ProjectDocument Find(int id);
        void Add(ProjectDocumentDTO projectDocumentDTO);
        void Update(ProjectDocumentDTO projectDocumentDTO);
        void Delete(int id);
        void Save();
    }
}

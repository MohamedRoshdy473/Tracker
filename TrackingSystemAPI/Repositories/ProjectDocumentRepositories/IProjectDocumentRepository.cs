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
        IEnumerable<ProjectDocumentDTO> GetProjectDocumentsByProjectId(int ProjectId);
        void UpdateByProjectId(int ProjectId, List<ProjectDocumentDTO> projectDocumentDTOs);

        ProjectDocument Find(int id);
        void Add(List<ProjectDocumentDTO> projectDocumentDTO);
        void Update(ProjectDocumentDTO projectDocumentDTO);
        void Delete(int id);
        void Save();
    }
}

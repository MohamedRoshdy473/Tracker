using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrackingSystemAPI.DTO;
using TrackingSystemAPI.Models;

namespace TrackingSystemAPI.Repositories.ProjectDocumentRepositories
{
    interface IProjectDocumentRepository : IDisposable
    {
        IEnumerable<ProjectDocumentDTO> GetAll();
        ProjectDocumentDTO GetById(int id);
        ProjectDocument Find(int id);
        void Add(ProjectDocument projectDocument);
        void Update(ProjectDocument  projectDocument);
        void Delete(int id);
        void Save();
    }
}

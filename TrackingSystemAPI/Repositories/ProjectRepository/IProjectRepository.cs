using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrackingSystemAPI.DTO;
using TrackingSystemAPI.Models;

namespace TrackingSystemAPI.Repositories.ProjectRepository
{
   public interface IProjectRepository : IDisposable
    {
        IEnumerable<ProjectDTO> GetAll();
        Project GetById(int id);
        Project Find(int id);
        void Add(Project project);
        void Update(Project project);
        void Delete(int id);
        void Save();
    }
}

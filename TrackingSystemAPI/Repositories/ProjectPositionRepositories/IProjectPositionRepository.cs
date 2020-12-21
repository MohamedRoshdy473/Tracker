using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrackingSystemAPI.Models;

namespace TrackingSystemAPI.Repositories.ProjectPositionRepositories
{
  public interface IProjectPositionRepository : IDisposable
    {
        IEnumerable<ProjectPosition> GetAll();
        ProjectPosition GetById(int id);
        ProjectPosition Find(int id);
        void Add(ProjectPosition projectPosition);
        void Update(ProjectPosition projectPosition);
        void Delete(int id);
        void Save();
    }
}

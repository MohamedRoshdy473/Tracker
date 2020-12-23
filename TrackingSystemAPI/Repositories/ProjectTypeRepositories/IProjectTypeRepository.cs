using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrackingSystemAPI.Models;

namespace TrackingSystemAPI.Repositories.ProjectTypeRepositories
{
   public interface IProjectTypeRepository : IDisposable
    {
        IEnumerable<ProjectType> GetAll();
        ProjectType GetById(int id);
        ProjectType Find(int id);
        void Add(ProjectType projectType);
        void Update(ProjectType projectType);
        void Delete(int id);
        void Save();
    }

}

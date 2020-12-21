using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrackingSystemAPI.DTO;
using TrackingSystemAPI.Models;

namespace TrackingSystemAPI.Repositories.ProjectTeamRepositories
{
   public interface IProjectTeamRepository : IDisposable
    {
        IEnumerable<ProjectTeamDTO> GetAll();
        ProjectTeamDTO GetById(int id);
        ProjectTeam Find(int id);
        void Add(ProjectTeam projectTeam);
        void Update(ProjectTeam projectTeam);
        void Delete(int id);
        void Save();
    }
}

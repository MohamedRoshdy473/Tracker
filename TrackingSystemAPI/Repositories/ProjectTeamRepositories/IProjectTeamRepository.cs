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
        IEnumerable<ProjectTeamDTO> GetProjectTeamsByProjectId(int ProjectId);
        ProjectTeam Find(int id);
        void Add(List<ProjectTeamDTO> projectTeamDTO);
        void Update(ProjectTeamDTO projectTeamDTO);
        void Delete(int id);
        void Save();
    }
}

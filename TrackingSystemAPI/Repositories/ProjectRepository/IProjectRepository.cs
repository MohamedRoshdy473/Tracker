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
        ProjectDTO GetById(int id);
        IEnumerable<ProjectDTO> GetProjectsByClientId(int ClientId);
        IEnumerable<ProjectDTO> GetClientsByEmployeeId(int EmployeeId);
        IEnumerable<ClientDTO> GetClientByProjectId(int ProjectId);
        IEnumerable<ProjectDTO> GetAllProjectsByEmployeeId(int EmployeeId);
        Project Find(int id);
        int Add(ProjectDTO projectDTO);
        void Update(ProjectDTO projectDTO);
        void SoftDelete(ProjectDTO projectDTO);
        void Save();

    }
}

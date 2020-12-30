using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrackingSystemAPI.DTO;
using TrackingSystemAPI.Models;

namespace TrackingSystemAPI.Repositories.StackeholdersRepositories
{
   public interface IStackeholdersRepository : IDisposable
    {
        IEnumerable<StackeholdersDTO> GetAll();
        StackeholdersDTO GetById(int id);
        IEnumerable<StackeholdersDTO> GetStackeholdersByProjectId(int ProjectId);
        void UpdateByProjectId(int ProjectId, List<StackeholdersDTO> stackeholdersDTO);
        Stackeholders Find(int id);
        void Add(List<StackeholdersDTO> stackeholdersDTO);
        void Update(StackeholdersDTO stackeholdersDTO);
        void Delete(int id);
        void Save();
    }
}

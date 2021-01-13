using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrackingSystemAPI.DTO;
using TrackingSystemAPI.Models;

namespace TrackingSystemAPI.Repositories.RequestProblemsRepositories
{
   public interface IRequestProblemRepository : IDisposable
    {
        IEnumerable<RequestProblemsDTO> GetAll();
        RequestProblemsDTO GetById(int id);
        IEnumerable<RequestProblemsDTO> GetAllRequestByRequestProblemId(int RequestProblemId);
        RequestProblems Find(int id);
        void Add(RequestProblems requestProblems);
        void Update(RequestProblems requestProblems);
        void Delete(int id);
        void Save();
    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrackingSystemAPI.DTO;
using TrackingSystemAPI.Models;

namespace TrackingSystemAPI.Repositories.RequestProblemsRepositories
{
    public class RequestProblemRepository : IRequestProblemRepository
    {
        private readonly ApplicationDbContext _context;

        public RequestProblemRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Add(RequestProblems requestProblems)
        {
            _context.requestProblems.Add(requestProblems);
        }

        public void Delete(int id)
        {
            RequestProblems requestProblems = Find(id);
            _context.requestProblems.Remove(requestProblems);
        }
        public RequestProblems Find(int id)
        {
            return _context.requestProblems.Find(id);
        }

        public IEnumerable<RequestProblemsDTO> GetAll()
        {
            var requestProblems = _context.requestProblems.Include(r => r.Request).Select(reqProblem => new RequestProblemsDTO
            {
                Id = reqProblem.Id,
                RequestId=reqProblem.RequestId,
                RequestName=reqProblem.Request.RequestName,
                ProblemId = reqProblem.ProblemId,
                ProblemName = reqProblem.Problems.ProblemName

            }).ToList();
            return requestProblems;
        }

        public RequestProblemsDTO GetById(int id)
        {
            var requestProblems = _context.requestProblems.Include(r => r.Request).Where(r => r.Id == id).Select(reqProblem => new RequestProblemsDTO
            {
                Id = reqProblem.Id,
                RequestId = reqProblem.RequestId,
                RequestName = reqProblem.Request.RequestName,
                ProblemId = reqProblem.ProblemId,
                ProblemName = reqProblem.Problems.ProblemName

            }).FirstOrDefault();
            return requestProblems;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(RequestProblems requestProblems)
        {
            _context.Entry(requestProblems).State = EntityState.Modified;
        }
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public IEnumerable<RequestProblemsDTO> GetAllRequestByRequestProblemId(int RequestProblemId)
        {
            var requestsByProblemId = _context.requestProblems.Where(r => r.Id == RequestProblemId)
                .Include(r => r.Request.ProjectTeam).Include(r => r.Request.RequestPeriority)
                                             .Include(r => r.Request.RequestStatus).Include(r => r.Request.RequestSubCategory)
                                             .Include(r => r.Request.RequestMode)
                                             .Include(r => r.Request.Asset).Include(r => r.Request)
                                             .Select(reqProblem => new RequestProblemsDTO
            {
                Id = reqProblem.Id,
                ProblemId = reqProblem.ProblemId,
                ProblemName = reqProblem.Problems.ProblemName,
                RequestId = reqProblem.RequestId,
                IsSolved = reqProblem.Request.IsSolved,
                IsAssigned = reqProblem.Request.IsAssigned,
                RequestName = reqProblem.Request.RequestName,
                RequestCode = reqProblem.Request.RequestCode,
                Description = reqProblem.Request.Description,
                RequestDate = reqProblem.Request.RequestDate,
                RequestTime = (reqProblem.Request.RequestTime).ToString(),
                RequestModeId = reqProblem.Request.RequestModeId,
                RequestMode = reqProblem.Request.RequestMode.Mode,
                AssetId = reqProblem.Request.AssetId,
                AssetCode = reqProblem.Request.Asset.AssetCode,
                ClientId = reqProblem.Request.ClientId,
                ClientName = reqProblem.Request.Client.ClientName,
                RequestSubCategoryId = reqProblem.Request.RequestSubCategoryId,
                RequestSubCategoryName = reqProblem.Request.RequestSubCategory.SubCategoryName,
                ProjectTeamId = reqProblem.Request.ProjectTeamId,
                ProjectName = reqProblem.Request.ProjectTeam.Project.ProjectName,
                TeamName = reqProblem.Request.ProjectTeam.Team.Name,
                RequestStatusId = reqProblem.Request.RequestStatusId,
                RequestStatus = reqProblem.Request.RequestStatus.status,
                RequestPeriorityId = reqProblem.Request.RequestPeriorityId,
                RequestPeriority = reqProblem.Request.RequestPeriority.periorty,
            }).ToList();
            return requestsByProblemId;
        }
    }
}

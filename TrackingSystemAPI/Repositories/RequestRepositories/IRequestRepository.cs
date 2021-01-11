﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrackingSystemAPI.DTO;
using TrackingSystemAPI.Models;

namespace TrackingSystemAPI.Repositories.RequestRepositories
{
   public interface IRequestRepository : IDisposable
    {
        IEnumerable<RequestDTO> GetAll();
        RequestDTO GetById(int id);
        IEnumerable<RequestDTO> GetProjectTeamsByProjectId(int ProjectId);
        IEnumerable<RequestDTO> GetAllRequestByClientId(int ClientId);
        List<RequestDTO> GetAllRequestByProjectTeamId(ProjectTeamVM model);
        Request Find(int id);
        int Add(RequestDTO requestDTO);
        void Update(RequestDTO requestDTO);
        void Delete(int id);
        void Save();
    }
}

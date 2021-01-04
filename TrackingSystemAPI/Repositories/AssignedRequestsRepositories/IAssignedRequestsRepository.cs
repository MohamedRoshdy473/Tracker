﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrackingSystemAPI.DTO;
using TrackingSystemAPI.Models;

namespace TrackingSystemAPI.Repositories.AssignedRequestsRepositories
{
    public interface IAssignedRequestsRepository : IDisposable
    {
        IEnumerable<AssignedRequestsDTO> GetAll();
        AssignedRequestsDTO GetById(int id);
        AssignedRequests Find(int id);
        void Add(AssignedRequestsDTO assignedRequestsDTO);
        void Update(AssignedRequestsDTO assignedRequestsDTO);
        void Delete(int id);
        void Save();
    }
}

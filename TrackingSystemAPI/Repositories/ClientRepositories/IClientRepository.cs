﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrackingSystemAPI.DTO;
using TrackingSystemAPI.Models;

namespace TrackingSystemAPI.Repositories.ClientRepositories
{
    public interface IClientRepository: IDisposable
    {
        IEnumerable<ClientDTO> GetAll();
        ClientDTO GetById(int id);
        Client Find(int id);
        void Add(ClientDTO client);
        void Update(ClientDTO client);
        void Delete(int id);
        void Save();
    }
}

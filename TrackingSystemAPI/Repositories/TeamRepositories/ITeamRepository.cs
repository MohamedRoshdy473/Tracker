using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrackingSystemAPI.DTO;
using TrackingSystemAPI.Models;

namespace TrackingSystemAPI.Repositories.TeamRepositories
{
    public interface ITeamRepository
    {
        IEnumerable<Team> GetAll();
        Team GetById(int id);
        Team Find(int id);
        int Add(TeamDTO team);
        void Update(Team team);

        void Save();
    }
}

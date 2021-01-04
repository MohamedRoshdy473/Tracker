using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrackingSystemAPI.DTO;
using TrackingSystemAPI.Models;

namespace TrackingSystemAPI.Repositories.TeamRepositories
{
    public class TeamRepository : ITeamRepository
    {
        private readonly ApplicationDbContext _context;
        public TeamRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public int Add(TeamDTO team)
        {
            Team teamObj = new Team();
            teamObj.Name = team.Name;
            _context.teams.Add(teamObj);
            _context.SaveChanges();
            int Id = teamObj.Id;

            foreach (var item in team.projectTeams)
            {
                ProjectTeam projectTeamObj = new ProjectTeam();
                projectTeamObj.EmployeeId = item.EmployeeId;
                projectTeamObj.ProjectId = item.ProjectId;
                projectTeamObj.DepartmentId = item.DepartmentId;
                projectTeamObj.ProjectPositionId = item.ProjectPositionId;
                projectTeamObj.TeamId = Id;
                _context.projectTeams.Add(projectTeamObj);
                _context.SaveChanges();
            }
            return Id;


        }

        public Team Find(int id)
        {
            return _context.teams.Find(id);

        }

        public IEnumerable<Team> GetAll()
        {
            return _context.teams.ToList();

        }

        public Team GetById(int id)
        {
            return _context.teams.Where(a => a.Id == id).FirstOrDefault();

        }

        public void Save()
        {
            _context.SaveChanges();

        }

        public void Update(Team team)
        {
            _context.Entry(team).State = EntityState.Modified;

        }
    }
}

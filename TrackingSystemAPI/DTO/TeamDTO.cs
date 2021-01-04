using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrackingSystemAPI.DTO
{
    public class TeamDTO
    {
        public int ID { get; set; }

        public string Name { get; set; }
        public List<ProjectTeamDTO> projectTeams { get; set; }
        
    }
}

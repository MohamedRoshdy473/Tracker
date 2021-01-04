using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TrackingSystemAPI.Models
{
    public class AssignedRequests
    {
        public int Id { get; set; }
        public int ProjectPositionId { get; set; }
        [ForeignKey("ProjectPositionId")]
        public virtual ProjectPosition ProjectPosition { get; set; }
        public int ProjectTeamId { get; set; }
        [ForeignKey("ProjectTeamId")]
        public virtual ProjectTeam ProjectTeam { get; set; }
        public int RequestId { get; set; }
        [ForeignKey("RequestId")]
        public virtual Request Request { get; set; }

    }
}

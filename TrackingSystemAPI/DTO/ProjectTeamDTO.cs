using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrackingSystemAPI.DTO
{
    public class ProjectTeamDTO
    {
        public int ID { get; set; }
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public int ProjectId { get; set; }
        public string  ProjectName { get; set; }
        public int DepartmentId { get; set; }
        public string  DepartmentName { get; set; }
        public int ProjectPositionId { get; set; }
        public string ProjectPositionName { get; set; }
    }
}

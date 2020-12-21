using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrackingSystemAPI.DTO
{
    public class ProjectDTO
    {
        public int Id { get; set; }
        public string ProjectName { get; set; }
        public string ProjectCode { get; set; }
        public string Type { get; set; }
        public decimal Cost { get; set; }
        public int ProjectPeriod { get; set; }
        public DateTime PlanndedStartDate { get; set; }
        public DateTime ActualStartDate { get; set; }
        public DateTime PlanndedEndDate { get; set; }
        public DateTime ActualEndDate { get; set; }
        public string Description { get; set; }
        public int OrganizationId { get; set; }
        public string OrganizationName { get; set; }
        public int EmployeeId { get; set; }
        public string  EmployeeName { get; set; }
        public int ClientId { get; set; }
        public string  ClientName { get; set; }
    }
}

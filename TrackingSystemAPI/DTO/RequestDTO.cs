using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrackingSystemAPI.DTO
{
    public class RequestDTO
    {
        public int Id { get; set; }
        public string RequestName { get; set; }
        public string RequestCode { get; set; }
        public string Photo { get; set; }
        public string Description { get; set; }
        public DateTime RequestDate { get; set; }
        public string RequestTime { get; set; }
        public int RequestSubCategoryId { get; set; }
        public string  RequestSubCategoryName { get; set; }
        public int ClientId { get; set; }
        public string ClientName { get; set; }
        public int ProjectId { get; set; }
        public string  ProjectName { get; set; }
        public int RequestModeId { get; set; }
        public string RequestMode { get; set; }
        public int AssetId { get; set; }
        public string AssetCode { get; set; }
        public int RequestStatusId { get; set; }
        public string RequestStatus { get; set; }
        public int RequestPeriorityId { get; set; }
        public string RequestPeriority { get; set; }
        public int RequestTypeId { get; set; }
        public string RequestTypeName { get; set; }

    }
}

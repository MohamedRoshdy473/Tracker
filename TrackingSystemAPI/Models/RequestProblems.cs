﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TrackingSystemAPI.Models
{
    public class RequestProblems
    {
        public int Id { get; set; }
        public int ProblemId { get; set; }
       
        [ForeignKey("ProblemId")]
        public virtual Problems Problems { get; set; }
        public int RequestId { get; set; }

        [ForeignKey("RequestId")]
        public virtual Request Request { get; set; }
    }
}

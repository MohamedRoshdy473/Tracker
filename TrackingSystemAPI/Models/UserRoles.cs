﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrackingSystemAPI.Models
{
    public static class UserRoles
    {
        public const string SuperAdmin = "SuperAdmin"; //All Permission
        public const string Admin = "Admin"; //View Only
        public const string PMO = "PMO"; //Create Project CRUD
        public const string PM = "PM"; //view Project and can manage more than Project
        public const string TL = "TL"; //assign tickets to members
        public const string Employee = "Employee";
        public const string Client = "Client";
        //public const string User = "User";
    }
}

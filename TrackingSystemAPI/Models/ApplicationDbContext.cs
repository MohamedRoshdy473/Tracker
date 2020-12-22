using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TrackingSystemAPI.DTO;

namespace TrackingSystemAPI.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        //public ApplicationDbContext()
        //{

        //}
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Client> clients { get; set; }
        public DbSet<Department> departments { get; set; }
        public DbSet<MileStone> mileStones  { get; set; }
        public DbSet<Organization> organizations  { get; set; }
        public DbSet<Project> projects { get; set; }
        public DbSet<ProjectDocument>projectDocuments  { get; set; }
        public DbSet<ProjectPosition>projectPositions  { get; set; }
        public DbSet<ProjectTeam>projectTeams  { get; set; }
        public DbSet<Request>requests  { get; set; }
        public DbSet<RequestCategory>requestCategories  { get; set; }
        public DbSet<RequestPeriority>requestPeriorities  { get; set; }
        public DbSet<RequestStatus>requestStatuses  { get; set; }
        public DbSet<RequestSubCategory> requestSubCategories  { get; set; }
        public DbSet<RequestType> requestTypes { get; set; }
        public DbSet<Stackeholders>stackeholders  { get; set; }
        public DbSet<ProjectType> projectTypes { get; set; }












    }
}

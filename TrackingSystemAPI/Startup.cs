using TrackingSystemAPI.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using System.IO;
using TrackingSystemAPI.Repositories.EmployeesRepository;
using TrackingSystemAPI.Repositories.ClientRepositories;
using TrackingSystemAPI.Repositories.DepartmentRepositories;
using TrackingSystemAPI.Repositories.MileStoneRepositories;
using TrackingSystemAPI.Repositories.OrganizationRepositories;
using TrackingSystemAPI.Repositories.ProjectRepository;
using TrackingSystemAPI.Repositories.ProjectDocumentRepositories;
using TrackingSystemAPI.Repositories.ProjectPositionRepositories;
using TrackingSystemAPI.Repositories.ProjectTeamRepositories;
using TrackingSystemAPI.Repositories.RequestCategoryRepositories;
using TrackingSystemAPI.Repositories.RequestPeriorityRepositories;
using TrackingSystemAPI.Repositories.RequestRepositories;
using TrackingSystemAPI.Repositories.RequestStatusRepositories;
using TrackingSystemAPI.Repositories.RequestSubCategoryRepositories;
using TrackingSystemAPI.Repositories.RequestTypeRepositories;
using TrackingSystemAPI.Repositories.StackeholdersRepositories;
using Microsoft.AspNetCore.Http.Features;
using TrackingSystemAPI.Repositories.AssetRepositories;
using TrackingSystemAPI.Repositories.RequestModeRepositories;
using TrackingSystemAPI.Repositories.RequestImageRepositories;
using TrackingSystemAPI.Repositories.TeamRepositories;

namespace TrackingSystemAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public object JwtBearerDefaults { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        [System.Obsolete]
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDirectoryBrowser();
            services.AddHttpContextAccessor();
            services.AddCors();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddControllers();

            // For Entity Framework  
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("ConnStr")));
            //services.AddScoped<IEmployee, EmployeeService>();
            // For Identity  
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            services.AddScoped<IMileStoneRepository,MileStoneRepository>();
            services.AddScoped<IOrganizationRepository, OrganizationRepository>();
            services.AddScoped<IProjectDocumentRepository, ProjectDocumentRepository>();
            services.AddScoped<IProjectRepository, ProjectRepository>();
            services.AddScoped<IProjectPositionRepository, ProjectPositionRepository>();
            services.AddScoped<IProjectTeamRepository, ProjectTeamRepository>();
            services.AddScoped<IRequestCategoryRepository, RequestCategoryRepository>();
            services.AddScoped<IRequestPeriorityRepository, RequestPeriorityRepository>();
            services.AddScoped<IRequestRepository, RequestRepository>();
            services.AddScoped<IRequestStatusRepository, RequestStatusRepository>();
            services.AddScoped<IRequestSubCategoryRepository, RequestSubCategoryRepository>();
            services.AddScoped<IRequestTypeRepository, RequestTypeRepository>();
            services.AddScoped<IStackeholdersRepository, StackeholdersRepository>();
            services.AddScoped<IAssetRepository, AssetRepository>();
            services.AddScoped<IRequestModeRepository, RequestModeRepository>();
            services.AddScoped<IRequestImageRepositories, RequestImageRepositories>();
            services.AddScoped<ITeamRepository, TeamRepository>();


            // Adding Authentication  
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme;
            })

            // Adding Jwt Bearer  
            .AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = Configuration["JWT:ValidAudience"],
                    ValidIssuer = Configuration["JWT:ValidIssuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:Secret"]))
                };
            });
            services.Configure<FormOptions>(o => {
                o.ValueLengthLimit = int.MaxValue;
                o.MultipartBodyLengthLimit = int.MaxValue;
                o.MemoryBufferThreshold = int.MaxValue;
            });
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors(
             //options => options.WithOrigins("http://localhost:4200.com").AllowAnyMethod()
             options=>options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()
           );
            app.UseStaticFiles(); // For the wwwroot folder.

           
            app.UseFileServer(new FileServerOptions
            {
                FileProvider = new PhysicalFileProvider(
                    Path.Combine(env.ContentRootPath, "wwwroot")),
                RequestPath = "/wwwroot",
                EnableDirectoryBrowsing = true
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

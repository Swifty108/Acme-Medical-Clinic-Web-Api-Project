using Apartments.BLL.HelperClasses;
using Apartments.DAL.Data;
using Apartments.DAL.Interfaces;
using AutoMapper;
using MediatR;
using MedicalClinicWebApi.BLL;
using MedicalClinicWebApi.BLL.Interfaces;
using MedicalClinicWebApi.Common.Interfaces;
using MedicalClinicWebApi.Common.Services;
using MedicalClinicWebApi.DAL.Data;
using MedicalClinicWebApi.DAL.Identity;
using MedicalClinicWebApi.DAL.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MedicalClinicWebApi.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")),
                    ServiceLifetime.Transient
                    );
            services.AddIdentity<AppUser, IdentityRole>(options =>
            {
                options.SignIn.RequireConfirmedAccount = false;
                options.SignIn.RequireConfirmedEmail = false;
                options.SignIn.RequireConfirmedPhoneNumber = false;
                options.User.RequireUniqueEmail = true;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
            })

            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders()
            .AddDefaultUI()
            .AddRoles<IdentityRole>();

            services.AddIdentityCore<Employee>()
            .AddRoles<IdentityRole>()
            .AddClaimsPrincipalFactory<UserClaimsPrincipalFactory<Employee, IdentityRole>>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders()
            .AddDefaultUI();

            services.AddIdentityCore<Patient>()
            .AddRoles<IdentityRole>()
            .AddClaimsPrincipalFactory<UserClaimsPrincipalFactory<Patient, IdentityRole>>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders()
            .AddDefaultUI();

            services.AddControllers();
            services.AddAutoMapper(c => c.AddProfile<AutoMappingProfile>(), typeof(Startup));
            services.AddTransient<IDbInitializer, DbInitializer>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IAccountLogic, AccountLogic>();
            services.AddTransient<IRecordsLogic, RecordsLogic>();
            services.AddTransient<IAppointmentsLogic, AppointmentsLogic>();
            services.AddTransient<ILabOrdersLogic, LabOrersLogic>();
            services.AddTransient<ILabResultsLogic, LabResultsLogic>();

            services.AddMediatR(typeof(Startup));
            services.AddHttpContextAccessor();

            services.AddControllers().AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.AddAuthentication()
                .AddCookie()
                .AddJwtBearer();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

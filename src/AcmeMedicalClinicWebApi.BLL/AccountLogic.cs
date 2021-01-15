
using AcmeMedicalClinicWebApi.BLL.Interfaces;
using AcmeMedicalClinicWebApi.BLL.Models;
using AcmeMedicalClinicWebApi.DAL.Identity;
using AcmeMedicalClinicWebApi.DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

namespace AcmeMedicalClinicWebApi.BLL
{
    public class AccountLogic : IAccountLogic
    {
        private readonly UserManager<AppUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IConfiguration _configuration;
        public AccountLogic(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            _configuration = configuration;
        }
        public async Task<IdentityResult> RegisterEmployee(RegisterEmployeeModel model)
        {
            Employee user = new Employee()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.UserName,
                FirstName = model.FirstName,
                LastName = model.LastName,
                StreetAddress = model.StreetAddress,
                City = model.City,
                State = model.State,
                Zipcode = model.Zipcode,
                Department = model.Department
            };

            var result = await userManager.CreateAsync(user, model.Password);

            return result;
        }

        public async Task<IdentityResult> RegisterPatient(RegisterPatientModel model)
        {
            Patient user = new Patient()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.UserName,
                FirstName = model.FirstName,
                LastName = model.LastName,
                StreetAddress = model.StreetAddress,
                City = model.City,
                State = model.State,
                Zipcode = model.Zipcode,
                InsuranceName = model.InsuranceName,
                InsuranceNumber = model.InsuranceNumber
            };

            var result = await userManager.CreateAsync(user, model.Password);

            return result;
        }
    }
}


using MedicalClinicWebApi.BLL.Interfaces;
using MedicalClinicWebApi.BLL.Models;
using MedicalClinicWebApi.DAL.Identity;
using MedicalClinicWebApi.DAL.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;

namespace MedicalClinicWebApi.BLL
{
    public class AccountLogic : IAccountLogic
    {
        private readonly UserManager<AppUser> _userManager;

        public AccountLogic(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
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
                PhoneNumber = model.PhoneNumber,
                Department = model.Department
            };

            var result = await _userManager.CreateAsync(user, model.Password);
            await _userManager.AddToRoleAsync(user, "Employee");

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
                PhoneNumber = model.PhoneNumber,
                InsuranceName = model.InsuranceName,
                InsuranceNumber = model.InsuranceNumber
            };

            var result = await _userManager.CreateAsync(user, model.Password);
            await _userManager.AddToRoleAsync(user, "Patient");

            return result;
        }
    }
}

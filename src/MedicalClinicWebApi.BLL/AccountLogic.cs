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

        public async Task<string> RegisterEmployee(RegisterEmployeeModel model)
        {
            Employee user = new Employee()
            {
                UserName = model.UserName,
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                FirstName = model.FirstName,
                LastName = model.LastName,
                StreetAddress = model.StreetAddress,
                City = model.City,
                State = model.State,
                Zipcode = model.Zipcode,
                PhoneNumber = model.PhoneNumber,
                Department = model.Department
            };

            try
            {
                await _userManager.CreateAsync(user, model.Password);
                await _userManager.AddToRoleAsync(user, "Employee");
                var userId = await _userManager.GetUserIdAsync(user);

                return userId;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<string> RegisterPatient(RegisterPatientModel model)
        {
            Patient user = new Patient()
            {
                UserName = model.UserName,
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
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

            try
            {
                await _userManager.CreateAsync(user, model.Password);
                await _userManager.AddToRoleAsync(user, "Patient");
                var userId = await _userManager.GetUserIdAsync(user);

                return userId;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
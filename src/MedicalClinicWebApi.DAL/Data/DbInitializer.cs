using Apartments.DAL.Interfaces;
using MedicalClinicWebApi.DAL.Identity;
using MedicalClinicWebApi.DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalClinicWebApi.DAL.Data
{
    public class DbInitializer : IDbInitializer
    {
        private readonly IServiceScopeFactory _scopeFactory;
        private IList<AppUser> _appUsers;

        public DbInitializer(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
            _appUsers = new List<AppUser> {
            new Employee
                            {
                                UserName = "john.doe@employee.com",
                                Email = "john.doe@employee.com",
                                FirstName = "John",
                                LastName = "Doe",
                                StreetAddress = "123 Ronan Street",
                                City = "Atlanta",
                                State = "Georgia",
                                Zipcode = "77777",
                                PhoneNumber = "777-777-7777",
                                Department = "Nephrology"
   
                            },
            new Patient
                            {

                                UserName = "emily.smith@patient.com",
                                Email = "emily.smith@patient.com",
                                FirstName = "Emily",
                                LastName = "Smith",
                                StreetAddress = "456 Planter Street",
                                City = "Atlanta",
                                State = "Georgia",
                                Zipcode = "88888",
                                PhoneNumber = "888-888-8888",
                                InsuranceName = "HBCBS",
                                InsuranceNumber = "FCM437343437"
                            }
            };
        }

        public void Initialize()
        {
            using (var serviceScope = _scopeFactory.CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>())
                {
                    context.Database.Migrate();        
                }
            }
        }

        public async Task SeedData()
        {
            await CreateRoles();
            await CreateUsers(_appUsers);
        }

        public async Task CreateRoles()
        {
            using (var serviceScope = _scopeFactory.CreateScope())
            {
                using (var roleManager = serviceScope.ServiceProvider.GetService<RoleManager<IdentityRole>>())
                {
                    if (!roleManager.Roles.Any())
                    {
                        if (!await roleManager.RoleExistsAsync
                    ("Employee"))
                        {
                            IdentityRole role = new IdentityRole();
                            role.Name = "Employee";
                            IdentityResult roleResult = await roleManager.
                            CreateAsync(role);
                        }

                        if (!await roleManager.RoleExistsAsync
                    ("Patient"))
                        {
                            IdentityRole role = new IdentityRole();
                            role.Name = "Patient";
                            IdentityResult roleResult = await roleManager.
                            CreateAsync(role);
                        }
                    }
                }
            }
        }

        public async Task CreateUsers(IList<AppUser> appUsers)
        {
            using (var serviceScope = _scopeFactory.CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>())
                {
                    using (var userManager = serviceScope.ServiceProvider.GetService<UserManager<AppUser>>())
                    {
                        if (!context.Users.Any())
                        {
                            foreach (var user in appUsers)
                            {
                                IdentityResult result = await userManager.CreateAsync
                                (user, "Med5helix!");

                                if (result.Succeeded)
                                {

                                    if (user.Email.Contains("employee"))
                                    {
                                        await userManager.AddToRoleAsync(user as Employee, "Employee");
                                    }
                                    else if (user.Email.Contains("patient"))
                                    {
                                        await userManager.AddToRoleAsync(user as Patient, "Patient");
                                    }
                                }                          
                            }
                        }
                    }
                }
            }
        }
    }
}
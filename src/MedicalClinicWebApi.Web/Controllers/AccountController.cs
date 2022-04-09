using MedicalClinicWebApi.BLL.Interfaces;
using MedicalClinicWebApi.BLL.Models;
using MedicalClinicWebApi.Common.Interfaces;
using MedicalClinicWebApi.Common.Services;
using MedicalClinicWebApi.DAL.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

//Todo: Implement logging framework

namespace MedicalClinicWebApi.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IAccountLogic _accountLogic;

        public AccountController(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration, IUserService userService, IAccountLogic auth)
        {
            _userService = userService;
            _accountLogic = auth;
        }

        [HttpPost]
        [Route("registeremployee")]
        public async Task<IActionResult> RegisterEmployee([FromBody] RegisterEmployeeModel model)
        {
            var user = await _userService.FindUserByName(model.UserName);

            if (user != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new { Status = "Error", Message = "User already exists!" });
            else
            {
                var userId = await _accountLogic.RegisterEmployee(model);

                return userId != null ? Ok(new { Status = "Success", Message = "Employee account registered successfully!", UserId = userId }) : StatusCode(StatusCodes.Status500InternalServerError, new { Status = "Error", Message = "Employee account registration failed!Please check user details and try again." });
            }
        }

        [HttpPost]
        [Route("registerpatient")]
        public async Task<IActionResult> RegisterPatient([FromBody] RegisterPatientModel model)
        {
            var user = await _userService.FindUserByName(model.UserName);

            if (user != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new { Status = "Error", Message = "User already exists!" });
            else
            {
                var userId = await _accountLogic.RegisterPatient(model);

                return userId != null ? Ok(new { Status = "Success", Message = "Patient account registered successfully!", UserId = userId }) : StatusCode(StatusCodes.Status500InternalServerError, new { Status = "Error", Message = "Patient account registration failed! Please check user details and try again." });
            }
        }
    }
}
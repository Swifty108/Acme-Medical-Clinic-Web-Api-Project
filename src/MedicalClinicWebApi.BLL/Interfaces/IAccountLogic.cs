using MedicalClinicWebApi.BLL.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace MedicalClinicWebApi.BLL.Interfaces
{
    public interface IAccountLogic
    {
        public Task<IdentityResult> RegisterEmployee(RegisterEmployeeModel model);
        public Task<IdentityResult> RegisterPatient(RegisterPatientModel model);
    }
}

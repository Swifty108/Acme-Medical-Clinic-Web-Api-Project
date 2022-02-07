using MedicalClinicWebApi.BLL.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace MedicalClinicWebApi.BLL.Interfaces
{
    public interface IAccountLogic
    {
        public Task<string> RegisterEmployee(RegisterEmployeeModel model);
        public Task<string> RegisterPatient(RegisterPatientModel model);
    }
}

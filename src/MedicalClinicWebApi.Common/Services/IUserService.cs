using MedicalClinicWebApi.DAL.Identity;
using System.Threading.Tasks;

namespace MedicalClinicWebApi.Common.Services
{
    public interface IUserService
    {
        public Task<AppUser> FindUserByName(string userName);
    }
}
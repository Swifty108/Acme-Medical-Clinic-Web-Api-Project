using AcmeMedicalClinicWebApi.DAL.Identity;
using System.Threading.Tasks;

namespace AcmeMedicalClinicWebApi.Common.Services
{
    public interface IUserService
    {
        public Task<AppUser> FindUserByName(string userName);
    }
}
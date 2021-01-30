using MedicalClinicWebApi.DAL.Identity;
using System.Threading.Tasks;

namespace MedicalClinicWebApi.Common.Interfaces
{
    public interface IUserService
    {
        Task<AppUser> FindUserByID(string userId);
        public Task<AppUser> FindUserByName(string userName);
    }
}
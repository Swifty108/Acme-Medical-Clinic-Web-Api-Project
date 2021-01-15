using AcmeMedicalClinicWebApi.DAL.Identity;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace AcmeMedicalClinicWebApi.Common.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<AppUser> userManager;

        public UserService(UserManager<AppUser> userManager)
        {
            this.userManager = userManager;
        }

        public async Task<AppUser> FindUserByName(string userName)
        {
            var user = await userManager.FindByNameAsync(userName);
            return user;
        }
    }
}

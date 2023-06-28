using RevFIT.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevFIT.Services.AuthenticationService
{
    public interface IAuthenticationService
    {
        Task<ServiceResponseModel<int>> Register(APIRegisterViewModel user);
        Task<ServiceResponseModel<string>> Login(string email, string password);
        Task<ServiceResponseModel<bool>> ChangePassword(int userId, string newPassword);
        int GetUserId();
        string GetUserEmail();
        Task<APIUserViewModel> GetUserByEmail(string email);
    }
}

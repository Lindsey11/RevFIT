using RevFit.UI.ViewModels.Auth;

namespace RevFit.UI.Auth
{
    public interface IUIAuthService
    {
        Task<bool> Register(UserRegisterViewModel request);
        Task<string> Login(UserLoginViewModel request);
        //Task<ServiceResponse<bool>> ChangePassword(UserChangePassword request);
        Task<bool> IsUserAuthenticated();
    }
}

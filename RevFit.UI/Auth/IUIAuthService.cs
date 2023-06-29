using RevFit.Client.UI.ViewModels.Auth;

namespace RevFit.Client.UI.Auth
{
    public interface IUIAuthService
    {
        Task<bool> Register(UserRegisterViewModel request);
        Task<string> Login(UIUserLoginViewModel request);
        //Task<ServiceResponse<bool>> ChangePassword(UserChangePassword request);
        Task<bool> IsUserAuthenticated();
    }
}

using Microsoft.AspNetCore.Components.Authorization;
using RevFit.UI.RevFitAPI;
using RevFit.UI.ViewModels.Auth;

namespace RevFit.UI.Auth
{
    public class UIAuthService : IUIAuthService
    {
        private readonly AuthenticationStateProvider _authStateProvider;
        private readonly RevFITAPIClient _apiClient;
        public UIAuthService(RevFITAPIClient revFITAPIClient, AuthenticationStateProvider authenticationStateProvider)
        {
            _apiClient = revFITAPIClient;
            _authStateProvider = authenticationStateProvider;
        }
        public Task<bool> IsUserAuthenticated()
        {
            throw new NotImplementedException();
        }

        public Task<string> Login(UserLoginViewModel request)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Register(UserRegisterViewModel request)
        {
            throw new NotImplementedException();
        }
    }
}

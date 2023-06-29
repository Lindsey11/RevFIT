using Microsoft.AspNetCore.Components.Authorization;
using OpenAPIShared.RevFitAPI;
using RevFit.Client.UI.ViewModels.Auth;

namespace RevFit.Client.UI.Auth
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

        public async Task<string> Login(UIUserLoginViewModel request)
        {
            try
            {
                var result = await _apiClient.AuthLoginAsync(new() { Email = request.Email, Password = request.Password });
                return result.Data;
            }
            catch (Exception error)
            {
                return "";
            }
        }

        public Task<bool> Register(UserRegisterViewModel request)
        {
            throw new NotImplementedException();
        }
    }
}

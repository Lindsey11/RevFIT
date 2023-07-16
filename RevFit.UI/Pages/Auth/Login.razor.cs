using Microsoft.AspNetCore.Components;
using RevFit.Client.UI.ViewModels.Auth;
using Microsoft.AspNetCore.WebUtilities;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using RevFit.Client.UI.Auth;
using System;
using RevFit.Client.UI.Shared;

namespace RevFit.Client.UI.Pages.Auth
{
    public partial class Login : ComponentBase
    {
        private UIUserLoginViewModel user = new UIUserLoginViewModel();
        private string errorMessage = string.Empty;
        private string returnUrl = string.Empty;
        [Inject]
        NavigationManager NavigationManager { get; set; }
        [Inject]
        ILocalStorageService LocalStorage { get; set; }
        [Inject]
        AuthenticationStateProvider AuthenticationStateProvider { get; set; }
        [Inject]
        IUIAuthService AuthService { get; set; }
        private LoadingComponent loadingComponent;
        protected override void OnInitialized()
        {
            var uri = NavigationManager.ToAbsoluteUri(NavigationManager.Uri);
            if (QueryHelpers.ParseQuery(uri.Query).TryGetValue("returnUrl", out var url))
            {
                returnUrl = url;
            }
        }


        private async Task HandleLogin()
        {
            try
            {
                // Show loading
                loadingComponent.ShowLoading();
                var result = await AuthService.Login(user);
                if (!string.IsNullOrEmpty(result))
                {
                    errorMessage = string.Empty;

                    await LocalStorage.SetItemAsync("authToken", result);
                    await AuthenticationStateProvider.GetAuthenticationStateAsync();

                    NavigationManager.NavigateTo(returnUrl);
                }
                else
                {
                    errorMessage = "Error logging in";
                }
                // Hide loading
                loadingComponent.HideLoading();
            }
            catch (Exception error)
            {
                errorMessage = error.Message;
                // Hide loading
                loadingComponent.HideLoading();
            }

        }
    }
}

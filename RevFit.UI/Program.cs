using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using RevFit.UI;
using RevFit.UI.Auth;
using RevFit.UI.RevFitAPI;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
WebAssemblyHostConfiguration cfg = builder.Configuration;

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, RevFitAuthStateProvider>();

HttpClient RevAPI = new();
builder.Services.AddTransient(s => new RevFITAPIClient(cfg["RevFitAPI:Host"], RevAPI));

await builder.Build().RunAsync();

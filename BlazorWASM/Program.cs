using BlazorWASM;
using BlazorWASM.Auth;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using HttpClients.ClientInterfaces;
using HttpClients.ClientImplementations;
using Domain.Auth;
using Radzen;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5284") });

//Auth services
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthProvider>();
builder.Services.AddScoped<IAuthService, AuthService>();
AuthorizationPolicies.AddPolicies(builder.Services);

//HTTP services
builder.Services.AddScoped<ISubPageService, SubPageService>();
builder.Services.AddScoped<IPostService, PostService>();
builder.Services.AddScoped<IUserService, UserService>();

//Radzen services
builder.Services.AddScoped<DialogService>();
builder.Services.AddScoped<NotificationService>();
builder.Services.AddScoped<TooltipService>();
builder.Services.AddScoped<ContextMenuService>();

await builder.Build().RunAsync();

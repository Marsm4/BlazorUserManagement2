using BlazorUserManagement;
using BlazorUserManagement.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:44357/api/") }); // исправленный URL

builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddScoped<UserService>();

await builder.Build().RunAsync();

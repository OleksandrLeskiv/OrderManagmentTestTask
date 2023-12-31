using Blazored.Toast;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using SalesOrderDataManager.Client;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.Services.AddBlazoredToast();
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient {BaseAddress = new Uri("http://localhost:5000")});

await builder.Build().RunAsync();
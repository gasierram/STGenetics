using BlazorApp;
using BlazorApp.Services;
using CurrieTechnologies.Razor.SweetAlert2;
using MatBlazor;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5078/") });
builder.Services.AddScoped<IAnimalService,AnimalService>();
builder.Services.AddSweetAlert2();
builder.Services.AddMatBlazor();

await builder.Build().RunAsync();

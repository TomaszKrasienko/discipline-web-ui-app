using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using discipline_wasm_ui;
using discipline_wasm_ui.Configuration;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddBlazorBootstrap();
builder.Services.AddConfiguration(builder.Configuration);
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

await builder.Build().RunAsync();

//https://coolors.co/967371-391010-131613-1c211d-546357-c4d4c9-f5f4f5
//https://coolors.co/80805b-dedecf-805b5b-d4cac4-5b5b80-cbc8d0
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Net10.BWASM.A.Hosted.Rest.IB.Client.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<IssueApiService>();

await builder.Build().RunAsync();

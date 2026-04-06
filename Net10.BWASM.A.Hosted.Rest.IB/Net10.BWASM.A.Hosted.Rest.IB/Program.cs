using Microsoft.EntityFrameworkCore;
using Net10.BWASM.A.Hosted.Rest.IB.Client.Services;
using Net10.BWASM.A.Hosted.Rest.IB.Components;
using Net10.BWASM.A.Hosted.Rest.IB.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddControllers();

builder.Services.AddDbContext<IssuesDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("IssuesDb")));

// InteractiveServer モードでのプリレンダリング時に IssueApiService が使用するクライアント
builder.Services.AddHttpClient<IssueApiService>(client =>
{
    var baseUrl = builder.Configuration["ApiBaseUrl"] ?? "https://localhost:7163";
    client.BaseAddress = new Uri(baseUrl);
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapControllers();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(Net10.BWASM.A.Hosted.Rest.IB.Client._Imports).Assembly);

app.Run();


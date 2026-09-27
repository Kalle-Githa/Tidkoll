using IU2.Core;
using IU2.Core.services;
using IU2.Core.services.interfaces;
using IU2.Web.Components;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Registrera era tjänster här.
builder.Services.AddSingleton<IClock, SystemClock>();
builder.Services.AddScoped<IUpdateReportService, UpdateReportService>();

//Test fake date
//builder.Services.AddSingleton<IClock>(
//    new FakeClock(new DateTimeOffset(2026, 3, 15, 9, 0, 0, TimeSpan.FromHours(1))));

builder.Services.AddScoped<TimeReportService>();

var app = builder.Build();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();

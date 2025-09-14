using EcoTrack.Web.Components;
using Microsoft.EntityFrameworkCore;
using EcoTrack.Data.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Get the SQLite connection string
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Register your DbContext to use SQLite
builder.Services.AddDbContext<EcoTrackDbContext>(options =>
    options.UseSqlite(connectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();

// REPLACED: .NET 9's 'MapStaticAssets' with .NET 8's 'UseStaticFiles'
app.UseStaticFiles();

app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
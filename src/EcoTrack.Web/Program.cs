// --- Required using statements ---
using EcoTrack.Web.Components;
using Microsoft.EntityFrameworkCore;
using EcoTrack.Data.Data;
using EcoTrack.Core.Interfaces;
using EcoTrack.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// --- SERVICE REGISTRATION SECTION ---

// Get the SQLite connection string
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Register your DbContext to use SQLite
builder.Services.AddDbContext<EcoTrackDbContext>(options =>
    options.UseSqlite(connectionString));

// --- ADD THIS SECTION ---
// Register your repositories and the Unit of Work.
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IActivityRepository, ActivityRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ITravelActivityRepository, TravelActivityRepository>();
builder.Services.AddScoped<IFoodActivityRepository, FoodActivityRepository>();
builder.Services.AddScoped<IElectricityActivityRepository, ElectricityActivityRepository>();
builder.Services.AddScoped<IApplianceActivityRepository, ApplianceActivityRepository>();
builder.Services.AddScoped<IWasteActivityRepository, WasteActivityRepository>();

// ----------------------

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Riddle.Warehouse.DataAccess.Data;
using SQLCraft.DataAccess.Data;
using SQLCraft.DataAccess.Repository;
using SQLCraft.DataAccess.Repository.IRepository;
using SQLCraft.Services;
using SQLCraft.Utility;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddUserSecrets<Program>();

builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient<ChatGPTService>();

builder.Services.AddDbContext<ApplicationDbContext>(options => {
    var connectionString = builder.Configuration.GetConnectionString("ApplicationConnection");
    options.UseSqlServer(connectionString).EnableSensitiveDataLogging();
}
);

builder.Services.AddDbContext<WarehouseDbContext>(options => {
    var connectionString = builder.Configuration.GetConnectionString("RiddleWarehouseConnection");
    options.UseSqlServer(connectionString).EnableSensitiveDataLogging();
}
);

builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = $"/Identity/Account/Login";
    options.LogoutPath = $"/Identity/Account/Logout";
    options.AccessDeniedPath = $"/Identity/Account/AccessDenied";
});

builder.Services.AddRazorPages();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IEmailSender, EmailSender>();
var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapRazorPages();
app.MapControllerRoute(
    name: "default",
    pattern: "{area=User}/{controller=Home}/{action=Index}/{id?}");

app.Run();
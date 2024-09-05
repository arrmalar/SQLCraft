using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Riddle.Bank.TestCases.DataAccess.Data;
using Riddle.University.DataAccess.Data;
using Riddle.University.TestCases.DataAccess.Data;
using Riddle.Warehouse.DataAccess.Data;
using Riddle.Warehouse.TestCases.DataAccess.Data;
using SQLCraft.DataAccess.Data;
using SQLCraft.DataAccess.Repository.IRepository;
using SQLCraft.DataAccess.Repository;
using SQLCraft.Services.Interfaces;
using SQLCraft.Services;
using SQLCraft.Utility;
using Microsoft.AspNetCore.Identity.UI.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddUserSecrets<Program>();

builder.Services.AddControllers();
builder.Services.AddHttpClient<ChatGPTService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

builder.Services.AddDbContext<WarehouseTestCasesDbContext>(options => {
    var connectionString = builder.Configuration.GetConnectionString("RiddleWarehouseTestCasesConnection");
    options.UseSqlServer(connectionString).EnableSensitiveDataLogging();
}
);

builder.Services.AddDbContext<BankDbContext>(options => {
    var connectionString = builder.Configuration.GetConnectionString("RiddleBankConnection");
    options.UseSqlServer(connectionString).EnableSensitiveDataLogging();
}
);

builder.Services.AddDbContext<BankTestCasesDbContext>(options => {
    var connectionString = builder.Configuration.GetConnectionString("RiddleBankTestCasesConnection");
    options.UseSqlServer(connectionString).EnableSensitiveDataLogging();
}
);

builder.Services.AddDbContext<UniversityDbContext>(options => {
    var connectionString = builder.Configuration.GetConnectionString("RiddleUniversityConnection");
    options.UseSqlServer(connectionString).EnableSensitiveDataLogging();
}
);

builder.Services.AddDbContext<UniversityTestCasesDbContext>(options => {
    var connectionString = builder.Configuration.GetConnectionString("RiddleUniversityTestCasesConnection");
    options.UseSqlServer(connectionString).EnableSensitiveDataLogging();
}
);

builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = $"/Identity/Account/Login";
    options.LogoutPath = $"/Identity/Account/Logout";
    options.AccessDeniedPath = $"/Identity/Account/AccessDenied";
});

builder.Services.AddScoped<IUnitOfWorkApplication, UnitOfWorkApplication>();
builder.Services.AddScoped<IEmailSender, EmailSender>();
builder.Services.AddScoped<ISQLQueryValidatorService, SQLQueryValidatorService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
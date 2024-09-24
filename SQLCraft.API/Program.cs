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
using SQLCraft.Utility;
using SQLCraft.Models.DTO.Identity;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddUserSecrets<Program>();

builder.Services.AddControllers();
builder.Services.AddHttpClient();
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

builder.Services.AddAuthorization();
builder.Services.AddIdentityApiEndpoints<ApplicationUser>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = $"/Identity/Account/Login";
    options.LogoutPath = $"/Identity/Account/Logout";
    options.AccessDeniedPath = $"/Identity/Account/AccessDenied";
});

builder.Services.AddScoped<IUnitOfWorkApplication, UnitOfWorkApplication>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapIdentityApi<ApplicationUser>();
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.Run();
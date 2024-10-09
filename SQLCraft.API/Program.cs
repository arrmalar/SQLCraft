using Microsoft.EntityFrameworkCore;
using Riddle.Bank.TestCases.DataAccess.Data;
using Riddle.University.DataAccess.Data;
using Riddle.University.TestCases.DataAccess.Data;
using Riddle.Warehouse.DataAccess.Data;
using Riddle.Warehouse.TestCases.DataAccess.Data;
using SQLCraft.DataAccess.Data;
using SQLCraft.DataAccess.Repository.IRepository;
using SQLCraft.DataAccess.Repository;
using SQLCraft.Models.DTO.Identity;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using SQLCraft.API.Services;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddUserSecrets<Program>();

builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddControllers();
builder.Services.AddHttpClient();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options => {
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });
    options.OperationFilter<SecurityRequirementsOperationFilter>();
});

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
    .AddRoles<IdentityRole>()
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

app.UseHttpsRedirection();
app.MapGroup("/auth").MapIdentityApi<ApplicationUser>();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.Run();
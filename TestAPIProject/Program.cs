using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using TestAPI.Buisness.Services;
using TestAPI.Data.Repositories;
using TestAPIProject.Data;

var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.Console()
    .WriteTo.File("log/testLogs.txt", rollingInterval: RollingInterval.Year)
    .CreateLogger();

builder.Host.UseSerilog();

builder.Services.AddScoped<ITestService, TestService>();

builder.Services.AddScoped<ITestRepository>(provider =>
    new TestRepository(builder.Configuration.GetConnectionString("DefaultSQLConnection")));

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultSQLConnection"));
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();

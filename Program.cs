using Microsoft.EntityFrameworkCore;
using EmployeeMgmt.Crud;
using EmployeeMgmt.Services;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("EmployeeMgmt");
builder.Services.AddDbContext<EmployeeMgmtContext>(options => options.UseSqlServer(connectionString));
// Add services to the container.

builder.Services.AddScoped<DesignationCrud>();
builder.Services.AddScoped<EmployeeCrud>();

builder.Services.AddScoped<DesignationService>();
builder.Services.AddScoped<EmployeeService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

var scope = app.Services.CreateScope();
var context = scope.ServiceProvider.GetRequiredService<EmployeeMgmtContext>();
context.Database.EnsureCreated();

app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.MapControllers();
app.Run();

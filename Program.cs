using golden_snitch.Entities;
using golden_snitch.Services.Scheduler;
using golden_snitch.Services.Tenants;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var connectString = builder.Configuration.GetConnectionString("EntitiesDbContext");
// Note: This sample requires the database to be created before running.
Console.WriteLine($"Database path: {connectString}.");
builder.Services.AddDbContext<EntitiesDbContext>(options =>
  options.UseSqlServer(connectString));

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IProjectService, ProjectService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

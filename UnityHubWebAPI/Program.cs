using Microsoft.EntityFrameworkCore;
using UnityHubWebAPI;
using UnityHubWebAPI.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<DataBaseConnection>(opts => opts.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddApplicationServices();
builder.Services.AddEssentials();
builder.Services.AddEndpointsApiExplorer();
builder.Services.PresentationServices();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthorization();
var appSettings = new ConfigurationBuilder()
   .SetBasePath(Directory.GetCurrentDirectory())
   .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
   .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true)
   .Build();

builder.Services.AddInfrastructure(appSettings);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{

}


app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();

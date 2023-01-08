using kudapoyti.api.Configurations;
using kudapoyti.Service.Common.Security;
using kudapoyti.Service.Interfaces;
using kudapoyti.Service.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IAuthManager, AUthManager>();
builder.Services.AddScoped<IUserService,UserService>();
builder.Services.AddScoped<IPlaceService, PlaceService>();
builder.ConfigureDataAccess();

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

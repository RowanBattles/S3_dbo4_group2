using Bussines_MenuAPI;
using Bussines_MenuAPI.YourNamespace.Services;
using Bussiness_API_Contract;
using DataLayer_MenuAPI;
using DataLayer_MenuAPI.Repos;
using DateLayer_Bussiness_Contract;
using MenuAPI_Models;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCors(options =>
{
    options.AddPolicy("CORSpolicy", builder =>
    {
        builder
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader()
        .WithOrigins("http://localhost:5173");
    });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<MenuAPIDbContext>(o => o.UseSqlServer(connectionString));

builder.Services.AddScoped<ICategoryDAL, CategoryDAL>();
builder.Services.AddScoped<IMenuDAL, MenuDAL>();
builder.Services.AddScoped<IOrderDAL, OrderDAL>();
builder.Services.AddScoped<ITabDAL, TabDAL>();

builder.Services.AddScoped<ICategoryComponent, CategoryComponent>();
builder.Services.AddScoped<IMenuComponent, MenuComponent>();
builder.Services.AddScoped<IOrderComponent, OrderComponent>();
builder.Services.AddScoped<ITabComponent, TabComponent>();
builder.Services.AddSingleton<AccessCodeService>();

// Add services to the container
builder.Services.AddSingleton<AccessCodeService>();

var app = builder.Build();

app.UseCors("CORSpolicy");

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


using System.Reflection;
using DataAccessLayer;
using DataAccessLayer.Repository;
using Microsoft.EntityFrameworkCore;
using TestTask_Friend.APIStruct;
using TestTask_Friend.Services;
using TestTask_Friend.Validators;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IValidator<User>, UserValidator>();


builder.Services.AddAutoMapper(Assembly.GetAssembly(typeof(Program)));

builder.Services.AddDbContext<FriendContext>((provider, options) =>
{
    var connectionString = builder.Configuration["DataBaseOptions:ConnectionString"];
    connectionString += $"password={builder.Configuration["Password"]};";       //It comes from user-secrets
    options.UseNpgsql(connectionString);
});

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



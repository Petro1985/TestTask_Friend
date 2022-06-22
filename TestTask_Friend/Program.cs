using System.Reflection;
using Microsoft.EntityFrameworkCore;
using TestTask_Friend.APIStruct;
using TestTask_Friend.DAL;
using TestTask_Friend.DAL.Repository;
using TestTask_Friend.Services;
using TestTask_Friend.Validators;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(opt => 
{
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    opt.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
    
});

// Additional services registration
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IValidator<UserRequest>, UserValidator>();
builder.Services.AddAutoMapper(Assembly.GetAssembly(typeof(Program)));
builder.Services.AddDbContext<FriendContext>((options) =>
{
    var connectionString = builder.Configuration["ConnectionString"];       //It comes from dotnet user-secrets
    options.UseNpgsql(connectionString);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();

app.MapControllers();


app.Run();



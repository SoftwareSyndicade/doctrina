using System.Text.Json.Serialization;
using doctrine_api.Management.Account;
using doctrine_api.Management.Assistance.Request;
using doctrine_api.Management.Auth;
using doctrine_api.Management.Auth.Models;
using doctrine_api.Management.Student;
using doctrine_api.Management.Tutor;
using doctrine_api.Services.SQLServer;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddControllersWithViews();


builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNamingPolicy = null;
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

var JwtSecretKeySection = builder.Configuration.GetSection("JWTSecret");
builder.Services.Configure<JWTSecret>(JwtSecretKeySection);

builder.Services.AddMemoryCache();
builder.Services.AddDistributedMemoryCache(); // Adds a default in-memory implementation of IDistributedCache
builder.Services.AddDbContext<DoctrinaStore>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DoctrinaStoreConnectionString")));

builder.Services.AddScoped<IAccountManager, AccountManager>();
builder.Services.AddScoped<IAuthManager, AuthManager>();
builder.Services.AddScoped<IStudentManager, StudentManager>();
builder.Services.AddScoped<ITutorManager, TutorManager>();
builder.Services.AddScoped<IAssistanceRequestManager, AssistanceRequestManager>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.UseSpa(spa =>
{
    spa.Options.SourcePath = "../doctrina-clientapp";

    if (app.Environment.IsDevelopment())
    {
        spa.UseReactDevelopmentServer(npmScript: "start");
    }
});

app.Run();


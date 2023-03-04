using System.Security.Cryptography;
using System.Text.Json.Serialization;
using doctrine_api.Management.Account;
using doctrine_api.Management.Assistance.Request;
using doctrine_api.Management.Auth;
using doctrine_api.Management.Auth.Models;
using doctrine_api.Management.Student;
using doctrine_api.Management.Tutor;
using doctrine_api.Services.Google.Calendar;
using doctrine_api.Services.SQLServer;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using doctrine_api.Services.Google.Calendar.models;

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

var googleClientSecrets = builder.Configuration.GetSection("GoogleClientSecrets");
builder.Services.Configure<GoogleClientSecret>(googleClientSecrets);

var JwtSecretKeySection = builder.Configuration.GetSection("JWTSecret");
builder.Services.Configure<JWTSecret>(JwtSecretKeySection);

var jwtSettings = JwtSecretKeySection.Get<JWTSecret>();

builder.Services.AddSingleton<RsaSecurityKey>(provider =>
{
    RSA rsa = RSA.Create();
    rsa.ImportFromPem(jwtSettings.PUBLIC_KEY.ToCharArray());

    return new RsaSecurityKey(rsa);
});

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
{
    SecurityKey rsa = builder.Services.BuildServiceProvider().GetRequiredService<RsaSecurityKey>();

    options.IncludeErrorDetails = true;

    options.TokenValidationParameters = new()
    {
        IssuerSigningKey = rsa,
        ValidAudience = jwtSettings.AUDIENCE,
        ValidIssuer = jwtSettings.ISSUER,
        RequireSignedTokens = true,
        RequireExpirationTime = true, // <- JWTs are required to have "exp" property set
        ValidateLifetime = true, // <- the "exp" will be validated
        ValidateAudience = true,
        ValidateIssuer = true,
    };
});

builder.Services.AddMemoryCache();
builder.Services.AddDistributedMemoryCache(); // Adds a default in-memory implementation of IDistributedCache
builder.Services.AddDbContext<DoctrinaStore>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DoctrinaStoreConnectionString")));

builder.Services.AddScoped<IAccountManager, AccountManager>();
builder.Services.AddScoped<IAuthManager, AuthManager>();
builder.Services.AddScoped<IStudentManager, StudentManager>();
builder.Services.AddScoped<ITutorManager, TutorManager>();
builder.Services.AddScoped<IAssistanceRequestManager, AssistanceRequestManager>();
builder.Services.AddScoped<IGoogleCalendarService, GoogleCalendarService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();

app.UseAuthentication();

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


using APIAyudasSociales.Models;
using APIAyudasSociales.Services.Autenticacion;
using APIAyudasSociales.Services.AyudasSociales;
using APIAyudasSociales.Services.Localizacion;
using APIAyudasSociales.Services.Logging;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var misReglasCors = "ReglasCors";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: misReglasCors,
                      builder =>
                      {
                          builder.AllowAnyOrigin()
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                      });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddScoped<IAutenticacionService, AutenticacionService>();
builder.Services.AddScoped<ILocalizacionService, LocalizacionService>();
builder.Services.AddScoped<IAyudasSocialesService, AyudasSocialesService>();
builder.Services.AddScoped<ILoggingServices, LoggingService>();
builder.Services.AddHttpContextAccessor();


builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Description = "Standard Authorization header using the Bearer scheme (\"bearer {token}\")",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });

    options.OperationFilter<SecurityRequirementsOperationFilter>();
});

builder.Configuration.AddJsonFile("appsettings.json");
var secretKey = builder.Configuration.GetSection("settings").GetSection("secretKey").ToString();
var keyBytes = Encoding.UTF8.GetBytes(secretKey);

builder.Services.AddAuthentication(config => {

    config.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    config.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(config => {
    config.RequireHttpsMetadata = false;
    config.SaveToken = false;
    config.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(keyBytes),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDbContext<DbAPIAYUDASSOCIALESContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DbApiAyudasSocialesCon"));
});


var app = builder.Build();


// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
   
//}

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors(misReglasCors);

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
using evertec.Application.Interface;
using evertec.Application.Main;
using evertec.Domain.Core;
using evertec.Domain.Interface;
using evertec.InfraStructure.Data;
using evertec.InfraStructure.Interface;
using evertec.InfraStructure.Repository;
using evertec.Services.WebAPIRest.Helpers;
using evertec.Transversal.Common;
using evertec.Transversal.Logging;
using evertec.Transversal.Mapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Serialization;
using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllersWithViews().AddNewtonsoftJson();
builder.Services.AddRazorPages();
builder.Services.AddMvc(options =>
{
    options.EnableEndpointRouting = false;
});

builder.Services.AddControllers().AddNewtonsoftJson();
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.IgnoreNullValues = true;
});

builder.Services.AddControllers().AddXmlSerializerFormatters();
builder.Services.AddControllers().AddXmlDataContractSerializerFormatters();
builder.Services.Configure<FormOptions>(options =>
{
    options.MultipartBodyLengthLimit = long.MaxValue;
    options.ValueLengthLimit = int.MaxValue;
    options.MemoryBufferThreshold = int.MaxValue;
});

builder.Services.AddAutoMapper(Assembly.GetAssembly(typeof(MappingProfile)));

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

builder.Services.AddControllers()
    .AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.ContractResolver = new DefaultContractResolver();
    });


var appSettingsSection = builder.Configuration.GetSection("Config");
builder.Services.Configure<AppSettings>(appSettingsSection);

//configure jwt authentication
var appSettings = appSettingsSection.Get<AppSettings>();

//Se especifican la vida útil de los servicios.
builder.Services.AddSingleton<IConnectionFactory, ConnectionFactory>();

//Se usa de Scoped o de ámbito porque necesitamos que se instancie una vez por solicitud
//Clientes
builder.Services.AddScoped<IClientesApplication, ClientesApplication>();
builder.Services.AddScoped<IClientesDomain, ClientesDomain>();
builder.Services.AddScoped<IClientesRepository, ClientesRepository>();

//Usuarios
builder.Services.AddScoped<IUsuariosApplication, UsuariosApplication>();
builder.Services.AddScoped<IUsuariosDomain, UsuariosDomain>();
builder.Services.AddScoped<IUsuariosRepository, UsuariosRepository>();

builder.Services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));

var key = Encoding.ASCII.GetBytes(appSettings.Secret);
var IsSuer = appSettings.IsSuer;
var Audience = appSettings.Audience;

builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(x =>
{
    x.Events = new JwtBearerEvents
    {
        OnTokenValidated = context =>
        {
            var userId = int.Parse(context.Principal.Identity.Name);
            return Task.CompletedTask;
        },
        OnAuthenticationFailed = context =>
        {
            if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
            {
                context.Response.Headers.Add("Token-Expired", "true");
            }
            return Task.CompletedTask;
        }
    };
    x.RequireHttpsMetadata = false;
    x.SaveToken = false;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = true,
        ValidIssuer = IsSuer,
        ValidateAudience = true,
        ValidAudience = Audience,
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero
    };
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
app.UseAuthentication();
app.UseCors("CorsPolicy");



app.MapControllers();

app.Run();

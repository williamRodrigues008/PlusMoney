using Blazored.SessionStorage;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using PlusMoney.API.Helpers;
using PlusMoney.API.Interfaces;
using PlusMoney.API.Models;
using PlusMoney.API.Services;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var KEY = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuracoes.Key));

// Add services to the container.
builder.Services.AddCors(c =>
{
    c.AddPolicy("PermitirTudo", policy =>
    {
        policy.WithOrigins("https://localhost:7295")
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

builder.Services.AddDbContext<DbContexto>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("DbPlusMoney"));
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Por favor insira o token JWT com o prefixo 'Bearer'",
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });

});
builder.Services.AddScoped<ILogin, LoginService>();
builder.Services.AddScoped<ILeituraMovimentacao, MovimentacaoService>();
builder.Services.AddScoped<IEscritaMovimentacao, MovimentacaoService>();
builder.Services.AddScoped<ILeituraEscritaMovimentacao, MovimentacaoService>();

builder.Services.AddScoped<IUsuarioLeitura, UsuarioService>();
builder.Services.AddScoped<IUsuarioEscrita, UsuarioService>();
builder.Services.AddScoped<IUsuarioLeituraEscrita, UsuarioService>();

builder.Services.AddCascadingAuthenticationState();
builder.Services.AddScoped<AutenticarUsuario>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddAuthentication( o =>
{
    o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer("Bearer", o =>
{
    o.RequireHttpsMetadata = false;
    o.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        ValidateLifetime = true,
        IssuerSigningKey = KEY,
        ValidateAudience = false,
        ValidateIssuer = false
    };
});

builder.Services.AddAuthorization();


var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("PermitirTudo");
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
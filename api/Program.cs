using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Serilog;
using MediatR;
using FluentValidation;
using api.Application.Estudante.Command;
using api.Application.Estudante.Validation;
using api.Domain.Models;
using api.Domain.Services;
using api.Domain.Services.Interfaces;
using api.Infra.Repositories;
using api.Infra.Repositories.Interfaces;
using api.Application.EstudanteLocalidade.Command;
using api.Application.EstudanteLocalidade.Validation;
using api.Application.Localidade.Command;
using api.Application.Localidade.Validation;
using api.Application.Usuario.Command;
using api.Application.Usuario.Validation;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

string chaveSecreta = "CHAVE_14112023_BARAO";

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File("logs.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

builder.Services.AddLogging(loggingBuilder =>
{
    loggingBuilder.ClearProviders();
    loggingBuilder.AddSerilog();
});

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(chaveSecreta))
    };
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(typeof(Program));

builder.Services.AddScoped<IAuthService>(serviceProvider =>
    new AuthService(
        chaveSecreta,
        serviceProvider.GetRequiredService<IUsuarioService>(),
        serviceProvider.GetRequiredService<ILogger<AuthService>>()
    )
);

builder.Services.AddMediatR(typeof(Program).Assembly);

//Validation
builder.Services.AddTransient<IValidator<SalvarEstudanteCommand>, SalvarEstudanteCommandValidator>();
builder.Services.AddTransient<IValidator<AtualizarEstudanteCommand>, AtualizarEstudanteCommandValidator>();
builder.Services.AddTransient<IValidator<SalvarEstudanteLocalidadeCommand>, SalvarEstudanteLocalidadeCommandValidator>();
builder.Services.AddTransient<IValidator<AtualizarEstudanteLocalidadeCommand>, AtualizarEstudanteLocalidadeCommandValidator>();
builder.Services.AddTransient<IValidator<SalvarLocalidadeCommand>, SalvarLocalidadeCommandValidator>();
builder.Services.AddTransient<IValidator<AtualizarLocalidadeCommand>, AtualizarLocalidadeCommandValidator>();
builder.Services.AddTransient<IValidator<SalvarUsuarioCommand>, SalvarUsuarioCommandValidator>();
builder.Services.AddTransient<IValidator<AtualizarUsuarioCommand>, AtualizarUsuarioCommandValidator>();


//Service
builder.Services.AddScoped<IEstudanteService, EstudanteService>();
builder.Services.AddScoped<ILocalidadeService, LocalidadeService>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<IEstudanteLocalidadeService, EstudanteLocalidadeService>();
builder.Services.AddScoped<IMediatorService, MediatorService>();

//Repository
builder.Services.AddScoped<EstudanteRepository>();
builder.Services.AddScoped<LocalidadeRepository>();
builder.Services.AddScoped<UsuarioRepository>();
builder.Services.AddScoped<EstudanteLocalidadeRepository>();

//Interfaces e repositories
builder.Services.AddScoped<IEstudanteRepository, EstudanteRepository>();
builder.Services.AddScoped<ILocalidadeRepository, LocalidadeRepository>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IEstudanteLocalidadeRepository, EstudanteLocalidadeRepository>();

builder.Services.AddScoped<ISenhaHasher, SenhaHasher>();

builder.Services.AddDbContext<Contexto>(opcoes => opcoes.UseSqlServer(configuration["ConnectionStrings:ConexaoBD"]));

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

app.UseStaticFiles();

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors(builder =>
{
    builder.WithOrigins("http://localhost:4200", "http://localhost:5000")
           .AllowAnyHeader()
           .AllowAnyMethod();
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
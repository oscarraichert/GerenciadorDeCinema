using AutoMapper;
using GerenciadorDeCinema.WebApi;
using GerenciadorDeCinema.WebApi.Config;
using GerenciadorDeCinema.WebApi.Config.AutoMapperConfig;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.ConfigureDependencyInjection();
builder.Services.AddAutoMapper(typeof(AppProfileBase));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors(builder => builder
    .WithOrigins("http://localhost:4200")
    .WithMethods("*")
    .WithHeaders("*")
    .Build());
}

app.UseCors(builder => builder
    .WithOrigins("http://localhost:4200")
    .WithMethods("*")
    .WithHeaders("*")
    .Build());

app.ConfigurarSalas();

app.UseAuthorization();

app.MapControllers();

app.Run();

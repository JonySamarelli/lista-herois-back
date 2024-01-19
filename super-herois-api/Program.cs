using super_herois_api.Domain.DTOs;
using super_herois_api.Domain.Models;
using super_herois_api.Persistences;
using super_herois_api.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<SuperHeroisContext>();
builder.Services.AddTransient<IServiceBase<Herois, HeroisDTO>, HeroisService>();
builder.Services.AddTransient<IHeroiPersistencia, HeroisPersistencia>();
builder.Services.AddTransient<IServiceBase<Superpoderes, Superpoderes>, SuperpoderesService>();
builder.Services.AddTransient<ISuperpoderesPersistencia, SuperpoderesPersistencia>();
builder.Services.AddTransient<IHeroisSuperpoderesService, HeroisSuperpoderesService>();
builder.Services.AddTransient<IHeroisSuperpoderesPersistencia, HeroisSuperpoderesPersistencia>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(x => x
    .AllowAnyOrigin()
       .AllowAnyMethod()
          .AllowAnyHeader());  

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

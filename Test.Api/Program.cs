using Microsoft.Extensions.Options;
using System.Reflection;
using Test.Api.Services.CampaignServices;
using Test.Api.Services.MatchServices;
using Test.Api.Services.MovieServices;
using Test.Api.Settings;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IMovieService, MovieService>();
builder.Services.AddScoped<IMatchService, MatchService>();
builder.Services.AddScoped<ICampaignService, CampaignService>();


builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly()); //AutoMapper

builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection("DatabaseSettings")); //appsettingjson ayarlar�n� g�rmesi i�in
builder.Services.AddScoped<IDatabaseSettings>(sp =>
{
    return sp.GetRequiredService<IOptions<DatabaseSettings>>().Value;
}); //DatabaseSettings S�n�f�na eri�mesini sa�lad�k ba�lant� i�in


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


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

using Microsoft.AspNetCore.Mvc;
using UniHockey;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<UniHockeySettings>(builder.Configuration.GetSection("UniHockeySettings"));
builder.Services.AddHttpClient();
builder.Services.AddMvc(o =>
{
    o.CacheProfiles.Add("GeneralCache", new CacheProfile
    {
        Duration = 12,
        VaryByHeader = "Origin, Accept, Accept-Encoding, authorization, X-CustomCloudfront-Header"
    });
    o.EnableEndpointRouting = false;
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

app.MapControllers();

app.Run();

using LearningConfiguration;
using LearningConfiguration.Options;
using Shared.Configurations;

var builder = WebApplication.CreateBuilder(args);

//builder.AddEnterpriseConfiguration(args);

//builder.Configuration.AddAppConfiguration();

builder.Services.Configure<AppOptions>(builder.Configuration.GetSection("App"));

var data = builder.Configuration.AsEnumerable();
foreach (var item in data)
{
    Console.WriteLine($"{item.Key} = {item.Value}");
}

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

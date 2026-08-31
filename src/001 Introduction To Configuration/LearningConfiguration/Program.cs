using LearningConfiguration;

var builder = WebApplication.CreateBuilder(args);

builder.AddEnterpriseConfiguration(args);

builder.Configuration.Sources.Clear();

builder.Configuration
    .AddJsonFile("../CustomAppSettings.json", optional: true, reloadOnChange: true)
    .AddJsonFile("dbdetails.json", optional: true, reloadOnChange: true)
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

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

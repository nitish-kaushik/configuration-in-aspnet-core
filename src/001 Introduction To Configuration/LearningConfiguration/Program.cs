using LearningConfiguration;
using LearningConfiguration.BackgroundServices;
using LearningConfiguration.Options;
using Shared.Configurations;

var builder = WebApplication.CreateBuilder(args);

//builder.AddEnterpriseConfiguration(args);

//builder.Configuration.AddAppConfiguration();
builder.Services.AddHostedService<SmtpService>();
//builder.Services.Configure<AppOptions>(builder.Configuration.GetSection(AppOptions.SectionName));

builder.Services.AddOptions<AppOptions>()
    .Bind(builder.Configuration.GetSection(AppOptions.SectionName))
    //.ValidateDataAnnotations()
    .Validate(x=> !string.IsNullOrWhiteSpace(x.Name), "App Name is required")
    .Validate(x=> !string.IsNullOrWhiteSpace(x.Version), "App Version is required")
    .ValidateOnStart();

builder.Services.Configure<SmtpOptions>("provider1", builder.Configuration.GetSection("SmtpOptions:provider1"));
builder.Services.Configure<SmtpOptions>("provider2", builder.Configuration.GetSection("SmtpOptions:provider2"));

// var data = builder.Configuration.AsEnumerable();
// foreach (var item in data)
// {
//     Console.WriteLine($"{item.Key} = {item.Value}");
// }

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

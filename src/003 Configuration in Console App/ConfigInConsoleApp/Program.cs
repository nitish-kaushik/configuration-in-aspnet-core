using Microsoft.Extensions.Configuration;

var configurationBuilder = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

IConfiguration configuration = configurationBuilder.Build();

var appname = configuration["AppName"];

Console.WriteLine($"App Name: {appname}");

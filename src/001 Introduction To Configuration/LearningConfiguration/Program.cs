var builder = WebApplication.CreateBuilder(args);

var switchMappings = new Dictionary<string, string>()
{
    { "-db", "ConnectionStrings:Default" },
    { "-rd", "ConnectionStrings:Redis" },
    { "--t", "Title" },
};

builder.Configuration.AddCommandLine(args, switchMappings);

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

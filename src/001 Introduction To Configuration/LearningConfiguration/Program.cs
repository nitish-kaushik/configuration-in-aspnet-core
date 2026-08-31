var builder = WebApplication.CreateBuilder(args);

var switchMappings = new Dictionary<string, string>()
{
    { "-db", "ConnectionStrings:Default" },
    { "-rd", "ConnectionStrings:Redis" },
    { "--t", "Title" },
};
builder.Configuration.AddCommandLine(args, switchMappings);

var inMemoryCollection = new Dictionary<string, string>()
{
    { "Title", "My In memory Application" },
    { "App:Name", "App name In memory" },
    { "ConnectionStrings:Default", "InMem,Server=localhost;Database=mydb;User Id=myuser;Password=mypassword;" },
    { "ConnectionStrings:Redis", "localhost:inmem" }
};

builder.Configuration.AddInMemoryCollection(inMemoryCollection);

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

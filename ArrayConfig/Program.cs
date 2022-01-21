using ArrayConfig;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<Weekdays>(builder.Configuration);

var app = builder.Build();



// var configs= app.Configuration.GetSection("ConfigArray").Get<string[]>();

var configs=app.Services.GetRequiredService<IOptions<Weekdays>>()?.Value.ConfigArray;
foreach (var config in configs)
{
    Console.WriteLine(config);
}

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
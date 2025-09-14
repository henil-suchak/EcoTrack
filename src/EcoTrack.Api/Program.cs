var builder = WebApplication.CreateBuilder(args);

// REPLACED: .NET 9's 'AddOpenApi' with the standard .NET 8 Swagger services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// REPLACED: .NET 9's 'MapOpenApi' with the standard .NET 8 Swagger UI
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Your API endpoints will go here later

app.Run();
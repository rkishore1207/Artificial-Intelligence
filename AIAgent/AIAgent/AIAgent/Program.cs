using Services.FunctionCalling;
using Services.VectorEmbeddingAgent;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddScoped<IFunctionCalling, FunctionCalling>();
builder.Services.AddScoped<ICustomFunctions, CustomFunctions>();
builder.Services.AddScoped<IVectorEmbedding, VectorEmbedding>();

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

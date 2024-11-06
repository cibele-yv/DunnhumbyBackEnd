using FluentAssertions.Common;
using Microsoft.EntityFrameworkCore;
using WebApiDunnhumbyAssessment;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder =>
        {
            builder.AllowAnyOrigin() 
                   .AllowAnyHeader()                     // Allow all headers
                   .AllowAnyMethod();                    // Allow all HTTP methods (GET, POST, etc.)
        });
});

builder.Services.AddControllers();

builder.Services.AddDbContext<ProductDbContext>(options =>
            options.UseSqlite("Data Source=products.db"));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowAllOrigins");

app.UseAuthorization();

app.MapControllers();

app.Run();

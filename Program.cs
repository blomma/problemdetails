using Hellang.Middleware.ProblemDetails;
using Hellang.Middleware.ProblemDetails.Mvc;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddProblemDetails(opt =>
{
    opt.IncludeExceptionDetails = (_, _) => true;
});

builder.Services.AddControllers();
builder.Services.AddProblemDetailsConventions();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseProblemDetails();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection();

// app.UseAuthorization();

app.MapControllers();

app.Run();

using CollegeApp.Configurations;
using CollegeApp.Data;
using CollegeApp.Data.Repository;
using CollegeApp.MyLogging;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options =>
{
    options.ReturnHttpNotAcceptable = false; // It will return exception for the unsupported format. like if user want data in xml it return exception.
}).AddNewtonsoftJson().AddXmlDataContractSerializerFormatters();// This method is used to support xml format.

builder.Services.AddDbContext<CollegeDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddAutoMapper(typeof(AutoMapperConfig));
builder.Services.AddTransient<IMyLogger, LogToFile>(); // This indicates that where ever IMylogger is used it will load logtofile.
builder.Services.AddTransient<IStudentRepository, StudentRepository>();

//For Generic type we need to register like this
builder.Services.AddScoped(typeof(ICollegeRepository<>), typeof(CollegeRepository<>));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>options.AddPolicy("MyTestCORS", policy =>
{
    //policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    policy.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader();
}));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("MyTestCORS");

app.UseAuthorization();

app.MapControllers();

app.Run();

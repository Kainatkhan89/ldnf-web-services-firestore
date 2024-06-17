using learndotnetfast_web_services.Common.Exceptions.Handlers;
using learndotnetfast_web_services.Data;
using learndotnetfast_web_services.Middleware;
using learndotnetfast_web_services.Repositories.CourseModule;
using learndotnetfast_web_services.Repositories.Tutorial;
using learndotnetfast_web_services.Services.Courses;
using learndotnetfast_web_services.Services.Tutorials;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddControllers();
// --Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// --Register your DbContext to use an in-memory database
//builder.Services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase(builder.Configuration.GetConnectionString("MyTestDB")));

builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// --Register other services, repositories, etc.
builder.Services.AddScoped<ICourseModuleRepository, CourseModuleRepository>();
builder.Services.AddScoped<ICourseModuleService, CourseModuleService>();
builder.Services.AddScoped<ITutorialRepository, TutorialRepository>();
builder.Services.AddScoped<ITutorialService, TutorialService>();

// --Register AutoMapper
builder.Services.AddAutoMapper(typeof(Program).Assembly);

// --Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "AllowSpecificOrigin",
        builder =>
        {
            builder.WithOrigins("http://localhost:4200")
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
});

builder.Services.AddControllers(options =>
{
    // --Register the Database Exception Handler globally
    options.Filters.Add<ApiExceptionHandler>();
    options.Filters.Add<DatabaseExceptionHandler>();
});

var app = builder.Build();


// --Middleware to handle exceptions globally
app.UseMiddleware<ExceptionHandlingMiddleware>();

// --Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowSpecificOrigin"); // Apply CORS policy

app.UseAuthorization();

app.MapControllers();

app.Run();

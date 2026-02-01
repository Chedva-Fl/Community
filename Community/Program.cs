using Community;
using Community.core.Repositories;
using Community.core.Serivecs;
using Community.Data;
using Community.Data.Repositories;
using Community.Service;
using System.Runtime.Serialization.DataContracts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.\
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ITeacherRepository,TeacherRepository>();
builder.Services.AddScoped<ITeacherService, TeacherService>();

builder.Services.AddScoped<ICoursesRepository, CourseRepository>();
builder.Services.AddScoped<ICoursesService, CourseService>();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddSingleton<DataContext>();


//var policy = "policy";
//builder.Services.AddCors(options =>
//{
//    options.AddPolicy(name: policy, policy =>
//    {
//        policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
//    });
//});
builder.Services.AddAutoMapper(typeof(MappingPostModels), typeof(MappingPostModels));

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
//app.UseCors(policy);

app.Run();

using Postie.Core.Contracts;
using Postie.Core.Repositories;
using Postie.Core.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//repositories
builder.Services.AddTransient<IPostDbRepository, PostDbRepository>(_ => new PostDbRepository());
builder.Services.AddTransient<IUserDbRepository, UserDbRepository>(_ => new UserDbRepository());
//Services
builder.Services.AddTransient<IBusinessLogicService, BusinessLogicService>();
builder.Services.AddTransient<IPostRepository, PostService>();
builder.Services.AddTransient<IUserService, UserService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        policy =>
        {
            policy.WithOrigins("https://localhost:7088")
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials();
        });
});

var app = builder.Build();

app.UseCors("AllowSpecificOrigin");

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

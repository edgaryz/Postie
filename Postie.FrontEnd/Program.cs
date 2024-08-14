using Postie.Core.Contracts;
using Postie.Core.Repositories;
using Postie.Core.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddTransient<IPostDbRepository, PostDbRepository>(_ => new PostDbRepository());
builder.Services.AddTransient<IUserDbRepository, UserDbRepository>(_ => new UserDbRepository());
//Services
builder.Services.AddTransient<IBusinessLogicService, BusinessLogicService>();
builder.Services.AddTransient<IPostRepository, PostService>();
builder.Services.AddTransient<IUserService, UserService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();

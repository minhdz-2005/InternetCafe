using InternetCafe.Data;
using InternetCafe.Services;
using Microsoft.EntityFrameworkCore;
using InternetCafe.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<InternetCafeContext>(option =>
    option.UseSqlServer(builder.Configuration.GetConnectionString("InternetCafe"))
);

builder.Services.AddScoped<ComputerSevice>();
builder.Services.AddScoped<AccountSevice>();
builder.Services.AddScoped<ManagerSevice>();
builder.Services.AddScoped<UsedInfoSevice>();
builder.Services.AddScoped<UserSevice>();

var app = builder.Build();




// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();

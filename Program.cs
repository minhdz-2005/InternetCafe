using InternetCafe.Data;
using InternetCafe.Services;
using Microsoft.EntityFrameworkCore;
using InternetCafe.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication("Auth").AddCookie("Auth", options =>
{
    options.LoginPath = "/Account/Login";
    options.AccessDeniedPath = "/Account/Login";
});
builder.Services.AddAuthorization();

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
builder.Services.AddScoped<UsingViewModelSevice>();

builder.Services.AddSession();

var app = builder.Build();

// TEST CRUD
// using (var scope = app.Services.CreateScope()) {
//     var db = scope.ServiceProvider.GetRequiredService<ComputerSevice>();

//     var ListC = db.GetAll();
//     foreach (var c in ListC) {
//         c.Revenue = 0m;
//         db.Update(c.Id, c);
//     }
//     var db1 = scope.ServiceProvider.GetRequiredService<UsedInfoSevice>();
//     db1.Delete(1);
// }

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseSession();

app.UseHttpsRedirection();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}")
    .WithStaticAssets();

app.Run();

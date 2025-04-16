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
builder.Services.AddScoped<UsingViewModelSevice>();

builder.Services.AddSession();

var app = builder.Build();

// using (var scope = app.Services.CreateScope()) {
//     var db = scope.ServiceProvider.GetRequiredService<ComputerSevice>();

    
//     for (int i = 1; i <= 10; i++) {
//         var c = db.GetById(i);
//         if(c != null) {
//             Random r = new Random();
//             decimal randomDecimal = Math.Round(10 + (decimal)(r.NextDouble() * (100 - 10)), 2);
//             c.Revenue = randomDecimal;
//             db.Update(i, c);
//         }
//     }

    
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

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}")
    .WithStaticAssets();


app.Run();

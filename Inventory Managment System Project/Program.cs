using Inventory_Managment_System_Project.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Register DbContext with Dependency Injection
builder.Services.AddDbContext<MyContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddDefaultIdentity<IdentityUser>()
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<MyContext>();


builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Registration/LogIn"; // Change this to your controller and action
});

builder.Services.AddControllersWithViews();

builder.Services.AddControllersWithViews();
builder.Services.AddAuthentication();
builder.Services.AddSession();


var app = builder.Build();



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();
app.UseRouting();


app.UseSession();
app.UseAuthentication();
app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Registration}/{action=LogIn}/{id?}")
    .WithStaticAssets();




app.Run();

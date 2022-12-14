using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MoodPlus.Data;
using MoodPlus.Models;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("ApplicationDbContextConnection") ?? throw new InvalidOperationException("Connection string 'ApplicationDbContextConnection' not found.");

// Add services to the container.
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddIdentity<Account, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultUI()
    .AddTokenProvider<DataProtectorTokenProvider<Account>>(TokenOptions.DefaultProvider);

builder.Services.AddDbContext<ApplicationDbContext>();
builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews();
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "MyPolicy", policy =>
    {
        policy.WithOrigins("http://localhost:7040").AllowAnyHeader().AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseCors("MyPolicy");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();

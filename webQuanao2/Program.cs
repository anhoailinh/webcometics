using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Build.Framework;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProtoBuf.Extended.Meta;
using webQuanao2.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<webQuanao2Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("webQuanao2Context") ?? throw new InvalidOperationException("Connection string 'webQuanao2Context' not found.")));

// Add services to the container.
builder.Services.AddHttpContextAccessor();
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Users/Login"; // Đường dẫn tới trang đăng nhập mới của bạn
    });
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseSession();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

using Microsoft.EntityFrameworkCore;
using CodeFirstTeach.Models;
////////////////////////////////// 註冊服務只能寫在這裡之下
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

/* 
筆記( 一.2.e. ) : 在Program.cs內以依賴注入的寫法註冊讀取連線字串的服務(food panda、Uber Eats)
注意: 程式的位置必須要在var builder = WebApplication.CreateBuilder(args); 這句之後且在var app = builder.Build(); 之前
*/
builder.Services.AddDbContext<GuestBookContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("GuestBookConnection")));

////////////////////////////////// 註冊服務只能寫在這裡之上

////////////////////////////////// 這裡之下是用來啟動服務
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

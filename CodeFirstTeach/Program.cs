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

/*
筆記( 一.3.d. ) : 在Program.cs撰寫啟用Initializer的程式(要寫在var app = builder.Build();之後)
※這個Initializer的作用是建立一些初始資料在資料庫中以利測試，所以不一定要有Initializer※
※注意:初始資料的照片放在BookPhotos資料夾中※
*/
using (var scope = app.Services.CreateScope())
{
    var service = scope.ServiceProvider;

    SeedData.Initialize(service);
    // SeedData.Initialize(services)是用來初始化資料庫的初始資料
    // 這裡的services是依賴注入的服務提供者
}


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

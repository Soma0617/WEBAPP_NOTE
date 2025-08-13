using Microsoft.EntityFrameworkCore;
using CodeFirstTeach.Models;
////////////////////////////////// ���U�A�ȥu��g�b�o�̤��U
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

/* 
���O( �@.2.e. ) : �bProgram.cs���H�̿�`�J���g�k���UŪ���s�u�r�ꪺ�A��(food panda�BUber Eats)
�`�N: �{������m�����n�bvar builder = WebApplication.CreateBuilder(args); �o�y����B�bvar app = builder.Build(); ���e
*/
builder.Services.AddDbContext<GuestBookContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("GuestBookConnection")));

////////////////////////////////// ���U�A�ȥu��g�b�o�̤��W

////////////////////////////////// �o�̤��U�O�ΨӱҰʪA��
var app = builder.Build();

/*
���O( �@.3.d. ) : �bProgram.cs���g�ҥ�Initializer���{��(�n�g�bvar app = builder.Build();����)
���o��Initializer���@�άO�إߤ@�Ǫ�l��Ʀb��Ʈw���H�Q���աA�ҥH���@�w�n��Initializer��
���`�N:��l��ƪ��Ӥ���bBookPhotos��Ƨ�����
*/
using (var scope = app.Services.CreateScope())
{
    var service = scope.ServiceProvider;

    SeedData.Initialize(service);
    // SeedData.Initialize(services)�O�ΨӪ�l�Ƹ�Ʈw����l���
    // �o�̪�services�O�̿�`�J���A�ȴ��Ѫ�
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

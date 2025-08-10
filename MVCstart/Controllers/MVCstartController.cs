using Microsoft.AspNetCore.Mvc;
/* 
1. 這行是告訴編譯器我們要使用微軟提供的ASP.NET Core的MVC功能
2. ASP.NET Core MVC組織方式說明 : 
    a. 組織程式碼 : 把大量程式以M, V, C進行分類、命名清楚，以方便管理
    b. 命名空間( namespace ) : 用來組織程式碼的容器，如同資料夾，避免命名衝突
    c. 控制器( Controllers )、資料模型( Models )、使用者畫面( Views )
        、前端靜態資源( 如圖片、CSS、JS )wwwroot
    d. 執行時，要先把專案名稱調整至需要的專案，然後網址的寫法 : https://localhost:5001/CSharp/Hello
        => https://localhost:5001/ + [Controller名稱] + [Action名稱]
*/

namespace MVCstart.Controllers
/*
1. Controllers( 控制器 ) : 負責判斷程式碼、處理資料、判斷使用者的請求
   ，並決定要傳什麼樣的資料到View( 使用者畫面 )
2. Views( 使用者畫面 ) : 把Controllers傳來的資料用HTML呈現給使用者看
*/
{
    public class MVCstartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

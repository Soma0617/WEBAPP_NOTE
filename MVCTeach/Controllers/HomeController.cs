using System.Diagnostics;
using Microsoft.AspNetCore.Mvc; // 這行是告訴編譯器我們要使用微軟提供的ASP.NET Core的MVC功能
using MVCTeach.Models;
/* 
1. ASP.NET Core是一個Web應用程式開發的框架，支援多種開發方式( MVC就是其中一種模式 )
2. MVC( Model-View-Controller )是一種設計模式，也是ASP.NET Core的其中一種Web應用程式開發方式之一
   ，它把應用程式分成三個主要部分 : 
   a. Model( 資料模型 ) : 負責處理資料的邏輯與存取
   b. View( 使用者畫面 ) : 把Controllers傳來的資料呈現給使用者看
   c. Controller( 控制器 ) : 負責判斷程式碼、處理資料、判斷使用者的請求
    ，並決定要傳什麼樣的資料到View( 使用者畫面 )
   d. wwwroot( 前端靜態資源 ) : 如圖片、CSS、JS
3. 執行時，要先把專案名稱調整至需要的專案，然後網址的寫法 : https://localhost:5001/MVCTeach/Index
    => https://localhost:5001/ + [Controller名稱] + [Action名稱]
補充 : 在VS中，如果要自動對齊程式碼，要按下ctrl + K再按ctrl + D
*/

namespace MVCTeach.Controllers
// namespace( 命名空間 )是用來組織程式碼的方式，如同資料夾，避免命名衝突，方便管理
{
    public class HomeController : Controller
    /*
    1. 建立一個公開的( public )控制器類別( class )，名叫HomeController
        ，而且HomeController要繼承名為Controller的類別
        => 繼承 : 表示HomeController會擁有Controller類別的所有功能與屬性
        ，也就是說HomeController會擁有MVC中的控制器( Controller )應有的功能
        ( 像是處理網頁請求、傳資料給View等 )
    2. 在View中也會有一個名稱為Home的資料夾，一定要跟這個Controller名稱一樣
        ，這樣控制器( Controller )才能正確地把資料傳進對應的View 
    3. 在Controller中會有action( 動作方法 )
        ，action是Controller中特殊的方法( method，有點像是JS中function的作用 )
        a. action的名稱要跟View中的.cshtml檔案名稱一致
        b. action的功用是處理使用者的請求，並傳遞資料到View中顯示
            ，所以View中會有一個跟action同名的.cshtml檔案
    補充 : 在public( 公開的 )中建立的class( 類別 )中會有method( 方法 )
        ，而這些method就叫做action( 動作方法 )
        因此所有的action都會是method，但不是所有的method都叫做action
    4. 結論 : 當有一個叫做Home名稱的Controller時
        ，View中就會有一個名稱為Home的資料夾，而Controller中有個名稱為Index的action
        ，則Home資料夾中就會有一個叫做Index的.cshtml檔案
        ( 以上是命名的規定 )
    */
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        /*
        1. IActionResult是一個介面( interface )，在ASP.NET Core MVC用來表示回傳結果的資料型別
            ，這個結果可以是很多種類型( 例如View畫面、JSON資料、重導向等 )
            => 可以理解為控制器( Controller )的這個action可以回傳任何一種結果給瀏覽器
        2. Index()是這個action的名稱，action的名稱是自訂的
        */
        {
            // 底下是要執行的程式碼
            ViewData["myTime"] = DateTime.Now.ToString("hh:mm:ss tt");
            /*
            1. ViewData是一個物件( 這個叫做字典 )，功能是用來在Controller和View之間傳遞資料
            2. 語法 : ViewData["Key名稱( 自訂 )"] = 值( 可以是任何資料型別 )
                => 在View中利用@ViewData["Key名稱( 自訂 )"]來取得這個值，並顯示在畫面上
            3. DateTime.Now：取得目前的系統日期與時間
            4. ToString("hh:mm:ss tt")：將時間格式化為12小時制的時間字串
                => "hh"表示小時( 01-12 )，"mm"表示分鐘，"ss"表示秒，"tt"表示AM / PM
            */

            /*
            Controller中常見的三種傳資料方式 : 
            1. ViewData是一種字典資料型別 : 用來在Controller和View之間傳遞資料
               a. 在Controller中語法 :  
               => ViewData["Key名稱( 自訂 )"] = 值( 可以是任何資料型別 )
               b. 在View中語法 :
               => @ViewData["Key名稱( 自訂 )"]
            2. ViewBag是一個動態物件( dynamic object )資料型別 : 用來在Controller和View之間傳遞資料
               a. 在Controller中語法 : 
               => ViewBag.屬性名稱( 自訂 ) = 值( 可以是任何資料型別 )
               b. 在View中語法 :
               => @ViewBag.屬性名稱( 自訂 )
            3. Model( 模型 ) : 用來在Controller和View之間傳遞資料
               a. 在Controller中語法 : 在Controller的action中建立Model物件，並return View(Model物件)
               => EX : 
               var product = new Product { Name = "Apple", Price = 100 };
               return View(product);
            b. 在Model中語法 : 在Model資料夾下建立一個類別
               並寫下類別資料型態以及的屬性
               => EX : 
               public class Product
               {
                    public string Name { get; set; }
                    public decimal Price { get; set; }
               }
            c. 在View中語法 : 在View的.cshtml檔案中使用@model關鍵字來指定Model資料型態
                並使用@Model.屬性名稱來取得Model的屬性值
                => EX : 
                @model Product
                <p>Product Name: @Model.Name</p>
                <p>Product Price: @Model.Price</p>
        */
            string a = "<a href='http://www.google.com'>點我</a>";
            ViewData["a"] = a;
            ViewBag.A = a;
            // 可以把要傳入View的值直接寫在ViewData或ViewBag中，也可以宣告一個變數並賦值
            return View();
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

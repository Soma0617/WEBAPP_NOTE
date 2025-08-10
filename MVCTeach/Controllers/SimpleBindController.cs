using Microsoft.AspNetCore.Mvc;
using MVCTeach.Models;

namespace MVCTeach.Controllers
{
    /*
    簡單繫結法實際運用 : 
    要做一個商品資料表，有商品編號、商品名稱、商品價格這些欄位
    1. 需要在View中做一個商品新增的表單介面
    2. 因此要先在Controller中建立一個相對應的action，讓他把程式碼傳進這個View
    3. 結論 : 
        先寫Controller( 控制器 )，寫完後在對應的action中建立View( 檢視 )
        ，並進行View介面的設計
    */
    public class SimpleBindController : Controller
    {
        public IActionResult Create()
        {
            return View();
        }

        // 表單submit後，會將資料傳送到Controller中這個指定的action
        [HttpPost]
        /* 
        1. 這句表示下面這個action只處理來自Post方法的資料
        補充 : 如果沒有寫就是預設為HttpGet
        2. 下面叫做SimpleBind( 簡單繫結法 ) : 
           把action的參數名稱跟View中表單欄位中的name屬性名稱取一樣的
           ，ASP.NET Core會自動將這些繫結到表單參數資料上
        */
        /*
        GET跟POST的差別 :
        1. GET傳資料是公開傳送的，不論是自己打在網址上，還是從網頁上點擊連結，都是GET傳資料
            ，但是需求的資料( 參數 )都會顯示在網址上
            => 常用在查詢資料、顯示資料等情況
        2. POST傳資料是把資料送到伺服端的程式，讓Controller去處理
            => 常用在新增、修改、刪除資料等情況
        3. GET是用來查詢、顯示畫面等功能，所以當如果沒有輸入參數，就會顯示最原始的網頁畫面
            ，所以可以獨立存在
        4. POST是用來處理資料的，所以如果沒有輸入參數，就會顯示錯誤訊息
            ，因此POST需要有資料( 參數 )輸入進行處理，然後搭配GET顯示畫面，所以POST通常都會搭配GET一起使用
        */

        // 簡單繫結法 :
        public IActionResult Create(string ProductNo, string ProductName, string ProductPrice)
        /* 
        1. 簡單繫結法要把要傳入的欄位資料型態跟欄位名稱寫在參數( 要傳的資料 )裡
            ，並由action傳入參數
        2. action傳入參數 : action(參數的資料型態 要繫結的name屬性名稱, 第二個參數, 第三個參數) 
        */
        {
            ViewData["ProductNo"] = ProductNo;
            ViewData["ProductName"] = ProductName;
            ViewData["ProductPrice"] = ProductPrice;

            return View();
        }

        // 把上面簡單繫結法改寫成複雜繫結法 : 
        public IActionResult Create2()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create2(Product product)
        {
            ViewData["ProductNo"] = product.ProductNo; 
            // 物件名稱.物件的屬性( 欄位 )名稱( 在Product.cs中自訂的 )
            ViewData["ProductName"] = product.ProductName產品名稱;
            ViewData["ProductPrice"] = product.ProductPrice;

            return View();
        }

    }
}

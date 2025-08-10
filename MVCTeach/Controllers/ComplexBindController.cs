using Microsoft.AspNetCore.Mvc;
using MVCTeach.Models;
/*
寫using MVCTeach.Models表示引用MVCTeach.Models的namespace( 命名空間 )
，讓我可以直接使用MVCTeach.Models中的命名空間下定義的所有類別( 例如Member、Product等等 )
，如此一來下面叫做Create()的action才能使用Member模型( Model中的Member.cs )的內容
*/

namespace MVCTeach.Controllers
{
    /*
    複雜繫結法實際運用 : 
    要做一個會員資料表，有會員編號、會員姓名、地址、電話、性別這些欄位
    1. 首先要寫會員資料表的資料模型 => 建立一個Model( 使用複雜繫結法必須要有MVC中的Model( 模型 ) )
    2. 需要在View中做一個加入會員的表單介面
    3. 因此要先在Controller中建立一個相對應的action，讓他把程式碼傳進這個View
    4. 結論 : 
        先建立Model( 資料模型 )，然後再寫Controller( 控制器 )，寫完後在對應的action中建立View( 檢視 )
        ，並進行View介面的設計
    */
    public class ComplexBindController : Controller
    {
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Member member)
        /* 
        1. 簡單繫結法，有幾個欄位就需傳幾個參數( 資料型態 + name屬性名稱 )
        2. 複雜繫結法，直接傳入一個物件member( 物件的屬性會自動對應到跟屬性名稱相同的欄位名稱 )
        3. 第一個Member是資料模型( Model )中類別( class )的名稱
           ，第二個member是物件( 也是參數 )
        */
        {
            ViewData["MemberID"] = member.MemberID; // 物件名稱.物件的屬性名稱( 在Member.cs中自訂的 )
            ViewData["MemberName"] = member.MemberName;
            ViewData["Address"] = member.Address;
            ViewData["Phone"] = member.Phone;
            ViewData["Gender"] = member.Gender;

            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using MVCTeach.Models;

namespace MVCTeach.Controllers
{
    public class LogInController : Controller
    {
        public IActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public IActionResult LogIn(LogIn login)
        /*
        1. 抓表單送來的帳號密碼 
        2. 驗證帳號密碼是否正確
        3. 如果正確，則登入成功，導向後台頁面
        4. 如果錯誤，則登入失敗，導向登入頁面並顯示錯誤訊息
        帳號 => login.UserName;
        密碼 => login.Password;
        */
        {
            // 假設帳號 : admin，密碼 : 12345678
            if (login.UserName == "admin" && login.Password == "12345678")
            { 
                return RedirectToAction("Index", "ViewTeach");
                /*
                語法說明 :
                1. RedirectToAction表示重新導向至哪個action
                2. RedirectToAction("欲重新導向至的action名稱", "欲重新導向至的controller名稱")
                3. 登入成功後，導向ViewTeachController的Index action
                */
            }

            ViewData["ErrorMessage"] = "帳號或密碼錯誤，請重新輸入";
            // 如果帳號或密碼錯誤，則會回到現在這個LogIn action( 也就是登入頁面 )
            return View();
        }
    }
}

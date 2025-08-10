using Microsoft.AspNetCore.Mvc;
using System.Drawing;

namespace MVCTeach.Controllers
{
    public class FileUploadController : Controller
    {
        public IActionResult ShowPhotos()
        {
            string[] files = Directory.GetFiles(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Photos"));
            // 這裡給的路徑是/wwwroot/Photos之中的全部的檔案，並以一個集合的形式回傳
            foreach (string item in files)
            {
                // 取得檔案名稱
                string fileName = Path.GetFileName(item);
                ViewData["Photos"] += $"<img src='/Photos/{fileName}'>";
            }
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

    [HttpPost]
        public IActionResult Create(IFormFile photo)
        /*
        1. IFormFile是ASP.NET Core中用來處理上傳檔案的參數的資料型別
        2. photo是參數名稱( 自訂 )
        補充 : 常用的屬性( 參數.屬性 )
        1. photo.FileName : 取得上傳檔案的名稱
        2. photo.ContentType : 取得上傳檔案的類型
        3. photo.Length : 取得上傳檔案的大小
        4. photo.CopyTo(Stream) : 將上傳的檔案複製到指定的資料流( Stream )中
        */
        {
            if (photo == null || photo.Length == 0)
            {
                ViewData["ErrMessage"] = "檔案沒上傳";
                return View();
            }

            // 檢查檔案類型( 例如只允許上傳圖片 )
            if (photo.ContentType != "image/jpeg" && photo.ContentType != "image/png")
            {
                ViewData["ErrMessage"] = "只允許上傳.jpg或.png的圖片檔案";
                return View();
            }

            // 取得檔案名稱
            string fileName = Path.GetFileName(photo.FileName);
            /*
            1. Path.GetFileName()：這個方法會從完整的檔案路徑中提取出檔案名稱，去除任何路徑資訊
            2. photo.FileName：取得上傳檔案的原始名稱，這個名稱有時可能包含路徑
            */

            // 取得檔案完整路徑
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Photos", fileName);
            /*
            1. Path.Combine()：這個方法用來組合多個字串成一個完整的路徑，確保路徑格式正確
                ，()內可以是多個參數，每個參數都是路徑的一部份
            2. Directory.GetCurrentDirectory()：這個方法會取得目前專案的根目錄或者專案檔案所在的目錄
            */

            // 將檔案上傳並儲存至指定路徑
            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            {
                photo.CopyTo(fs);
            }
            
            ViewData["SuccessMessage"] = "檔案上傳成功";

            return View();
        }
    }
}

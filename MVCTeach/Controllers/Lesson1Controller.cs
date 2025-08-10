using Microsoft.AspNetCore.Mvc;

namespace MVCTeach.Controllers
{
    public class Lesson1Controller : Controller
    {
        public IActionResult ShowPhotos()
        {
            for (int i = 1; i <=8; i++)
            {
                ViewData["Photos"] += $"<img src='/images/{i}.jpg'>";
                /*
                1. ${}可以讓字串中嵌入變數
                2. $放在字串最前面，{}之中包裹變數或運算式
                3. 這裡使用 += 而不是用 = 的原因 : 
                    a. = 是指定運算子，每次都會把原本的值覆蓋掉，只留最後一次的值
                    b. += 是累加運算子，會把原本的值和新的值相加，保留之前的值
                        ，所以這裡就會變成8個<img>標籤
                */
            }
            return View();
        }

        public IActionResult ShowPhoto(int number)
        /*
        1. 使用者輸入就是建立一個有參數的action，讓使用者在網址上輸入參數的值，這個叫做Query String傳參數
        2. 使用者輸入參數方式 : 在網址後面加上問號、參數名稱、等號跟參數的值
            => 網址範例 : /Lesson1/ShowPhoto?number=1，這樣會顯示number=1時，程式碼的照片
        */
        {
            /*
            1. C#中的陣列需要先寫出陣列中元素的資料型別，因此這個元素是字串的陣列是寫string[]來表示
            2. 如果陣列中想要有不同資料型別的元素，則可以使用object[]來表示
            */
            string[] name = { "菜名1", "菜名2", "菜名3", "菜名4", "菜名5", "菜名6", "菜名7", "菜名8" };
            // 語法 : 陣列的資料型別[] 陣列變數名稱( 自訂 ) = {陣列的內容};
            ViewData["Photo"] += $"<div style='text-align:center'><img src='/images/{number}.jpg'><br><h3>{name[number-1]}</h></div>";
            return View();
        }

        public IActionResult ShowPhotoDetail()
        {
            for (int i = 1; i <= 8; i++)
            {
                ViewData["PhotoDetail"] += $"<a href='/Lesson1/ShowPhoto?number={i}'><img src='/images/{i}.jpg' width='200px'></a>";
                // 這裡是把圖片作為超連結的媒介，點擊圖片就會觸發超連結

            }
            return View();
        }
    }
}

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
3. Controllers( 控制器 ) : 負責判斷程式碼、處理資料、判斷使用者的請求
   ，並決定要傳什麼樣的資料到View( 使用者畫面 )
4. Views( 使用者畫面 ) : 把Controllers傳來的資料用HTML呈現給使用者看
*/

namespace CSharp.Controllers 
/* 
1. 命名空間( namespace ) : 用來組織程式碼的容器，如同資料夾，避免命名衝突
    ，這裡我們定義了一個CSharp.Controllers的命名空間
2. 一個solution裡可以有多個專案( project )，而這裡表示在我的solution中有個叫做CSharp的專案
    ，而這裡面寫的程式將是我這專案中負責處理controller功能的程式
*/

{
    public class CSharpController : Controller
    /*
    1. 建立一個公開的( public )控制器類別( class )，名叫CSharpController
        ，而且要繼承名為Controller的類別，也就是說
        ，CSharpController會擁有MVC控制器該有的功能( 像是處理網頁請求、傳資料給View等 )
    2. public是C#中的存取修飾詞( access modifier )
        ，寫在public後面的東西表示這個東西( 不論是變數、方法、類別等 )
        都可以被任何地方的程式碼存取
    3. 常用的修飾詞有public( 公開 )、private( 私有 )、protected( 保護 )、internal( 內部 )等
    補充 : 繼承就是從另一個類別( 在這裡是Controller )取得完全一樣的功能和屬性
    */

    {
        public IActionResult Index()
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
            return View();
            // 這行會回傳一個View結果，表示要顯示一個名叫Index.cshtml的View網頁畫面
        }

        public string Hello()
        // 這裡Hello()這個方法前面的資料型態是string，表示這個方法必須回傳一個字串
        {
            return "Hello, World";
            // 因此return回傳的內容必須是字串
        }
        /*
        這個寫法沒有用到View，沒有畫面排版，純粹使用後端程式輸出結果
        ，所以沒有用到ViewBag，也沒有建立一個新的View檔案
        => 用在純教學C#語法時的用途( 簡化理解 )
        */

        // 第一單元 : 資料型態與變數宣告
        public IActionResult CSharpTeach()
        {
            int number = 5;
            string user = "Soma";
            bool loggedIn = false;
            // 宣告三個變數( 有賦值 )，代表我要顯示的資料
            string result;
            // 宣告一個字串變數，變數名稱為result，還沒賦值

            ViewBag.Number = number;
            ViewBag.User = user;
            ViewBag.IsLoggedIn = loggedIn;
            /*
            1. ViewBag是一個用來傳資料到View的特殊物件
            2. .Number、.User、.IsLoggedIn是我自己定義的屬性名稱，並且在對應的View中可以取得值
                ，用@ViewBag.Number、@ViewBag.User、@ViewBag.IsLoggedIn的方式來取得
            3. 先在Controller裡設好變數，再用ViewBag傳給View顯示出來
            */

            return View();
            // 告訴MVC : 這個action執行完之後，要去找View檔案來顯示畫面
        }

        // 補充 : 資料型態
        public void Number()
        /* 
        1. 這裡Number()這個方法前面的資料型態是void，表示這個方法不會回傳任何東西
        2. 這個方法可以用來執行一些操作，但不會有任何回傳值
            ，例如：可以用來處理一些邏輯或是修改資料庫等
        */
        {
            int a = 10; // 宣告一個整數變數
            short b = 20; // 宣告一個短整數變數
            long c = 30; // 宣告一個長整數變數
            float d = 40.5f; // 宣告一個單精度浮點數變數，注意要加上f或F來表示這是float類型
            double e = 50.5; // 宣告一個雙精度浮點數變數，比float更精確，只是比較吃記憶體
        }

        public void Var()
        {
            string a = "Hello"; // 宣告一個字串變數
            bool b = true; // 宣告一個布林變數
        }

        public string Statement()
        {
            int a = 123;
            a += 10;
            a++;

            return "a等於" + a;
            // 因為Statement()方法前面的資料型態是string，所以return的值一定要是字串
        }
        /* 
        程式碼打完後如果跑不出來需要重新做編譯，在專案旁邊按右鍵選擇重建即可
        ，執行網址要加 : /controller名稱/action名稱 
        => http://localhost:5032/CSharp/Statement
        */

        // 第二單元 : 字串與運算
        public IActionResult StringAndMath()
        {
            string firstName = "Soma";
            string lastName = "Chou";
            string fullName = firstName + " " + lastName;

            int age = 31;
            int birthYear = 2025 - age;

            ViewBag.FullName = fullName;
            ViewBag.BirthYear = birthYear;

            return View();
        }

        // 第三單元 : 條件判斷
        public IActionResult GradeCheck()
        {
            int score = 78;
            string result;

            if (score >= 60)
            {
                result = "及格";
            }
            else
            {
                result = "不及格";
            }

            ViewBag.Score = score;
            ViewBag.Result = result;

            return View();
        }

        // 第四單元 : 使用者輸入 + 條件判斷
        /*
        1. 使用者輸入就是建立一個有參數的action，讓使用者在網址上輸入參數的值
            ，這個叫做Query String傳參數
        2. 有參數的action可以讓使用者在網址中傳入資料，要先打問號再寫參數以及參數值
            網址範例 : http://localhost:5032/Csharp/IfStatement?score=70
        */

        public IActionResult CheckScore(int score)
        // 寫法一 : if-else條件判斷
        {
            string result;

            if (score >= 60 && score <= 100)
            {
                result = "及格";
            }
            else if (score >= 0 && score < 60)
            {
                result = "不及格";
            }
            else
            {
                result = "輸入錯誤，請輸入數字0~100";
            }

            ViewBag.Score = score;
            ViewBag.Result = result;

            return View();
        }
        /*
        寫法二 : 
        把所有的result = " "變成return " "，然後else if跟else都改成if即可，例如
        => result = "不及格"; 變成 return "不及格";
        因為每執行到return，判斷是true，這個方法就會結束
        ，所以可以不需要寫到else，而是把全部的條件判斷都獨立進行
        return => true => 結束方法;
        return => false => 繼續執行下一個條件判斷
        */


        // 第五單元 : 使用多個參數 + 計算功能
        public IActionResult CheckBMI(double height, double weight)
        // 網址輸入的參數範例 : http://localhost:5032/Csharp/CheckBMI?height=170&weight=60
        {
            string status; // 宣告一個字串變數，變數名稱為status，用來儲存BMI的結果
            double bmi = weight / Math.Pow(height / 100, 2);
            /* 
            1. 計算BMI，記得身高轉成公尺
            2. Math.Pow(底數, 指數)是C#中的數學函式，用來計算次方
                => 例如Math.Pow(2, 3)會計算2的3次方
                => 例如Math.Pow(5, 2)會計算5的2次方
            */

            if (bmi < 18.5)
            {
                status = "過輕";
            }
            else if (bmi < 24)
            {
                status = "正常";
            }
            else if (bmi < 27)
            {
                status = "過重";
            }
            else
            {
                status = "肥胖";
            }

            ViewBag.Height = height;
            ViewBag.Weight = weight;
            ViewBag.BMI = Math.Round(bmi, 2);
            // Math.Round(原始數值, 小數位數)是C#中用來四捨五入數值的數學函式
            ViewBag.Status = status;

            return View();
        }

        // 第六單元 : 表單處理
        // 顯示表單畫面( GET )
        [HttpGet] // 因為Get是預設的HTTP請求方法，所以這行可以省略，但Post不能省略
        public IActionResult InputForm()
        {
            return View();
        }

        // 接收表單資料( POST )
        [HttpPost] // 這行表示接下來的action只接受表單送出請求
        public IActionResult InputForm(string userName, int age)
        {
            ViewBag.UserName = userName;
            ViewBag.Age = age;

            return View(); // 回傳同一個 View
        }
        /*
        GET跟POST的差別 :
        1. GET傳資料是公開傳送的，不論是自己打在網址上，還是從網頁上點擊連結，都是GET傳資料
            ，但是需求的資料( 參數 )都會顯示在網址上
            => 常用在查詢資料、顯示資料等情況
        2. POST傳資料是把資料送到伺服端的程式，讓Controller去處理
            => 常用在新增、修改、刪除資料等情況
        3. GET是用來查詢、顯示畫面等功能，所以當如果沒有輸入參數，就會顯示最原始的網頁畫面，所以可以獨立存在
        4. POST是用來處理資料的，所以如果沒有輸入參數，就會顯示錯誤訊息
            ，因為POST需要有資料( 參數 )輸入進行處理，然後搭配GET顯示畫面，所以POST通常都會搭配GET一起使用
        */

        // 第七單元 : 動態畫面處理
        // 不同的action也可以放在同一個View裡面執行
        public IActionResult Welcome()
        {
            return View();
        }

        public IActionResult Countdown()
        {
            return View();
        }

        // 第八單元 : 條件樣式與錯誤訊息顯示技巧( Model Binding + 錯誤提示基礎 )
        [HttpGet] // 這行表示這個action只接受GET請求
        public IActionResult CheckScore2()
        {
            return View();
        }

        [HttpPost] // 這行表示這個action只接受POST請求
        // 如果兩個action名稱相同，但HTTP請求方法不同，沒有打上[HttpPost]就會跑不出畫面
        public IActionResult CheckScore2(int score)
        {
            string result;
            string color;

            if (score < 0 || score > 100)
            {
                result = "分數錯誤";
                color = "orange";
            }
            else if (score >= 60)
            {
                result = "及格";
                color = "green";
            }
            else
            {
                result = "不及格";
                color = "red";
            }

            ViewBag.Score = score;
            ViewBag.Result = result;
            ViewBag.Color = color;

            return View();
        }

        // 第九單元 : 迴圈與陣列
        // for迴圈 : 
        /*
        語法 :
        for (初始值; 條件; 增量值)
        {
            只要條件是true，就會重複執行這裡的程式碼
        }
        */
        public IActionResult LoopExample()
        {
            string result = ""; // 建立一個字串變數result，result是空字串，用來儲存迴圈結果

            for (int i = 1; i <= 10; i++)
            {
                result += i + " "; // 每個result的值中間都會有個空格隔開
            }

            ViewBag.LoopResult = result;
            return View();
        }

        // while迴圈 :
        /*
        語法 : 
        while (條件)
        {
            只要條件是true，就會重複執行這裡的程式碼
        }
        */
        public IActionResult WhileLoop()
        {
            int count = 1;
            string result = "";

            while (count <= 5)
            {
                result += count + " ";
                count++;
            }

            ViewBag.LoopResult = result;
            return View();
        }

        // foreach迴圈 :
        /*
        語法 : 
        foreach (資料型態 變數名稱 in 陣列或集合)
        {
            每次迴圈都會取出陣列或集合中的一個元素，並執行這裡的程式碼
        }
        */
        public IActionResult ForeachLoop()
        {
            string[] fruits = { "Apple", "Banana", "Mango", "Peach", "Orange" };
            string result = "";

            foreach (string fruit in fruits)
            {
                result += fruit + "<br />";
            }

            ViewBag.FruitList = result;
            return View();
        }

        // 雙陣列配合CSS
        public IActionResult Rainbow()
        {
            string[] names = { "紅", "橙", "黃", "綠", "藍", "電", "紫" };
            string[] colors = { "red", "orange", "yellow", "green", "blue", "deepskyblue", "purple" };

            string result = "";

            for (int i = 0; i < names.Length; i++)
            {
                result += $"<span style='color:{colors[i]}'>{names[i]}</span> ";
            }

            ViewBag.RainbowHtml = result;
            return View();
        }
    }
}

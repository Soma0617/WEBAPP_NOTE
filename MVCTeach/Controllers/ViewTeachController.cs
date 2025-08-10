using Microsoft.AspNetCore.Mvc;
using MVCTeach.Models;

namespace MVCTeach.Controllers
{
    public class ViewTeachController : Controller
    {
        /* 
        因為Index跟IndexRWD的程式碼幾乎一模一樣
        ，所以把裡面的內容直接寫成一個function來讓它們讀取
        ，然後Index跟IndexRWD就可以直接呼叫這個function來取得資料
        */
        private List<NightMarket> GetData()
        {
            string[] id = { "A01", "A02", "A03", "A04", "A05", "A06", "A07" };
            string[] name = { "夜市一", "夜市二", "夜市三", "夜市四", "夜市五", "夜市六", "夜市七" };
            string[] adress = { "地址一", "地址二", "地址三", "地址四", "地址五", "地址六", "地址七" };

            List<NightMarket> list = new List<NightMarket>();
            for (int i = 0; i < id.Length; i++)
            {
                NightMarket nm = new NightMarket();
                nm.Id = id[i];
                nm.Name = name[i];
                nm.Adress = adress[i];

                list.Add(nm);
            }

            return list;
        }
        public IActionResult Index()
        {
            /* 
            用陣列來存放資料 : 
            假設有三筆資料，每筆資料有三個欄位，要像下面這樣列
            ，如此一來不論有多少筆資料，都只會有三個陣列
            string[] id = { "001", "002", "003" };
            string[] name = { "菜名1", "菜名2", "菜名3" };
            string[] price = { "100", "200", "300" };
            => 程式碼說明 :
            1. 定義一個字串資料型態的陣列 
            => string[]
            2. 宣告變數( 變數名稱自訂 )來存放陣列裡的資料
            */

            /* 
            實際運用範例 : 
            string[] id = { "A01", "A02", "A03", "A04", "A05", "A06", "A07" };
            string[] name = { "夜市一", "夜市二", "夜市三", "夜市四", "夜市五", "夜市六", "夜市七" };
            string[] adress = { "地址一", "地址二", "地址三", "地址四", "地址五", "地址六", "地址七" };
            */

            /*
            利用泛型物件來存放資料
            1. 泛型物件 : 可以放任何資料型態的物件，但是在要使用的時候才決定要放什麼資料型態
            2. 語法 : List<資料型態> 物件名稱( 自訂 ) = new 建構子();
            3. List<NightMarket>中的NightMarket代表的是一個類別( class )
                ，所以這個泛型物件可以存放NightMarket類別的所有資料
            */
            /*
            List<NightMarket> list = new List<NightMarket>();
            for (int i = 0; i < id.Length; i++)
            {
                理解如下 : 
                NightMarket nm1 = new NightMarket();
                nm.Id = id[0];
                nm.Name = name[0];
                nm.Adress = adress[0];
                => 這樣表示第一個物件( nm )是三個陣列索引值都是第0個位置的資料

                NightMarket nm2 = new NightMarket();
                nm.Id = id[1];
                nm.Name = name[1];
                nm.Adress = adress[1];

                NightMarket nm3 = new NightMarket();
                nm.Id = id[2];
                nm.Name = name[2];
                nm.Adress = adress[2];
                所以寫成迴圈型態
                
                NightMarket nm = new NightMarket();
            
                
                程式碼說明 : 
                1. 定義一個資料型態是NightMarket類別的物件
                2. 宣告變數nm( 變數名稱自訂 )來存放NightMarket類別的物件
                3. new NightMarket();表示建立一個新的NightMarket類別的物件
                
               
                nm.Id = id[i];
                // 變數nm( NightMarket類別的物件 )，他的屬性( 欄位 )名稱叫做Id，用來存放id陣列的資料
                nm.Name = name[i];
                nm.Adress = adress[i];

                // 將資料存入泛型物件中，並且資料必須是相同的資料型態( 在這邊是NightMarket類別的物件 )
                list.Add(nm);
                // 要養成觀念，資料表就是類別( class )，欄位就是屬性( property )
            }
            

            return View(list);
            // 這樣寫可以直接把list物件傳到View，不需要再另外寫ViewData來傳
            */

            // 因為已經把程式碼寫在GetData()的函式裡了，呼叫GetData()方法來取得資料
            return View(GetData());
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult IndexRWD()
        {
            /*
            // 這個action要做的事跟上面Index的一樣，只是要用RWD的方式來呈現

            string[] id = { "A01", "A02", "A03", "A04", "A05", "A06", "A07" };
            string[] name = { "夜市一", "夜市二", "夜市三", "夜市四", "夜市五", "夜市六", "夜市七" };
            string[] adress = { "地址一", "地址二", "地址三", "地址四", "地址五", "地址六", "地址七" };

            List<NightMarket> list = new List<NightMarket>();
            for (int i = 0; i < id.Length; i++)
            {
                NightMarket nm = new NightMarket();
                nm.Id = id[i];
                nm.Name = name[i];
                nm.Adress = adress[i];

                list.Add(nm);
            }

            return View(list);
            */

            // 因為已經把程式碼寫在GetData()的函式裡了，呼叫GetData()方法來取得資料
            return View(GetData());
        }

        /*
        Details這個action的用途是顯示點開詳細資料後的畫面
        ，所以他的return View()不能直接呼叫GetData()，而是要取得GetData()之中的某些資料而已
        */
        public IActionResult Details(string id)
        {
            // List<NightMarket> list = GetData();可改成下面程式碼
            var list = GetData();

            // 這寫法是Linq的語法，用來查詢list中的資料，會很像SQL語法
            var result = (from n in list 
                         where n.Id == id // 篩選條件是NightMarket物件中Id屬性為參數id的夜市資料
                         select n).FirstOrDefault();
            /*
            把上面Linq寫法改成Lambda寫法 : 
            var result = list.Where(list => list.Id == id).OrderBy(list => list.Id).FirstOrDefault();
            */

            /*
            語法說明 : 
            1. n是list中的每一個NightMarket物件
            2. 篩選條件是NightMarket物件中Id屬性為A01的夜市資料
                ，但因為我並不是只是要A01的資料而是每一筆資料隨參數id設定來取得
            3. select n表示選擇符合條件的NightMarket物件作為欄位
            4. FirstOrDefault()表示只取第一筆符合條件的資料，如果沒有符合條件的資料則返回null
            5. 最後把整個答案存到result變數中，並用var來取代他的資料型態
            6. 網址寫法 : 後面接 
            => /ViewTeach/Details?id=A01 => 來取得參數是A01的夜市資料
            */
            return View(result);
            // 把最終結果result回傳到View中，這樣在View中就可以使用result來顯示詳細資料了
        }

        // 要做一個所有資料的列表頁面
        public IActionResult DataList(string id)
        {
            var list = GetData();
            /*
            目標 : 
            1. 在左側顯示夜市資料導覽列
            2. 點擊導覽列後在右側顯示夜市詳細內容
            */
            // 左側的導覽列 => 取得所有夜市的編號及名稱


            // 右側的主畫面 => 取得某一筆夜市資料的詳細內容
            // Lambda寫法 :
            var result = list.Where(list => list.Id == id).FirstOrDefault();
            
            return View(result);
        }
    }
}

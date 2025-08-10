using Microsoft.AspNetCore.Mvc;
using MVCTeach.Models;

namespace MVCTeach.Controllers
{
    public class FruitStore : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult FruitInfo() // 一次傳送一筆資料到View
        {
            var fruit = new Fruit // 這裡的Fruit是從Models命名空間引入的類別
            {
                Name = "蘋果",
                Color = "紅色",
                Price = 30.5m,
                Boss = "9安"
            };

            return View(fruit);
        }

        public IActionResult FruitsInfo() // 一次傳送多筆資料到View
        {
            var fruits = new List<Fruit>
            {
                new Fruit { Name = "蘋果", Color = "紅色", Price = 30, Boss = "9安" },
                new Fruit { Name = "香蕉", Color = "黃色", Price = 20, Boss = "安9" },

            };

            return View(fruits);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using System.Net;

namespace CodeFirstTeach.Models
{
    public class SeedData
    {
        /*
        筆記( 一.3.c. ) : 撰寫SeedData類別的內容
        (1) 撰寫靜態方法Initialize( IServiceProvider serviceProvider )
        (2) 撰寫Book及ReBook資料表內的初始資料程式
        (3) 撰寫上傳圖片的程式
        (4) 加上using()及判斷資料庫是否有資料的程式
        */
        // 撰寫靜態方法Initialize( IServiceProvider serviceProvider )
        public static void Initialize(IServiceProvider serviceProvider)
        {
            // 撰寫Book及ReBook資料表內的初始資料程式
            GuestBookContext context = new GuestBookContext(serviceProvider.GetRequiredService<DbContextOptions<GuestBookContext>>());

            context.Book.AddRange(
                new Book 
                { 
                    BookID = Guid.NewGuid().ToString(), // 我們設定的BookID是GUID，而不是自己取的號碼，而且要用ToString()把GUID轉成字串
                    Title = "C# 程式設計",
                    Discription = "這是一本關於C#程式設計的書籍",
                    Author = "作者一號",
                    Photo = ".jpg",
                    CreatedDate = DateTime.Now,
                },
                {
                    BookID = "書籍二號",
                    Title = "烹飪課",
                    Discription = "這是一本關於烹飪的書籍",
                    Author = "作者五號",
                    Photo = ".jpg",
                    CreatedDate = DateTime.Now,
                }
            )

            context.ReBook;
        }
    }
}

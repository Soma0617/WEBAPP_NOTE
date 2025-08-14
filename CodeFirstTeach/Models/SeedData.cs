using System.Net;
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
        // (1) 撰寫靜態方法Initialize( IServiceProvider serviceProvider )
        public static void Initialize(IServiceProvider serviceProvider)
        {
            // (4) 加上using()及判斷資料庫是否有資料的程式
            using (GuestBookContext context = new GuestBookContext(serviceProvider.GetRequiredService<DbContextOptions<GuestBookContext>>()))
            // 這裡的using()是用來確保在使用完GuestBookContext後能夠釋放資源
            {
                if (!context.Books.Any())
                /* 
                判斷Books資料表是否有資料，如果沒有資料，執行裡面程式碼
                ，但不用判斷ReBooks資料表是否有資料，因為ReBooks是依賴於Books的
                */
                {
                    // (2) 撰寫Book及ReBook資料表內的初始資料程式
                    // 因為GUID是會變化的，所以用陣列的方式取值，如果資料筆數再更多，就用each迴圈寫
                    string[] guid = { Guid.NewGuid().ToString(),
                Guid.NewGuid().ToString(), Guid.NewGuid().ToString(),
                Guid.NewGuid().ToString(), Guid.NewGuid().ToString() };
                    // 我們設定的BookID是GUID，而不是自己取的號碼，而且要用ToString()把GUID轉成字串

                    context.Books.AddRange(
                        new Book
                        {
                            BookID = guid[0], // 用陣列取值
                            Title = "C# 程式設計",
                            Description = "這是一本關於C#程式設計的書籍",
                            Author = "作者一號",
                            Photo = guid[0] + ".jpg",
                            CreatedDate = DateTime.Now,
                        },
                        new Book
                        {
                            BookID = guid[1],
                            Title = "烹飪課",
                            Description = "這是一本關於烹飪的書籍",
                            Author = "作者五號",
                            Photo = guid[1] + ".jpg",
                            CreatedDate = DateTime.Now,
                        },
                        new Book
                        {
                            BookID = guid[2],
                            Title = "估尼",
                            Description = "?????",
                            Author = "作者八號",
                            Photo = guid[2] + ".jpg",
                            CreatedDate = DateTime.Now,
                        },
                        new Book
                        {
                            BookID = guid[3],
                            Title = "鬼之副長",
                            Description = "超帥",
                            Author = "作者二號",
                            Photo = guid[3] + ".jpg",
                            CreatedDate = DateTime.Now,
                        },
                        new Book
                        {
                            BookID = guid[4],
                            Title = "叭哩補補",
                            Description = "補補里",
                            Author = "作者七號",
                            Photo = guid[4] + ".jpg",
                            CreatedDate = DateTime.Now,
                        }
                    );
                    context.SaveChanges();

                    context.ReBooks.AddRange(
                        new ReBook
                        {
                            ReBookID = Guid.NewGuid().ToString(),
                            Description = "111111",
                            Author = "作者一號",
                            CreatedDate = DateTime.Now,
                            BookID = guid[0] // ReBook的Foreign Key關聯到BookID
                            /* 
                            這裡回覆留言是關聯到BookID的guid[0]
                            ，也就表示這筆留言是對BookID為guid[0]的書籍的回覆
                            */
                        },
                        new ReBook
                        {
                            ReBookID = Guid.NewGuid().ToString(),
                            Description = "222222",
                            Author = "作者二號",
                            CreatedDate = DateTime.Now,
                            BookID = guid[0]
                        },
                        new ReBook
                        {
                            ReBookID = Guid.NewGuid().ToString(),
                            Description = "333333",
                            Author = "作者三號",
                            CreatedDate = DateTime.Now,
                            BookID = guid[2]
                        },
                        new ReBook
                        {
                            ReBookID = Guid.NewGuid().ToString(),
                            Description = "444444",
                            Author = "作者四號",
                            CreatedDate = DateTime.Now,
                            BookID = guid[4]
                        },
                        new ReBook
                        {
                            ReBookID = Guid.NewGuid().ToString(),
                            Description = "555555",
                            Author = "作者五號",
                            CreatedDate = DateTime.Now,
                            BookID = guid[4]
                        }
                    );
                    context.SaveChanges();

                    // (3) 撰寫上傳圖片的程式
                    string SeedPhotosPath = Path.Combine(Directory.GetCurrentDirectory(), "SeedPhotos"); // 取得專案中來源照片的路徑
                    string BookPhotosPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "BookPhotos"); // 取得上傳照片的目的路徑，在wwwroot中的BookPhotos資料夾

            string[] files = Directory.GetFiles(SeedPhotosPath); // 取得指定路徑中的所有檔案，並丟入陣列中
                    for (int i = 0; i < files.Length; i++)
                    {
                        string destFile = Path.Combine(BookPhotosPath, guid[i] + ".jpg"); // 組合目的路徑與檔案名稱
                        File.Copy(files[i], destFile); // 複製檔案到目的路徑
                    }
                }
            } // using()結束，確保釋放資源
        }
    }
}

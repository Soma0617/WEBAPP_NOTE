using Microsoft.EntityFrameworkCore;
namespace CodeFirstTeach.Models
{
    /*
    筆記( 一.2.c. ) : 撰寫GuestBookContext類別的內容
        (1)須繼承DbContext類別
        (2)撰寫依賴注入用的建構子
        (3)描述資料庫裡面的資料表
    */
    public class GuestBookContext : DbContext
    {
        // 撰寫依賴注入用的建構子( 這個是固定寫法 )
        public GuestBookContext(DbContextOptions<GuestBookContext> options)
            : base(options)
        {
        }

        // 描述資料庫裡面的資料表
        public virtual DbSet<Book> Books { get; set; } // 這裡的Books屬性代表資料庫中的Books資料表
        public virtual DbSet<ReBook> ReBooks { get; set; } // 這裡的ReBooks屬性代表資料庫中的ReBooks資料表
    }
}

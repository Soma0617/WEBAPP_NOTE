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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // 筆記( 一.2.g. ) : 在DbContext中使用Fluent API在GuestBookContext覆寫OnModelCreating方法
            // 設定Book的資料表結構
            modelBuilder.Entity<Book>(entity =>
            {
                // 設定Book的主鍵和屬性
                entity.HasKey(e => e.BookID).HasName("PK_BookID"); // 設定主鍵
                entity.Property(e => e.BookID) // 設定屬性
                .HasMaxLength(36)
                .IsUnicode(false); // BookID預設值為GUID

                // 設定Title的屬性
                entity.Property(e => e.Title)
                .HasMaxLength(30);

                // 設定Author的屬性
                entity.Property(e => e.Author)
                .HasMaxLength(20);

                // 設定Photo的屬性
                entity.Property(e => e.Photo)
                .HasMaxLength(40);

                // 設定CreatedDate的屬性
                entity.Property(e => e.CreatedDate)
                .HasColumnType("datetime"); // 設定為datetime資料型態
            });

            // 設定ReBook的資料表結構
            modelBuilder.Entity<ReBook>(entity =>
            {
                // 設定ReBook的主鍵和屬性
                entity.HasKey(e => e.ReBookID).HasName("PK_ReBookID"); // 設定主鍵
                entity.Property(e => e.ReBookID) // 設定屬性
                .HasMaxLength(36)
                .IsUnicode(false); // ReBookID預設值為GUID

                // 設定Author的屬性
                entity.Property(e => e.Author)
                .HasMaxLength(20);

                // 設定CreatedDate的屬性
                entity.Property(e => e.CreatedDate)
                .HasColumnType("datetime"); // 設定為datetime資料型態
            });


        }
    }
}

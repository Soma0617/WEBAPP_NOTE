using Microsoft.EntityFrameworkCore;

namespace CodeFirstExam.Models
{
    public class GuestBookExamContext : DbContext
    {
        public GuestBookExamContext(DbContextOptions<GuestBookExamContext> options)
            : base(options)
        {
        }

        // 描述資料庫裡面的資料表
        public virtual DbSet<BookExam> Books { get; set; } // 這裡的Books屬性代表資料庫中的Books資料表
        public virtual DbSet<ReBookExam> ReBooks { get; set; } // 這裡的ReBooks屬性代表資料庫中的ReBooks資料表
    }
}

using Microsoft.EntityFrameworkCore;

namespace CodeFirstExam.Models
{
    public class GuestBookExamContext : DbContext
    {
        public GuestBookExamContext(DbContextOptions<GuestBookExamContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BookExam> Books { get; set; }
        public virtual DbSet<ReBookExam> ReBooks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookExam>(entity =>
            {
                entity.HasKey(e => e.BookID).HasName("PK_BookExamID"); 
                entity.Property(e => e.BookID)
                .HasMaxLength(36)
                .IsUnicode(false); 

                entity.Property(e => e.Title)
                .HasMaxLength(30);

                entity.Property(e => e.Author)
                .HasMaxLength(20);

                entity.Property(e => e.Photo)
                .HasMaxLength(40);

                entity.Property(e => e.CreatedDate)
                .HasColumnType("datetime");
            });

            modelBuilder.Entity<ReBookExam>(entity =>
            {

                entity.HasKey(e => e.ReBookID).HasName("PK_ReBookExamID");
                entity.Property(e => e.ReBookID)
                .HasMaxLength(36)
                .IsUnicode(false); 

                entity.Property(e => e.Author)
                .HasMaxLength(20);

                entity.Property(e => e.CreatedDate)
                .HasColumnType("datetime");
            });


        }
    }
}

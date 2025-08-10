using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DBFirstTeach.Models;

public partial class dbStudentsContext : DbContext
/*
1. 建立一個名為dbStudentsContext的類別，這類別繼承類別DbContext
2. 表示這個資料庫叫做dbStudents
*/
{
    /*
    我要用的是空的建構子
    這邊是依賴注入，暫時用不上
    public dbStudentsContext(DbContextOptions<dbStudentsContext> options)
        : base(options)
    {
    }
    */

    // 筆記( 一.2.f. ) : 在dbStudentsContext.cs裡撰寫一個空的建構子
    public dbStudentsContext()
    {
    }

    // 筆記( 一.2.e. ) : 在dbStudentsContext.cs裡撰寫連線到資料庫的程式
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer("Data Source=Soma;Database=dbStudents;TrustServerCertificate=True;User ID=Soma0617;Password=soma830617");

    public virtual DbSet<tStudent> tStudent { get; set; }
    /*
    1. dbStudents資料庫中，有一個叫做tStudent的資料表
    2. tStudent資料表的內容寫在<tStudent>這個物件之中
    */

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<tStudent>(entity =>
        {
            entity.HasKey(e => e.fStuId).HasName("PK__tStudent__08E5BA956C043617");

            entity.Property(e => e.fStuId)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.fEmail).HasMaxLength(40);
            entity.Property(e => e.fName).HasMaxLength(30);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

/*
建置欄位規則有兩種方法 : 
1. 使用using System.ComponentModel.DataAnnotations;
   這個寫法搭配Display來建置屬性的規則是對初學者比較容易的寫法
   EX : [Display(Name = "留言編號")]
2. 寫在DBContext裡面
   這個寫法是對進階者比較容易的寫法，因為可以直接在DBContext裡面定義欄位規則
   EX : modelBuilder.Entity<Book>().Property(b => b.BookID).IsRequired().HasMaxLength(10);
*/
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Mvc;
namespace CodeFirstTeach.Models
{
    public partial class Book
    /* 
    筆記( 一.1.g. ) : 使用Partial Class的特性
    ，將MetaData類別標註於Models中對應的Book及ReBook類別上
    ( 在原始的Book及ReBook類別須在class前加上partial )
    => 目的是因為我們習慣在模型( Models )中建立乾淨的模型，而規則拉出來另外寫，再套用就好
    */
    {
        public string BookID { get; set; } = null!;
        // 留言編號採用GUID
        // { get; set; }叫做屬性封裝，get是取得屬性的值( getter )，set是設定屬性的值( setter )

        public string Title { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string Author { get; set; } = null!;

        public string? Photo { get; set; } = null!;
        /* 
        這樣寫是一筆留言只能留一張照片，如果一筆留言要能夠留多張照片
        ，要獨立做另一張資料表做一對多( 多值屬性 )
        */

        public DateTime CreatedDate { get; set; } = DateTime.Now;
        /* 
        1. CreatedDate這個屬性( 名稱自訂 )是我建立來記錄每一筆資料的建立時間
        2. DateTime是CreatedDate這個屬性的資料型態，代表日期與時間的資料型態
        3. Now是DateTime的靜態屬性，DateTime一樣代表資料型別，兩個一起寫代表取得目前的日期與時間
        4. DateTime.Now取得目前的日期跟時間，存入CreatedDate，所以CreatedDate會自動填入目前時間
        */

        /*
        筆記( 一.1.e. ) : 撰寫兩個類別間的關聯屬性做為未來資料表之間的關聯
        1. 這是一對多的關聯，一個主留言( Book )可以有多個回覆留言( ReBook )
            ，一個回覆留言只可以對一個主留言
        => Book是一， ReBook是多
        */
        public virtual List<ReBook>? ReBooks { get; set; }
    }
}

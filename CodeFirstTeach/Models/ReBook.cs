using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;

namespace CodeFirstTeach.Models
{
    public partial class ReBook
    /* 
    筆記( 一.1.g. ) : 使用Partial Class的特性
    ，將MetaData類別標註於Models中對應的Book及ReBook類別上
    ( 在原始的Book及ReBook類別須在class前加上partial )
    => 目的是因為我們習慣在模型( Models )中建立乾淨的模型，而規則拉出來另外寫，再套用就好
    */
    {
        public string ReBookID { get; set; } = null!;

        public string Discription { get; set; } = null!;

        public string Author { get; set; } = null!;

        public DateTime CreatedDate { get; set; } = DateTime.Now;
        // 這個屬性會自動產生目前時間，當新增一筆資料時，CreateDate會自動填入目前時間

        public string BookID { get; set; } = null!;
        // 語法說明 : ForeignKey是來自Book資料表中的BookID

        public virtual Book? Book { get; set; } // 一個ReBook只能對一個Book，所以不用寫List
    }
}

using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeFirstTeach.Models;

/*
在MataData中寫規則，然後帶到Book跟ReBook的類別，所以Book跟ReBook中就可以保持畫面乾淨，只寫屬性
*/
/* 
筆記(一.1.f.) : 建立一個叫做MeataData類別，把原先預設的MataData建立的class刪掉，把Book及ReBook類別中自己所添加的程式碼移植至MetaData類別中
*/
public class BookMetaData
{
    [Display(Name = "留言編號")]
    [StringLength(36, MinimumLength = 36)] // GUID的長度是36個字元
    [Key] // 因為這是P.K.主索引鍵，所以要加上[Key]屬性，這樣在資料庫端才會把這個建立成主索引鍵
    public string BookID { get; set; } = null!;
    // 留言編號採用GUID
    // { get; set; }叫做屬性封裝，get是取得屬性的值( getter )，set是設定屬性的值( setter )

    /*
    CodeFirst寫法中，資料型態轉成資料庫會自動對應
    1. string到時候轉成資料庫會轉成nvarchar(字母長度)，所以寫string需要寫StringLength來規定字母長度
    */

    [Display(Name = "留言標題")]
    [StringLength(30, MinimumLength = 5, ErrorMessage = "字數5~30之間")]
    [Required(ErrorMessage = "必填欄位")]
    public string Title { get; set; } = null!;

    [Display(Name = "留言內容")]
    [Required(ErrorMessage = "必填欄位")]
    [DataType(DataType.MultilineText)]
    // DataType(DataType.MultilineText)是用來指定這個欄位是多行文字輸入框
    public string Description { get; set; } = null!;

    [Display(Name = "留言者")]
    [Required(ErrorMessage = "必填欄位")]
    [StringLength(20, ErrorMessage = "最多20個字")]
    public string Author { get; set; } = null!;

    /*
    照片都會傳進我們設定的資料庫裡面，但如果檔名重複會導致本來的照片被覆蓋掉
    ，所以我們需要幫每張照片設定一個檔名來避免重複的問題
    因為這裡是一個留言只能留一張照片，所以只要用GUID來產生一個唯一的檔名就可以了
    => 照片檔名命名規則 : GUID + .jpg
    */
    [Display(Name = "留言圖片")]
    [StringLength(40)] // GUID的長度是36個字元，加上.jpg( 三個字加點，共四個字元 )後總長度是40個字元
    public string? Photo { get; set; } = null!;
    // 這樣寫是一筆留言只能留一張照片，如果一筆留言要能夠留多張照片，要獨立出另一張資料表做一對多( 多值屬性 )

    [Display(Name = "發布時間")]
    [DataType(DataType.DateTime)]
    [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd hh:mm:ss}")]
    /* 
    DisplayFormat是用來指定這個欄位在Views顯示時的格式
    1. {0}表示顯示時的格式，只有寫{0}表示沒有指定格式，所以會顯示成預設的格式
    2. {0:yyyy/MM/dd hh:mm:ss}表示顯示時的格式是yyyy/MM/dd hh:mm:ss
    */
    [HiddenInput]
    /* 
    這個表示在填表單時，會把這個屬性( 欄位 )從View上隱藏起來，不會顯示在畫面上
    ，因為這個時間欄位是自動產生的，不需要讓使用者填寫
    */
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    /* 
    1. CreatedDate這個屬性( 名稱自訂 )是我建立來記錄每一筆資料的建立時間
    2. DateTime是CreatedDate這個屬性的資料型態，代表日期與時間的資料型態
    3. Now是DateTime的靜態屬性，DateTime一樣代表資料型別，兩個一起寫代表取得目前的日期與時間
    4. DateTime.Now取得目前的日期跟時間，存入CreatedDate，所以CreatedDate會自動填入目前時間
    */
}

public class ReBookMetaData
{
    [Display(Name = "留言編號")]
    [StringLength(36, MinimumLength = 36)]
    [Key]
    public string ReBookID { get; set; } = null!;

    [Display(Name = "留言內容")]
    [Required(ErrorMessage = "必填欄位")]
    [DataType(DataType.MultilineText)]
    public string Description { get; set; } = null!;

    [Display(Name = "留言者")]
    [Required(ErrorMessage = "必填欄位")]
    [StringLength(20, ErrorMessage = "最多20個字")]
    public string Author { get; set; } = null!;

    [Display(Name = "發布時間")]
    [DataType(DataType.DateTime)]
    [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd hh:mm:ss}")]
    [HiddenInput]
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    // 這個屬性會自動產生目前時間，當新增一筆資料時，CreateDate會自動填入目前時間

    /*
    筆記( 一.1.e. ) : 撰寫兩個類別間的關聯屬性做為未來資料表之間的關聯
    1. 這是一對多的關聯，一個主留言( Book )可以有多個回覆留言( ReBook )
        ，一個回覆留言只可以對一個主留言
    => Book是一， ReBook是多
    */
    // 外來鍵屬性 : 當資料表一對多的時候，多的資料表中會有外來鍵( 在這裡對應的是BookID )
    [ForeignKey("Book")]
    public string BookID { get; set; } = null!;
    // 語法說明 : ForeignKey是來自Book資料表中的BookID
}

/* 
筆記( 一.1.g. ) : 使用Partial Class的特性
，將MetaData類別標註於Models中對應的Book及ReBook類別上
( 在原始的Book及ReBook類別須在class前加上partial )
=> 目的是因為我們習慣在模型( Models )中建立乾淨的模型，而規則拉出來另外寫，再套用就好
*/
[ModelMetadataType(typeof(BookMetaData))]
/* 
1. 透過[ModelMetadataType]，把叫做BookMetaData( 在MetaData中自訂的 )中的程式碼帶入叫做Book的partial class
2. typeof(型別名稱)會取得指定的型別( 這裡代表BookMetaData 這個類別的型別資訊 ) 
*/
public partial class Book
{
}

[ModelMetadataType(typeof(ReBookMetaData))]
public partial class ReBook
{
}
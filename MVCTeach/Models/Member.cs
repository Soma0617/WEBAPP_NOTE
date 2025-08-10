namespace MVCTeach.Models
{
    public class Member
    // 建立一個公開( public )的類別( class )叫做Member( 類別名稱 )
    {
        /*
        寫會員資料表的資料模型( 使用複雜繫結法必須要有MVC中的Model( 模型 ) ) : 
        1. 資料模型( Model )中的類別( class )就是資料表( 例如這裡在做會員資料表 )
        2. 資料模型中的資料表的欄位( column )就是class中的屬性( properties )
        3. 屬性( properties )就是用來定義資料表欄位中資料的資料型態、屬性名稱( 自訂 )
           以及是否可為空值
        */

        // Properties for Member model
        // 模型( Model )的屬性( properties )都要定義成public，然後寫上資料型態，再來是屬性名稱( 自訂 )
        public string MemberID { get; set; } = null!;
        /*
        製作第一個屬性( properties ) :
        1. 屬性名稱 : 會員編號( MemberID )
        2. get;set;用來定義這個( 屬性名稱叫做MemberID的 )屬性可以取值也可以給值
        3. = null!;表示此欄位不可空值，為必填欄位
        4. 完整解釋 : 建立一個公開的屬性( 欄位 )，資料型態為字串，屬性名稱( 欄位名稱 )叫做會員編號
            ，此屬性( 欄位 )可以被讀取和寫入，並且此屬性( 欄位 )不能為空值
        5. 如果要改欄位名稱要先在這裡改，再來才是Controller，再來是View
        */
        public string MemberName { get; set; } = null!; 
        // 製作第二個屬性 : 會員姓名
        public string? Address { get; set; }
        /*
        製作第三個屬性 : 
        1. 屬性名稱 : 地址( Address )
        2. ?表示此欄位可以為空值( 不填資料 )
        */
        public string Phone { get; set; } = null!; 
        // 製作第四個屬性 : 電話
        public bool Gender { get; set; } 
        // 製作第五個屬性 : 性別( true : 男性, false : 女性 )
    }
}

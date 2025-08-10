using System.ComponentModel.DataAnnotations;
// 使用Display時，一定要引入這個命名空間

namespace MVCTeach.Models
{
    public class NightMarket
    {
        [Display(Name = "編號")]
        [Required(ErrorMessage="必填")]
        [RegularExpression("A[0-9]{3}", ErrorMessage = "編號格式有誤")]
        public string Id { get; set; } // 夜市編碼
        /*
        完整解釋 : 建立一個公開的屬性( 欄位 )，資料型態為字串，屬性名稱( 欄位名稱 )叫做夜市編碼
        ，此屬性( 欄位 )可以被讀取和寫入
        */

        [Display(Name = "夜市名稱")]
        [Required(ErrorMessage = "必填")]
        [StringLength(20, ErrorMessage = "最長20個字")]
        public string Name { get; set; } // 夜市名稱

        [Display(Name = "地址")]
        [Required(ErrorMessage = "必填")]
        public string Adress { get; set; } // 地址
        /*
        語法 : 
        1. [Display(Name = "欄位要顯示的名稱")]
        補充 : Display屬性常用的參數
        a. Name = "顯示名稱"
        b. Description = "說明文字"
        c. Prompt = "提示文字"
        d. ShortName = "簡短名稱"
        2. [Required(ErrorMessage = "錯誤訊息")]
        補充 : Required屬性常用的參數
        a. ErrorMessage = "驗證失敗時顯示的錯誤訊息"
        b. AllowEmptyStrings = true/false ( 是否允許空字串 )
        3. [RegularExpression("正規表達式", ErrorMessage = "錯誤訊息")]
        補充 : RegularExpression屬性常用的參數
        a. 正規表達式 = 用於驗證輸入值是否符合特定模式( 不同的需求會有不同的正規表達式 )
        b. ErrorMessage = "驗證失敗時顯示的錯誤訊息"
        4. [StringLength(最大字數, MinimumLength = 數字, ErrorMessage = "最長只能20個字")]
        補充 : 
        a. 最大字數是必填的，只要輸入數字就好
        b. MinimumLength = 數字 ( 可寫可不寫，表示最小字數 )
        c. ErrorMessage = "驗證失敗時顯示的錯誤訊息"
        */
    }
}

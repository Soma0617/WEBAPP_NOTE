using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations; // 要寫[Dispay]一定要有這個程式碼

namespace DBFirstTeach.Models;

public partial class tStudent
{
    // 筆記( 三.2. ) : 撰寫在View上顯示的欄位內容( 需先寫上using System.ComponentModel.DataAnnotations )
    /*
    在Model中修改屬性( 欄位 )名稱可以讓所有有用到這個屬性的View都使用到新的名稱
    ，而且不用每個View都改內容，只需要統一管理Model就好，因此一開始建立一個完整的Model很重要
    */

    /*
    假設學號規則 : 
    1. 學號為必填欄位，並且長度是6個數字
    2. 學號第一碼是1~9數字，第二碼到第六碼都是0~9數字
    */
    [Display(Name = "學號")]
    [Required(ErrorMessage = "必填欄位")]
    [RegularExpression("[1-9][0-9]{5}", ErrorMessage = "學號為6個數字")]
    /* 
    RegularExpression(" ")語法 : 
    1. [1-9]表示第一碼是1~9的數字
    2. [0-9]{5}表示第二碼到第六碼都是0~9的數字，{5}表示重複五次
    補充 : 
    1. [A-Z0-9]表示這格可以是大寫英文字母A~Z任意一個字母或者數字0~9任意一個數字
    2. [ABCD]表示這格可以是A、B、C、D其中一個字母
    3. 切記一個[]內只代表一個字元
    */
    public string fStuId { get; set; } = null!;

    [Display(Name = "姓名")]
    [Required(ErrorMessage = "必填欄位")]
    [StringLength(30, ErrorMessage = "名字最多30個字")]
    public string fName { get; set; } = null!;

    [Display(Name = "伊媚兒")]
    [StringLength(40, ErrorMessage = "伊媚兒最多40個字")]
    [EmailAddress(ErrorMessage = "格式錯誤")]
    public string? fEmail { get; set; }

    [Display(Name = "分數")]
    [Range(0, 100, ErrorMessage = "成績介於0~100之間")]
    public int? fScore { get; set; }
}

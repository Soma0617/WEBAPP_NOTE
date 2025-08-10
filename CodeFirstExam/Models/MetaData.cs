using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeFirstExam.Models;

public class BookExamMetaData
{
    [Display(Name = "留言編號")]
    [StringLength(36, MinimumLength = 36)]
    [Key]
    public string BookID { get; set; } = null!;

    [Display(Name = "留言標題")]
    [StringLength(30, MinimumLength = 5, ErrorMessage = "字數5~30之間")]
    [Required(ErrorMessage = "必填欄位")]
    public string Title { get; set; } = null!;

    [Display(Name = "留言內容")]
    [Required(ErrorMessage = "必填欄位")]
    [DataType(DataType.MultilineText)]
    public string Discription { get; set; } = null!;

    [Display(Name = "留言者")]
    [Required(ErrorMessage = "必填欄位")]
    [StringLength(20, ErrorMessage = "最多20個字")]
    public string Author { get; set; } = null!;

    [Display(Name = "留言圖片")]
    [StringLength(40)]
    public string? Photo { get; set; } = null!;

    [Display(Name = "發布時間")]
    [DataType(DataType.DateTime)]
    [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd hh:mm:ss}")]
    [HiddenInput]

    public DateTime CreateDate { get; set; } = DateTime.Now;
}

public class ReBookExamMetaData
{
    [Display(Name = "留言編號")]
    [StringLength(36, MinimumLength = 36)]
    [Key]
    public string ReBookID { get; set; } = null!;

    [Display(Name = "留言內容")]
    [Required(ErrorMessage = "必填欄位")]
    [DataType(DataType.MultilineText)]
    public string Discription { get; set; } = null!;

    [Display(Name = "留言者")]
    [Required(ErrorMessage = "必填欄位")]
    [StringLength(20, ErrorMessage = "最多20個字")]
    public string Author { get; set; } = null!;

    [Display(Name = "發布時間")]
    [DataType(DataType.DateTime)]
    [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd hh:mm:ss}")]
    [HiddenInput]
    public DateTime CreateDate { get; set; } = DateTime.Now;

    [ForeignKey("BookExam")]
    public string BookID { get; set; } = null!;
}

[ModelMetadataType(typeof(BookExamMetaData))]
public partial class BookExam
{
}

[ModelMetadataType(typeof(ReBookExamMetaData))]
public partial class ReBookExam
{
}

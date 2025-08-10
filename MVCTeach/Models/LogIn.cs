using System.ComponentModel.DataAnnotations;

namespace MVCTeach.Models
{
    public class LogIn
    {
        [Display(Name = "帳號")]
        [Required(ErrorMessage = "必填欄位")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "輸入5~20個字")]
        public string UserName { get; set; } = null!;

        [Display(Name = "密碼")]
        [Required(ErrorMessage = "必填欄位")]
        [DataType(DataType.Password)]
        [MinLength(8, ErrorMessage = "最少8個字")]
        [MaxLength(20, ErrorMessage = "最多20個字")]
        public string Password { get; set; } = null!;
    }
}

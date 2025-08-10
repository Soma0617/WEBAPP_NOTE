using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;

namespace CodeFirstExam.Models
{
    public partial class ReBookExam
    {
        [StringLength(36, MinimumLength = 36)]
        [Key]
        public string ReBookID { get; set; } = null!;

        public string Discription { get; set; } = null!;

        public string Author { get; set; } = null!;

        public DateTime CreateDate { get; set; } = DateTime.Now;

        public string BookID { get; set; } = null!;

        public virtual BookExam? Books { get; set; }
    }
}

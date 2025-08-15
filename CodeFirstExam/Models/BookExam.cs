using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;

namespace CodeFirstExam.Models
{
    public partial class BookExam
    {
        [Key]
        [StringLength(36, MinimumLength = 36)]
        public string BookID { get; set; } = null!;

        public string Title { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string? Photo { get; set; } = null!;

        public string Author { get; set; } = null!;

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public virtual List<ReBookExam>? ReBooks { get; set; }
    }
}

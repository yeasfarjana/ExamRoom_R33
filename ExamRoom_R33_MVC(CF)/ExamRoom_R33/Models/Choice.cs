using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ExamRoom_R33.Models
{
    public class Choice
    {
        [Key]
        public int Id { get; set; }
        public int QuestionId { get; set; }

        [Display(Name = "Option")]
        [Required(ErrorMessage = "You can't leave it blank.")]
        public string Label { get; set; }

        [Display(Name = "Mark")]
        [Required(ErrorMessage = "You can't leave it blank.")]
        [Range(0, 100, ErrorMessage = ("You can't set negative or above 100 number to a option."))]
        public int Points { get; set; }
        public bool IsActive { get; set; }
        public virtual Question Question { get; set; }
        public virtual ICollection<TestXPaper> TestXPapers { get; set; }
        public virtual ICollection<TestXXPaper> TestXXPapers { get; set; }
    }
}
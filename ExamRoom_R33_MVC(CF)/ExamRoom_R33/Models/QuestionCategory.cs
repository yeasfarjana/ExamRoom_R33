using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ExamRoom_R33.Models
{
    public class QuestionCategory
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "You can't leave it blank.")]
        [Display(Name = "Question Category")]
        public string Category { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
    }
}
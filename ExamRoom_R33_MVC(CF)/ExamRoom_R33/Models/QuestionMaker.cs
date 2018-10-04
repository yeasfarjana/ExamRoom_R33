using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ExamRoom_R33.Models
{
    public class QuestionMaker
    {
        public int QuestionMakerID { get; set; }

        [Display(Name = "Question Maker Name")]
        [Required(ErrorMessage = "You can't leave it blank.")]
        public string QuestionMakerName { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
    }
}
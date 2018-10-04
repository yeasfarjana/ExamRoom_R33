using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ExamRoom_R33.Models
{
    public class TestXPaper
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Registration Id")]
        public int RegistrationId { get; set; }

        [Display(Name = "Text Question")]
        public int TextXQuestionId { get; set; }

        [Display(Name = "Choice")]
        public int ChoiceId { get; set; }

        public string Answer { get; set; }

        [Display(Name = "Mark Scored")]
        public decimal MarkScored { get; set; }

        public virtual Choice Choice { get; set; }
        public virtual Registration Registration { get; set; }
        public virtual TestXQuestion TestXQuestion { get; set; }
    }
}
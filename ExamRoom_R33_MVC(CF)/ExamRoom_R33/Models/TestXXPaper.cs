using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ExamRoom_R33.Models
{
    public class TestXXPaper
    {
        [Key]
        public int Id { get; set; }

        public int RegistrationId { get; set; }

        public int TextXQuestionId { get; set; }

        public int ChoiceId { get; set; }

        public string Answer { get; set; }

        public decimal MarkScored { get; set; }

        public virtual Choice Choice { get; set; }
        public virtual Registration Registration { get; set; }
        public virtual TestXQuestion TestXQuestion { get; set; }
    }
}
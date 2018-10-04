using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ExamRoom_R33.Models
{
    public class TestXQuestion
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Exam Name")]        
        public int TestId { get; set; }

        [Display(Name = "Question")]
        public int QuestionId { get; set; }

        [Display(Name = "Question Serial")]
        public int QuestionNumber { get; set; }
        public bool IsActive { get; set; }
        public virtual Question Question { get; set; }        
        public virtual Test Test { get; set; }
        public virtual ICollection<TestXPaper> TestXPapers { get; set; }
        public virtual ICollection<TestXXPaper> TestXXPapers { get; set; }
    }
}
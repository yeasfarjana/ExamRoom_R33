using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ExamRoom_R33.Models
{
    public class Registration
    {
        [Key]
        public int Id { get; set; }
        public Nullable<int> ExamineeId { get; set; }
        public Nullable<int> TestId { get; set; }

        [Display(Name = "Registration Date")]
        public DateTime RegistrationDate { get; set; }
        public Guid Token { get; set; }
        public DateTime TokenExpireTime { get; set; }

        public virtual Examinee Examinee { get; set; }
        public virtual Test Test { get; set; }
        
        public virtual ICollection<TestXPaper> TestXPapers { get; set; }
        public virtual ICollection<TestXXPaper> TestXXPapers { get; set; }
    }
}
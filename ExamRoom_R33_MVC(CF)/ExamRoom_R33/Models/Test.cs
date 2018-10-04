using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ExamRoom_R33.Models
{
    public class Test
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Exam Name")]
        [Required(ErrorMessage = "You can't leave it blank.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "You can't leave it blank.")]
        public string Description { get; set; }
        public bool IsActive { get; set; }

        [Display(Name = "Exam Duration in Minute")]
        [Range(1,180, ErrorMessage = ("You can't set 0 minute to a exam."))]
        public int DurationInMinute { get; set; }

        public virtual ICollection<Registration> Registrations { get; set; }
        public virtual ICollection<TestXQuestion> TestXQuestions { get; set; }
    }
}
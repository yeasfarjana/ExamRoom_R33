using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ExamRoom_R33.Models
{
    public class Examiner
    {
        public int ExaminerID { get; set; }

        [Display(Name = "Institute Admin Name")]
        public int InstituteAdminID { get; set; }

        [Required(ErrorMessage = "You can't leave it blank.")]
        [Display(Name = "Examiner Name")]
        public string UserName { get; set; }

        public virtual InstituteAdmin InstituteAdmin { get; set; }


    }
}
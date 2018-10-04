using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ExamRoom_R33.Models
{
    public class InstituteAdmin
    {
        public int InstituteAdminID { get; set; }

        [Required(ErrorMessage ="You can't leave it blank.")]
        [Display(Name = "Institute Admin Name")]
        public string InsAdminName { get; set; }

        [Required(ErrorMessage = "You can't leave it blank.")]
        [Display(Name = "Institute Name")]
        public string InstituteName { get; set; }

        public virtual ICollection<Examiner> Examiners { get; set; }

    }
}
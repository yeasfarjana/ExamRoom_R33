using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ExamRoom_R33.Models
{
    public class Examinee
    {
        public int ExamineeID { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "You can't leave it blank.")]
        [StringLength(maximumLength:15,ErrorMessage ="Maximum length of Name is 15 Character.")]
        public string Name { get; set; }

        [Display(Name = "Entry Date")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [Required(ErrorMessage = "You can't leave it blank.")]
        public DateTime EntryDate { get; set; }

        [Display(Name = "Date of Birth")]
        [DisplayFormat(DataFormatString ="{0:MM/dd/yyyy}")]
        [Required(ErrorMessage = "You can't leave it blank.")]
        public DateTime DOB { get; set; }

        [Required(ErrorMessage = "You can't leave it blank.")]
        public string Address { get; set; }

        [Display(Name ="Phone Number")]
        [RegularExpression("^([/+]88)?01[5-9]{1}[0-9]{8}$",ErrorMessage = "Phone number formate should be +8801XXXXXXXXX")]
        [Required(ErrorMessage = "You can't leave it blank.")]
        public string Phone { get; set; }

        [EmailAddress]
        [Remote("IsEmailAddressExists", "Examinee", ErrorMessage = "Email Address Already In Use!!!")]
        [Required(ErrorMessage = "You can't leave it blank.")]
        public string Email { get; set; }

        public virtual ICollection<Registration> Registrations { get; set; }
    }
}
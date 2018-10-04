using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ExamRoom_R33.Models
{
    public class Feedback
    {
        public int FeedbackID { get; set; }


        [Required(ErrorMessage = "You can't leave it blank.")]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }


        [Required(ErrorMessage = "You can't leave it blank.")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }


        [Required(ErrorMessage = "You can't leave it blank.")]
        public string PhoneNumber { get; set; }

        public string FeedbackScale { get; set; }
        public string Message { get; set; }
    }
}
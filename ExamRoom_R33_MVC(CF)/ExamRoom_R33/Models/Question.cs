using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ExamRoom_R33.Models
{
    public class Question
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Question Category")]
        public Nullable<int> QuestionCategoryId { get; set; }

        [Display(Name = "Question Type")]
        [Required(ErrorMessage = "You can't leave it blank.")]
        public string QuestionType { get; set; }

        [Display(Name = "Question")]
        [Required(ErrorMessage = "You can't leave it blank.")]
        public string Question1 { get; set; }

        [Display(Name = "Question Maker Name")]
        [Required(ErrorMessage = "You can't leave it blank.")]
        public Nullable<int> QuestionMakerID { get; set; }

        [Display(Name = "Mark")]
        [Required(ErrorMessage = "You can't leave it blank.")]
        [Range(1,100, ErrorMessage =("You can't set negative or above 100 number to a question."))]
        public int Points { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<Choice> Choices { get; set; }
        public virtual QuestionMaker QuestionMaker { get; set; }
        public virtual QuestionCategory QuestionCategory { get; set; }
        public virtual ICollection<TestXQuestion> TestXQuestions { get; set; }
    }
}
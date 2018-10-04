using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ExamRoom_R33.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public bool ConfirmedEmail { get; set; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<ExamRoom_R33.Models.InstituteAdmin> InstituteAdmins { get; set; }

        public System.Data.Entity.DbSet<ExamRoom_R33.Models.Examinee> Examinees { get; set; }

        public System.Data.Entity.DbSet<ExamRoom_R33.Models.Examiner> Examiners { get; set; }

        public System.Data.Entity.DbSet<ExamRoom_R33.Models.Feedback> Feedbacks { get; set; }
        public System.Data.Entity.DbSet<ExamRoom_R33.Models.ExamAudit> ExamAudits { get; set; }
        public System.Data.Entity.DbSet<ExamRoom_R33.Models.QuestionMaker> QuestionMakers { get; set; }
        public System.Data.Entity.DbSet<ExamRoom_R33.Models.Registration> Registrations { get; set; }
        public System.Data.Entity.DbSet<ExamRoom_R33.Models.Test> Tests { get; set; }
        public System.Data.Entity.DbSet<ExamRoom_R33.Models.QuestionCategory> QuestionCategorys { get; set; }
        public System.Data.Entity.DbSet<ExamRoom_R33.Models.Question> Questions { get; set; }
        public System.Data.Entity.DbSet<ExamRoom_R33.Models.TestXPaper> TestXPapers { get; set; }
        public System.Data.Entity.DbSet<ExamRoom_R33.Models.TestXXPaper> TestXXPapers { get; set; }
        public System.Data.Entity.DbSet<ExamRoom_R33.Models.TestXQuestion> TestXQuestions { get; set; }
        public System.Data.Entity.DbSet<ExamRoom_R33.Models.Choice> Choices { get; set; }

    }
}
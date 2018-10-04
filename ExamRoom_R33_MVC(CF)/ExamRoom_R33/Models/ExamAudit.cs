using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExamRoom_R33.Models
{
    public class ExamAudit
    {
        public int ExamAuditID { get; set; }

        public string TableName { get; set; }
        public string ModifiedBy { get; set; }
        public string Action { get; set; }
        public DateTime Date { get; set; }
    }
}
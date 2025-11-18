using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace WebApplication1.Models
{
    public class FinancialGoalModel
    {
        public int GoalID { get; set; }
        public int UserID { get; set; }
        public string GoalName { get; set; }
        public decimal TargetAmount { get; set; }
        public decimal CurrentProgress { get; set; }
        public string TargetDate { get; set; } 
        public string Status { get; set; }
        public string CreatedAt { get; set; }
        public string UpdatedAt { get; set; }
        public decimal ProgressPercent { get; set; }
    }
}
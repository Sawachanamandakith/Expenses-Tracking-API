using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace WebApplication1.Models.RequestApiModels
{
    public class FinancialGoalRequestAPI : RequestAPI
    {
        public int? GoalID { get; set; }
        public int? UserID { get; set; }
        public string GoalName { get; set; }
        public decimal? TargetAmount { get; set; }
        public decimal? CurrentProgress { get; set; }
        public DateTime? TargetDate { get; set; }
        public string Status { get; set; }
    }
}
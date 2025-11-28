using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace WebApplication1.Models
{
    public class TaskBudgetItemModel
    {
        public int ItemID { get; set; }
        public int TaskID { get; set; }
        public string ItemName { get; set; }
        public string Category { get; set; }
        public decimal EstimatedCost { get; set; }
        public string Note { get; set; }
        public string Status { get; set; }
        public string CreatedAt { get; set; }
        public string UpdatedAt { get; set; }
    }
}
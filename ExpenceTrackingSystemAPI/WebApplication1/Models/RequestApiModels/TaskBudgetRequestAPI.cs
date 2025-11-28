
using System;

namespace WebApplication1.Models.RequestApiModels
{
    public class TaskBudgetRequestAPI : RequestAPI
    {
        // Task Fields
        public int? TaskID { get; set; }
        public int? UserID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public decimal? MaxBudget { get; set; }

        // Item Fields
        public int? ItemID { get; set; }
        public string ItemName { get; set; }
        public string Category { get; set; }

        // FIXED: Must be decimal to match SP
        public decimal? EstimatedCost { get; set; }

        // FIXED: Must exactly match SP parameter @Note
        public string Note { get; set; }
    }
}


//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Text;

//namespace WebApplication1.Models.RequestApiModels
//{
//    public class TaskBudgetRequestAPI : RequestAPI
//    {
//        // Task Fields
//        public int? TaskID { get; set; }
//        public int? UserID { get; set; }
//        public string Name { get; set; }
//        public string Description { get; set; }
//        public DateTime? StartDate { get; set; }
//        public DateTime? EndDate { get; set; }
//        public decimal? MaxBudget { get; set; }

//        // Item Fields
//        public int? ItemID { get; set; }
//        public string ItemName { get; set; }
//        public string Category { get; set; }


//        public string EstimatedCost { get; set; }
//        public string Note { get; set; }
//    }
//}

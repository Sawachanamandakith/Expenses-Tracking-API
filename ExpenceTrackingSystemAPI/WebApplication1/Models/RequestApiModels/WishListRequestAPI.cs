using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace WebApplication1.Models.RequestApiModels
{
    public class WishListRequestAPI : RequestAPI
    {
        public int? WishID { get; set; }
        public int? UserID { get; set; }
        public string ItemName { get; set; }
        public decimal? EstimatedCost { get; set; }
        public string Priority { get; set; }
        public string TargetDate { get; set; }
        public string Status { get; set; }
    }
}
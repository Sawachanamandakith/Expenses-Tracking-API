using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace WebApplication1.Models.RequestApiModels
{
    public class TransactionRequestAPI : RequestAPI
    {
        public int? TransactionID { get; set; }
        public int? UserID { get; set; }
        public string Type { get; set; }       
        public string Name { get; set; }
        public DateTime? Date { get; set; }
        public decimal? Amount { get; set; }
        public string Category { get; set; }
        public string Note { get; set; }
        public string Status { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}

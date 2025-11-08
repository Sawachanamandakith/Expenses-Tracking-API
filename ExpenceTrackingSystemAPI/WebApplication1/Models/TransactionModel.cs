using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace WebApplication1.Models
{
    public class TransactionModel
    {
        public int TransactionID { get; set; }
        public int UserID { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string Date { get; set; }
        public decimal Amount { get; set; }
        public string Category { get; set; }
        public string Note { get; set; }
        public string Status { get; set; }
        public string CreatedAt { get; set; }
        public string UpdatedAt { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace WebApplication1.Models
{
    public class CategorySummaryModel
    {
        public string Category { get; set; }
        public string Type { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace WebApplication1.Models.RequestApiModels
{
    public class CategoryRequestAPI : RequestAPI
    {
        public string CategoryName { get; set; }
        public string Status { get; set; } = "Active";
    }
}
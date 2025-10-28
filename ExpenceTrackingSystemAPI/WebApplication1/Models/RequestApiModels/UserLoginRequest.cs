using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace WebApplication1.Models.RequestApiModels
{
    public class UserLoginRequest : RequestAPI
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
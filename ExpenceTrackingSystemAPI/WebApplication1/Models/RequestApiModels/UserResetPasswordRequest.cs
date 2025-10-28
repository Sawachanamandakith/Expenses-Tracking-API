using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace WebApplication1.Models.RequestApiModels
{
    public class UserResetPasswordRequest : RequestAPI
    {
        public string Password { get; set; }
        public string ResetPasswordToken { get; set; }
    }
}
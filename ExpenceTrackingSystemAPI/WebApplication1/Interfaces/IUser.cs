using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1.Models.RequestApiModels;

namespace WebApplication1.Interfaces
{
    public interface IUser
    {
        Response Register(UserRequestAPI request);

        Response Login(UserLoginRequest request);
        Response ForgotPassword(UserForgotPasswordRequest request);

        Response ResetPassword(UserResetPasswordRequest request);
    }
}

using biZTrack.Static;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebApplication1.Database_Layer;
using WebApplication1.Interfaces;
using WebApplication1.Models;
using WebApplication1.Models.RequestApiModels;

namespace WebApplication1.DataAccess
{
    public class DAUser : IUser
    {
        private readonly string ProcedureName = "sp_UserActions";

        public Response Register(UserRequestAPI requestAPI)
        {
            Response result = new Response();
            try
            {

                requestAPI.ActionType = "1";
                using (var dbConnect = new DBconnect())
                {
                    ProcedureDBModel res = dbConnect.ProcedureRead(requestAPI, ProcedureName);
                    if (res.ResultStatusCode == "1")
                    {
                        result.StatusCode = 200;
                        result.Result = "User registered successfully!";
                    }
                    else if (res.ResultStatusCode == "-1")
                    {
                        result.StatusCode = 409;
                        result.Result = "User already exists.";
                    }
                    else
                    {
                        result.StatusCode = 500;
                        result.Result = "Error occurred.";
                        LogHandler.WriteToLog(res.ExceptionMessage, System.Reflection.MethodBase.GetCurrentMethod().Name);
                    }
                }
            }
            catch (Exception ex)
            {
                result.StatusCode = 500;
                result.Result = "Exception occurred while adding user.";
                LogHandler.WriteToLog(ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
            return result;

        }
        public Response Login(UserLoginRequest requestAPI)
        {
            Response result = new Response();
            try
            {
                requestAPI.ActionType = "2"; 

                using (var dbConnect = new DBconnect())
                {
          
                    ProcedureDBModel res = dbConnect.ProcedureRead(requestAPI, ProcedureName);

                    if (res.ResultStatusCode == "1")
                    {
                        result.StatusCode = 200;
                        result.Result = "Login successful!";
                    }
                    else if (res.ResultStatusCode == "-1")
                    {
                        result.StatusCode = 401;
                        result.Result = "Invalid email or password.";
                    }
                    else
                    {
                        result.StatusCode = 500;
                        result.Result = "Error occurred.";
                        LogHandler.WriteToLog(res.ExceptionMessage, System.Reflection.MethodBase.GetCurrentMethod().Name);
                    }
                }
            }
            catch (Exception ex)
            {
                result.StatusCode = 500;
                result.Result = "Exception occurred while logging in.";
                LogHandler.WriteToLog(ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }

            return result;
        }
        public Response ForgotPassword(UserForgotPasswordRequest requestAPI)
        {
            Response result = new Response();
            try
            {

                requestAPI.ActionType = "3";

                using (var dbConnect = new DBconnect())
                {

                    ProcedureDBModel res = dbConnect.ProcedureRead(requestAPI, ProcedureName);


                    if (res.ResultStatusCode == "1")
                    {
                        result.StatusCode = 200;
                        result.Result = "Reset token updated successfully!";
                    }
                    else if (res.ResultStatusCode == "-1")
                    {
                        result.StatusCode = 404;
                        result.Result = "User not found.";
                    }
                    else
                    {
                        result.StatusCode = 500;
                        result.Result = "An unexpected error occurred.";
                        LogHandler.WriteToLog(res.ExceptionMessage, System.Reflection.MethodBase.GetCurrentMethod().Name);
                    }
                }
            }
            catch (Exception ex)
            {

                result.StatusCode = 500;
                result.Result = "Exception occurred while updating reset token.";
                LogHandler.WriteToLog(ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }

            return result;
        }
        public Response ResetPassword(UserResetPasswordRequest requestAPI)
        {
            Response result = new Response();
            try
            {
                requestAPI.ActionType = "4";

                using (var dbConnect = new DBconnect())
                {
                  
                    ProcedureDBModel res = dbConnect.ProcedureRead(requestAPI, ProcedureName);

                 
                    if (res.ResultStatusCode == "1")
                    {
                        result.StatusCode = 200;
                        result.Result = "Password reset successfully!";
                    }
                    else if (res.ResultStatusCode == "-1")
                    {
                        result.StatusCode = 404;
                        result.Result = "Invalid or expired reset token.";
                    }
                    else if (res.ResultStatusCode == "-2")
                    {
                        result.StatusCode = 400;
                        result.Result = "Password and Reset Token are required.";
                    }
                    else
                    {
                        result.StatusCode = 500;
                        result.Result = "An unexpected error occurred during password reset.";
                        LogHandler.WriteToLog(res.ExceptionMessage, System.Reflection.MethodBase.GetCurrentMethod().Name);
                    }
                }
            }
            catch (Exception ex)
            {
                result.StatusCode = 500;
                result.Result = "Exception occurred while resetting password.";
                LogHandler.WriteToLog(ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }

            return result;
        }

    }
}
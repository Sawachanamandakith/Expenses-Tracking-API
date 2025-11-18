using biZTrack.Static;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using WebApplication1.Database_Layer;
using WebApplication1.Interfaces;
using WebApplication1.Models;
using WebApplication1.Models.RequestApiModels;

namespace WebApplication1.DataAccess
{
    public class DAFinancialGoal : IFinancialGoal
    {
        private readonly string ProcedureName = "sp_FinancialGoals";

        // 1️⃣ ADD FINANCIAL GOAL
        public Response AddFinancialGoal(FinancialGoalRequestAPI request)
        {
            Response result = new Response();
            try
            {
                request.ActionType = "1"; // Add
                if (string.IsNullOrEmpty(request.Status))
                    request.Status = "A"; // Default Active

                using (var dbConnect = new DBconnect())
                {
                    ProcedureDBModel res = dbConnect.ProcedureRead(request, ProcedureName);

                    if (res.ResultStatusCode == "1")
                    {
                        result.StatusCode = 200;
                        result.Result = "Financial goal added successfully!";
                    }
                    else
                    {
                        result.StatusCode = 500;
                        result.Result = res.Result ?? "Error while adding goal.";
                        LogHandler.WriteToLog(res.ExceptionMessage, System.Reflection.MethodBase.GetCurrentMethod().Name);
                    }
                }
            }
            catch (Exception ex)
            {
                result.StatusCode = 500;
                result.Result = "Exception occurred while adding financial goal.";
                LogHandler.WriteToLog(ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
            return result;
        }

        // 2️⃣ UPDATE FINANCIAL GOAL
        public Response UpdateFinancialGoal(FinancialGoalRequestAPI request)
        {
            Response result = new Response();
            try
            {
                request.ActionType = "2"; // Update
                if (string.IsNullOrEmpty(request.Status))
                    request.Status = "A";

                using (var dbConnect = new DBconnect())
                {
                    ProcedureDBModel res = dbConnect.ProcedureRead(request, ProcedureName);

                    if (res.ResultStatusCode == "1")
                    {
                        result.StatusCode = 200;
                        result.Result = "Financial goal updated successfully!";
                    }
                    else
                    {
                        result.StatusCode = 500;
                        result.Result = res.Result ?? "Error while updating goal.";
                        LogHandler.WriteToLog(res.ExceptionMessage, System.Reflection.MethodBase.GetCurrentMethod().Name);
                    }
                }
            }
            catch (Exception ex)
            {
                result.StatusCode = 500;
                result.Result = "Exception occurred while updating financial goal.";
                LogHandler.WriteToLog(ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
            return result;
        }

        // 3️⃣ GET ALL FINANCIAL GOALS
        public Response GetAllFinancialGoals(FinancialGoalRequestAPI request)
        {
            Response result = new Response();
            request.ActionType = "3"; // GetAll

            try
            {
                using (var dbConnect = new DBconnect())
                {
                    ProcedureDBModel res = dbConnect.ProcedureRead(request, ProcedureName);

                    if (res.ResultStatusCode == "1")
                    {
                        List<FinancialGoalModel> goals = new List<FinancialGoalModel>();
                        foreach (DataRow row in res.ResultDataTable.Rows)
                        {
                            FinancialGoalModel goal = new FinancialGoalModel
                            {
                                GoalID = Convert.ToInt32(row["GoalID"]),
                                UserID = Convert.ToInt32(row["UserID"]),
                                GoalName = row["GoalName"].ToString(),
                                TargetAmount = Convert.ToDecimal(row["TargetAmount"]),
                                CurrentProgress = Convert.ToDecimal(row["CurrentProgress"]),
                                //TargetDate = Convert.ToDateTime(row["TargetDate"]),
                                TargetDate = row["TargetDate"].ToString(),
                                Status = row["Status"].ToString(),
                                CreatedAt = row["CreatedAt"].ToString(),
                                UpdatedAt = row["UpdatedAt"].ToString(),
                                ProgressPercent = Convert.ToDecimal(row["ProgressPercent"])
                            };
                            goals.Add(goal);
                        }

                        result.StatusCode = 200;
                        result.ResultSet = goals;
                    }
                    else
                    {
                        result.StatusCode = 500;
                        result.Result = res.ExceptionMessage;
                        LogHandler.WriteToLog(res.ExceptionMessage, System.Reflection.MethodBase.GetCurrentMethod().Name);
                    }
                }
            }
            catch (Exception ex)
            {
                result.StatusCode = 500;
                result.Result = "Exception occurred while retrieving goals.";
                LogHandler.WriteToLog(ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }

            return result;
        }
    }
}
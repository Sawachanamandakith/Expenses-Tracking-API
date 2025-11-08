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
    public class DATransaction : ITransaction
    {
        private readonly string ProcedureName = "sp_Transactions";


        // ADD TRANSACTION

        public Response AddTransaction(TransactionRequestAPI requestAPI)
        {
            Response result = new Response();
            try
            {
                requestAPI.ActionType = "1"; // Add
                if (string.IsNullOrEmpty(requestAPI.Status))
                    requestAPI.Status = "Active"; // ✅ Default to Active if not provided

                using (var dbConnect = new DBconnect())
                {
                    ProcedureDBModel res = dbConnect.ProcedureRead(requestAPI, ProcedureName);

                    if (res.ResultStatusCode == "1")
                    {
                        result.StatusCode = 200;
                        result.Result = "Transaction added successfully!";
                    }
                    else if (res.ResultStatusCode == "-1")
                    {
                        result.StatusCode = 500;
                        result.Result = "Error while adding transaction.";
                        LogHandler.WriteToLog(res.ExceptionMessage, System.Reflection.MethodBase.GetCurrentMethod().Name);
                    }
                    else
                    {
                        result.StatusCode = 400;
                        result.Result = res.Result ?? "Unknown error occurred.";
                    }
                }
            }
            catch (Exception ex)
            {
                result.StatusCode = 500;
                result.Result = "Exception occurred while adding transaction.";
                LogHandler.WriteToLog(ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }

            return result;
        }

        // UPDATE TRANSACTION

        public Response UpdateTransaction(TransactionRequestAPI requestAPI)
        {
            Response result = new Response();
            try
            {
                requestAPI.ActionType = "2"; // Update
                if (string.IsNullOrEmpty(requestAPI.Status))
                    requestAPI.Status = "Active"; // ✅ Keep Active by default unless changed

                using (var dbConnect = new DBconnect())
                {
                    ProcedureDBModel res = dbConnect.ProcedureRead(requestAPI, ProcedureName);

                    if (res.ResultStatusCode == "1")
                    {
                        result.StatusCode = 200;
                        result.Result = "Transaction updated successfully!";
                    }
                    else
                    {
                        result.StatusCode = 500;
                        result.Result = "Error while updating transaction.";
                        LogHandler.WriteToLog(res.ExceptionMessage, System.Reflection.MethodBase.GetCurrentMethod().Name);
                    }
                }
            }
            catch (Exception ex)
            {
                result.StatusCode = 500;
                result.Result = "Exception occurred while updating transaction.";
                LogHandler.WriteToLog(ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
            return result;
        }


        // DELETE TRANSACTION

        public Response DeleteTransaction(TransactionRequestAPI requestAPI)
        {
            Response result = new Response();
            try
            {
                requestAPI.ActionType = "3"; // Delete
                using (var dbConnect = new DBconnect())
                {
                    ProcedureDBModel res = dbConnect.ProcedureRead(requestAPI, ProcedureName);
                    if (res.ResultStatusCode == "1")
                    {
                        result.StatusCode = 200;
                        result.Result = "Transaction deleted successfully!";
                    }
                    else
                    {
                        result.StatusCode = 500;
                        result.Result = "Error while deleting transaction.";
                        LogHandler.WriteToLog(res.ExceptionMessage, System.Reflection.MethodBase.GetCurrentMethod().Name);
                    }
                }
            }
            catch (Exception ex)
            {
                result.StatusCode = 500;
                result.Result = "Exception occurred while deleting transaction.";
                LogHandler.WriteToLog(ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
            return result;
        }


        // GET ALL TRANSACTIONS BY USER

        //public Response GetAllTransactions(TransactionRequestAPI request)
        //{
        //    Response result = new Response();
        //    try
        //    {
        //        TransactionRequestAPI requestAPI = new TransactionRequestAPI
        //        {
        //            ActionType = "4",
                    
        //        };

        //        using (var dbConnect = new DBconnect())
        //        {
        //            ProcedureDBModel res = dbConnect.ProcedureRead(requestAPI, ProcedureName);

        //            if (res.ResultStatusCode == "1")
        //            {
        //                List<TransactionModel> transactionList = new List<TransactionModel>();

        //                foreach (DataRow row in res.ResultDataTable.Rows)
        //                {
        //                    TransactionModel transaction = new TransactionModel
        //                    {
        //                        TransactionID = Convert.ToInt32(row["TransactionID"]),
        //                        UserID = Convert.ToInt32(row["UserID"]),
        //                        Type = row["Type"].ToString(),
        //                        Name = row["Name"].ToString(),
        //                        Date = row["Date"].ToString(),
        //                        Amount = Convert.ToDecimal(row["Amount"]),
        //                        Category = row["Category"].ToString(),
        //                        Note = row["Note"].ToString(),
        //                        Status = row["Status"].ToString(), // ✅ Include Status
        //                        CreatedAt = row["CreatedAt"].ToString(),
        //                        UpdatedAt = row["UpdatedAt"].ToString()
        //                    };
        //                    transactionList.Add(transaction);
        //                }

        //                result.StatusCode = 200;
        //                result.ResultSet = transactionList;
        //            }
        //            else
        //            {
        //                LogHandler.WriteToLog(res.ExceptionMessage, System.Reflection.MethodBase.GetCurrentMethod().Name);
        //                result.StatusCode = 500;
        //                result.Result = res.ExceptionMessage;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        result.StatusCode = 500;
        //        result.Result = "Exception occurred while retrieving transactions.";
        //        LogHandler.WriteToLog(ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
        //    }

        //    return result;
        //}
        public Response GetAllTransactions(TransactionRequestAPI requestAPI)
        {
            Response result = new Response();
            requestAPI.ActionType = "4";

            try
            {
                using (var dbConnect = new DBconnect())
                {
                    ProcedureDBModel res = dbConnect.ProcedureRead(requestAPI, ProcedureName);

                    if (res.ResultStatusCode == "1")
                    {
                        List<TransactionModel> dailyTotalsList = new List<TransactionModel>();
                        foreach (DataRow row in res.ResultDataTable.Rows)
                        {
                            TransactionModel daily = new TransactionModel
                            {
                                TransactionID = Convert.ToInt32(row["TransactionID"]),
                                UserID = Convert.ToInt32(row["UserID"]),
                                Type = row["Type"].ToString(),
                                Name = row["Name"].ToString(),
                                Date = row["Date"].ToString(),
                                Amount = Convert.ToDecimal(row["Amount"]),
                                Category = row["Category"].ToString(),
                                Note = row["Note"].ToString(),
                                Status = row["Status"].ToString(), 
                                CreatedAt = row["CreatedAt"].ToString(),
                                UpdatedAt = row["UpdatedAt"].ToString()
                            };
                            dailyTotalsList.Add(daily);
                        }

                        result.StatusCode = 200;
                        result.ResultSet = dailyTotalsList;
                    }
                    else
                    {
                        LogHandler.WriteToLog(res.ExceptionMessage, System.Reflection.MethodBase.GetCurrentMethod().Name);
                        result.StatusCode = 500;
                        result.Result = res.ExceptionMessage;
                    }
                }
            }
            catch (Exception ex)
            {
                result.StatusCode = 500;
                result.Result = "Exception while retrieving daily totals.";
                LogHandler.WriteToLog(ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }

            return result;
        }
        public Response GetAllInactiveTransactions(TransactionRequestAPI requestAPI)
        {
            Response result = new Response();
            requestAPI.ActionType = "11";

            try
            {
                using (var dbConnect = new DBconnect())
                {
                    ProcedureDBModel res = dbConnect.ProcedureRead(requestAPI, ProcedureName);

                    if (res.ResultStatusCode == "1")
                    {
                        List<TransactionModel> dailyTotalsList = new List<TransactionModel>();
                        foreach (DataRow row in res.ResultDataTable.Rows)
                        {
                            TransactionModel daily = new TransactionModel
                            {
                                TransactionID = Convert.ToInt32(row["TransactionID"]),
                                UserID = Convert.ToInt32(row["UserID"]),
                                Type = row["Type"].ToString(),
                                Name = row["Name"].ToString(),
                                Date = row["Date"].ToString(),
                                Amount = Convert.ToDecimal(row["Amount"]),
                                Category = row["Category"].ToString(),
                                Note = row["Note"].ToString(),
                                Status = row["Status"].ToString(),
                                CreatedAt = row["CreatedAt"].ToString(),
                                UpdatedAt = row["UpdatedAt"].ToString()
                            };
                            dailyTotalsList.Add(daily);
                        }

                        result.StatusCode = 200;
                        result.ResultSet = dailyTotalsList;
                    }
                    else
                    {
                        LogHandler.WriteToLog(res.ExceptionMessage, System.Reflection.MethodBase.GetCurrentMethod().Name);
                        result.StatusCode = 500;
                        result.Result = res.ExceptionMessage;
                    }
                }
            }
            catch (Exception ex)
            {
                result.StatusCode = 500;
                result.Result = "Exception while retrieving daily totals.";
                LogHandler.WriteToLog(ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }

            return result;
        }



        // GET TOTAL INCOME & EXPENSE

        public Response GetTotalIncomeExpense(int userId, DateTime? startDate, DateTime? endDate)
        {
            Response result = new Response();

            try
            {
                TransactionRequestAPI requestAPI = new TransactionRequestAPI
                {
                    ActionType = "7",
                    UserID = userId,
                    StartDate = startDate,
                    EndDate = endDate
                };

                using (var dbConnect = new DBconnect())
                {
                    ProcedureDBModel res = dbConnect.ProcedureRead(requestAPI, ProcedureName);

                    if (res.ResultStatusCode == "1" && res.ResultDataTable.Rows.Count > 0)
                    {
                        DataRow row = res.ResultDataTable.Rows[0];

                        var summary = new
                        {
                            TotalIncome = row["TotalIncome"] != DBNull.Value ? Convert.ToDecimal(row["TotalIncome"]) : 0,
                            TotalExpense = row["TotalExpense"] != DBNull.Value ? Convert.ToDecimal(row["TotalExpense"]) : 0
                        };

                        result.StatusCode = 200;
                        result.ResultSet = summary;
                    }
                    else
                    {
                        result.StatusCode = 204;
                        result.Result = "No data found for this period.";
                    }
                }
            }
            catch (Exception ex)
            {
                result.StatusCode = 500;
                result.Result = "Exception while calculating total income and expense.";
                LogHandler.WriteToLog(ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }

            return result;
        }


        // GET CATEGORY TOTALS

        public Response GetCategoryTotals(int userId, DateTime? startDate, DateTime? endDate)
        {
            Response result = new Response();
            try
            {
                TransactionRequestAPI requestAPI = new TransactionRequestAPI
                {
                    ActionType = "8",
                    UserID = userId,
                    StartDate = startDate,
                    EndDate = endDate
                };

                using (var dbConnect = new DBconnect())
                {
                    ProcedureDBModel res = dbConnect.ProcedureRead(requestAPI, ProcedureName);
                    if (res.ResultStatusCode == "1")
                    {
                        List<CategorySummaryModel> categoryTotals = new List<CategorySummaryModel>();
                        foreach (DataRow row in res.ResultDataTable.Rows)
                        {
                            CategorySummaryModel summary = new CategorySummaryModel
                            {
                                Category = row["Category"].ToString(),
                                Type = row["Type"].ToString(),
                                TotalAmount = Convert.ToDecimal(row["TotalAmount"])
                            };
                            categoryTotals.Add(summary);
                        }

                        result.StatusCode = 200;
                        result.ResultSet = categoryTotals;
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
                result.Result = "Exception while retrieving category totals.";
                LogHandler.WriteToLog(ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
            return result;
        }


        // GET DAILY TOTALS

        public Response GetDailyTotals(TransactionRequestAPI requestAPI)
        {
            Response result = new Response();
            requestAPI.ActionType = "9";

            try
            {
                using (var dbConnect = new DBconnect())
                {
                    ProcedureDBModel res = dbConnect.ProcedureRead(requestAPI, ProcedureName);

                    if (res.ResultStatusCode == "1")
                    {
                        List<DailyTotalsModel> dailyTotalsList = new List<DailyTotalsModel>();
                        foreach (DataRow row in res.ResultDataTable.Rows)
                        {
                            DailyTotalsModel daily = new DailyTotalsModel
                            {
                                Date = row["Date"].ToString(),
                                TotalIncome = row["TotalIncome"] != DBNull.Value ? Convert.ToDecimal(row["TotalIncome"]) : 0,
                                TotalExpense = row["TotalExpense"] != DBNull.Value ? Convert.ToDecimal(row["TotalExpense"]) : 0
                            };
                            dailyTotalsList.Add(daily);
                        }

                        result.StatusCode = 200;
                        result.ResultSet = dailyTotalsList;
                    }
                    else
                    {
                        LogHandler.WriteToLog(res.ExceptionMessage, System.Reflection.MethodBase.GetCurrentMethod().Name);
                        result.StatusCode = 500;
                        result.Result = res.ExceptionMessage;
                    }
                }
            }
            catch (Exception ex)
            {
                result.StatusCode = 500;
                result.Result = "Exception while retrieving daily totals.";
                LogHandler.WriteToLog(ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }

            return result;
        }


        // GET TOTALS IN RANGE

        public Response GetRangeTotals(TransactionRequestAPI requestAPI)
        {
            Response result = new Response();
            requestAPI.ActionType = "10";

            try
            {
                using (var dbConnect = new DBconnect())
                {
                    ProcedureDBModel res = dbConnect.ProcedureRead(requestAPI, ProcedureName);

                    if (res.ResultStatusCode == "1" && res.ResultDataTable.Rows.Count > 0)
                    {
                        DataRow row = res.ResultDataTable.Rows[0];

                        var totals = new
                        {
                            TotalIncome = row["TotalIncome"] != DBNull.Value ? Convert.ToDecimal(row["TotalIncome"]) : 0,
                            TotalExpense = row["TotalExpense"] != DBNull.Value ? Convert.ToDecimal(row["TotalExpense"]) : 0
                        };

                        result.StatusCode = 200;
                        result.ResultSet = totals;
                    }
                    else
                    {
                        result.StatusCode = 204;
                        result.Result = "No transactions found in this range.";
                    }
                }
            }
            catch (Exception ex)
            {
                result.StatusCode = 500;
                result.Result = "Exception while calculating range totals.";
                LogHandler.WriteToLog(ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }

            return result;
        }
    }
}

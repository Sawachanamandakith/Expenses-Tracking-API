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
    public class DAWishList : IWishList
    {
        private readonly string ProcedureName = "sp_WishList";

        // 1️⃣ ADD WISH
        public Response AddWish(WishListRequestAPI request)
        {
            Response result = new Response();
            try
            {
                request.ActionType = "1"; // Add wish
                using (var dbConnect = new DBconnect())
                {
                    ProcedureDBModel res = dbConnect.ProcedureRead(request, ProcedureName);

                    if (res.ResultStatusCode == "1")
                    {
                        result.StatusCode = 200;
                        result.Result = "Wish added successfully!";
                    }
                    else
                    {
                        result.StatusCode = 500;
                        result.Result = res.Result ?? "Error while adding wish.";
                        LogHandler.WriteToLog(res.ExceptionMessage, System.Reflection.MethodBase.GetCurrentMethod().Name);
                    }
                }
            }
            catch (Exception ex)
            {
                result.StatusCode = 500;
                result.Result = "Exception occurred while adding wish.";
                LogHandler.WriteToLog(ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
            return result;
        }

        // 2️⃣ MARK WISH AS COMPLETED
        public Response MarkWishCompleted(WishListRequestAPI request)
        {
            Response result = new Response();
            try
            {
                request.ActionType = "2"; // Mark completed
                using (var dbConnect = new DBconnect())
                {
                    ProcedureDBModel res = dbConnect.ProcedureRead(request, ProcedureName);

                    if (res.ResultStatusCode == "1")
                    {
                        result.StatusCode = 200;
                        result.Result = "Wish marked as completed!";
                    }
                    else
                    {
                        result.StatusCode = 500;
                        result.Result = res.Result ?? "Error while marking wish completed.";
                        LogHandler.WriteToLog(res.ExceptionMessage, System.Reflection.MethodBase.GetCurrentMethod().Name);
                    }
                }
            }
            catch (Exception ex)
            {
                result.StatusCode = 500;
                result.Result = "Exception occurred while marking wish completed.";
                LogHandler.WriteToLog(ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
            return result;
        }

        // 3️⃣ GET ALL ACTIVE WISHES BY USER
        public Response GetAllWishes(WishListRequestAPI request)
        {
            Response result = new Response();
            try
            {
                request.ActionType = "3"; // Get all
                using (var dbConnect = new DBconnect())
                {
                    ProcedureDBModel res = dbConnect.ProcedureRead(request, ProcedureName);
                    if (res.ResultStatusCode == "1" && res.ResultDataTable != null)
                    {
                        List<WishListModel> wishList = new List<WishListModel>();
                        foreach (DataRow row in res.ResultDataTable.Rows)
                        {
                            WishListModel wish = new WishListModel
                            {
                                WishID = Convert.ToInt32(row["WishID"]),
                                UserID = Convert.ToInt32(row["UserID"]),
                                ItemName = row["ItemName"].ToString(),
                                EstimatedCost = Convert.ToDecimal(row["EstimatedCost"]),
                                Priority = row["Priority"].ToString(),
                                TargetDate = row["TargetDate"].ToString(),
                                Status = row["Status"].ToString(),
                                CreatedAt = row["CreatedAt"].ToString(),
                                UpdatedAt = row["UpdatedAt"].ToString()
                            };
                            wishList.Add(wish);
                        }

                        result.StatusCode = 200;
                        result.ResultSet = wishList;
                    }
                    else
                    {
                        result.StatusCode = 204;
                        result.Result = "No wishes found.";
                    }
                }
            }
            catch (Exception ex)
            {
                result.StatusCode = 500;
                result.Result = "Exception occurred while fetching wishes.";
                LogHandler.WriteToLog(ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
            return result;
        }
    }
}
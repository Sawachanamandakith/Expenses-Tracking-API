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
    public class DACategory : ICategory
    {
        private readonly string ProcedureName = "sp_Category";

        // Add Category
        public Response AddCategory(CategoryRequestAPI requestAPI)
        {
            Response result = new Response();
            try
            {
                requestAPI.ActionType = "1"; // Add category

                using (var dbConnect = new DBconnect())
                {
                    ProcedureDBModel res = dbConnect.ProcedureRead(requestAPI, ProcedureName);
                    if (res.ResultStatusCode == "1")
                    {
                        result.StatusCode = 200;
                        result.Result = "Category added successfully!";
                    }
                    else if (res.ResultStatusCode == "-1")
                    {
                        result.StatusCode = 409;
                        result.Result = "Category already exists.";
                    }
                    else
                    {
                        result.StatusCode = 500;
                        result.Result = "Error occurred while adding category.";
                        LogHandler.WriteToLog(res.ExceptionMessage, System.Reflection.MethodBase.GetCurrentMethod().Name);
                    }
                }
            }
            catch (Exception ex)
            {
                result.StatusCode = 500;
                result.Result = "Exception occurred while adding category.";
                LogHandler.WriteToLog(ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
            return result;
        }
        // Get All Categories (Active + Full List)
        public Response GetAllCategories()
        {
            Response result = new Response();
            try
            {
                using (var dbConnect = new DBconnect())
                {

                    var requestAPI = new CategoryRequestAPI { ActionType = "2" };
                    ProcedureDBModel res = dbConnect.ProcedureRead(requestAPI, ProcedureName);

                    if (res.ResultStatusCode == "1")
                    {
                        List<CategoryModel> categoryList = new List<CategoryModel>();
                        foreach (DataRow row in res.ResultDataTable.Rows)
                        {
                            CategoryModel category = new CategoryModel
                            {
                                CategoryID = Convert.ToInt32(row["CategoryID"]),
                                CategoryName = row["CategoryName"].ToString(),
                                Status = row["Status"].ToString()
                            };
                            categoryList.Add(category);
                        }

                        result.StatusCode = 200;
                        result.ResultSet = categoryList;
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
                result.Result = "Exception while retrieving categories.";
                LogHandler.WriteToLog(ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
            return result;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data;
using WebApplication1.Database_Layer;
using WebApplication1.Interfaces;
using WebApplication1.Models;
using WebApplication1.Models.RequestApiModels;

namespace WebApplication1.DataAccess
{
    public class DATaskBudget : ITaskBudget
    {
        private readonly string ProcedureName = "sp_ETTaskBudgetPlanning";

        // 1 - ADD TASK
        public Response AddTask(TaskBudgetRequestAPI request)
        {
            Response result = new Response();
            try
            {
                request.ActionType = "1"; // Add Task

                using (var db = new DBconnect())
                {
                    var res = db.ProcedureRead(request, ProcedureName);

                    if (res.ResultStatusCode == "1")
                    {
                        result.StatusCode = 200;
                        result.Result = "Task added successfully!";
                    }
                    else
                    {
                        result.StatusCode = 500;
                        result.Result = res.Result;
                    }
                }
            }
            catch (Exception ex)
            {
                result.StatusCode = 500;
                result.Result = "Exception while adding task.";
            }

            return result;
        }

        // 2 - UPDATE TASK
        public Response UpdateTask(TaskBudgetRequestAPI request)
        {
            Response result = new Response();

            try
            {
                request.ActionType = "2"; // Update Task
                using (var db = new DBconnect())
                {
                    var res = db.ProcedureRead(request, ProcedureName);
                    result.StatusCode = res.ResultStatusCode == "1" ? 200 : 500;
                    result.Result = res.Result;
                }
            }
            catch
            {
                result.StatusCode = 500;
                result.Result = "Exception while updating task.";
            }

            return result;
        }

        // 3 - DELETE TASK
        public Response DeleteTask(TaskBudgetRequestAPI request)
        {
            Response result = new Response();

            try
            {
                request.ActionType = "3"; // Delete Task
                using (var db = new DBconnect())
                {
                    var res = db.ProcedureRead(request, ProcedureName);
                    result.StatusCode = res.ResultStatusCode == "1" ? 200 : 500;
                    result.Result = res.Result;
                }
            }
            catch
            {
                result.StatusCode = 500;
                result.Result = "Exception while deleting task.";
            }

            return result;
        }

        // 4 - GET ALL TASKS
        public Response GetAllTasks(TaskBudgetRequestAPI request)
        {
            Response result = new Response();
            request.ActionType = "4";

            try
            {
                using (var db = new DBconnect())
                {
                    var res = db.ProcedureRead(request, ProcedureName);

                    if (res.ResultStatusCode == "1")
                    {
                        List<TaskBudgetModel> tasks = new List<TaskBudgetModel>();

                        foreach (DataRow row in res.ResultDataTable.Rows)
                        {
                            tasks.Add(new TaskBudgetModel
                            {
                                TaskID = Convert.ToInt32(row["TaskID"]),
                                UserID = Convert.ToInt32(row["UserID"]),
                                Name = row["Name"].ToString(),
                                Description = row["Description"].ToString(),
                                StartDate = row["StartDate"].ToString(),
                                EndDate = row["EndDate"].ToString(),
                                MaxBudget = Convert.ToDecimal(row["MaxBudget"]),
                                EstimatedCost = Convert.ToDecimal(row["EstimatedTotal"]),
                                Status = row["Status"].ToString(),
                                CreatedAt = row["CreatedAt"].ToString(),
                                UpdatedAt = row["UpdatedAt"].ToString()
                            });
                        }

                        result.StatusCode = 200;
                        result.ResultSet = tasks;
                    }
                    else
                    {
                        result.StatusCode = 500;
                        result.Result = res.Result;
                    }
                }
            }
            catch
            {
                result.StatusCode = 500;
                result.Result = "Exception while fetching tasks.";
            }

            return result;
        }

        public Response GetTaskById(TaskBudgetRequestAPI request)
        {
            Response result = new Response();
            request.ActionType = "5";

            try
            {
                using (var db = new DBconnect())
                {
                    var res = db.ProcedureRead(request, ProcedureName);

                    if (res.ResultStatusCode == "1")
                    {
                        List<TaskBudgetModel> tasks = new List<TaskBudgetModel>();

                        foreach (DataRow row in res.ResultDataTable.Rows)
                        {
                            tasks.Add(new TaskBudgetModel
                            {
                                TaskID = Convert.ToInt32(row["TaskID"]),
                                UserID = Convert.ToInt32(row["UserID"]),
                                Name = row["Name"].ToString(),
                                Description = row["Description"].ToString(),
                                StartDate = row["StartDate"].ToString(),
                                EndDate = row["EndDate"].ToString(),
                                MaxBudget = Convert.ToDecimal(row["MaxBudget"]),
                                @EstimatedCost = Convert.ToDecimal(row["EstimatedTotal"]),
                                Status = row["Status"].ToString(),
                                CreatedAt = row["CreatedAt"].ToString(),
                                UpdatedAt = row["UpdatedAt"].ToString()
                            });
                        }

                        result.StatusCode = 200;
                        result.ResultSet = tasks;
                    }
                    else
                    {
                        result.StatusCode = 500;
                        result.Result = res.Result;
                    }
                }
            }
            catch
            {
                result.StatusCode = 500;
                result.Result = "Exception while fetching tasks.";
            }

            return result;
        }

        // 6 - ADD TASK ITEM
        //public Response AddTaskItem(TaskBudgetRequestAPI request)
        //{
        //    Response result = new Response();
        //    request.ActionType = "6";

        //    try
        //    {
        //        using (var db = new DBconnect())
        //        {
        //            var res = db.ProcedureRead(request, ProcedureName);
        //            result.StatusCode = res.ResultStatusCode == "1" ? 200 : 500;
        //            result.Result = res.Result;
        //        }
        //    }
        //    catch
        //    {
        //        result.StatusCode = 500;
        //        result.Result = "Exception while adding item.";
        //    }

        //    return result;
        //}
        public Response AddTaskItem(TaskBudgetRequestAPI request)
        {
            Response result = new Response();
            request.ActionType = "6";  // Add Item

            try
            {
                using (var db = new DBconnect())
                {
                    // Just call ProcedureRead passing the request object
                    var res = db.ProcedureRead(request, ProcedureName);

                    result.StatusCode = res.ResultStatusCode == "1" ? 200 : 500;
                    result.Result = res.Result;
                }
            }
            catch (Exception ex)   // Keep 'ex' for debugging if needed
            {
                result.StatusCode = 500;
                result.Result = "Exception while adding item: " + ex.Message;
            }

            return result;
        }



        // 7 - UPDATE ITEM
        public Response UpdateTaskItem(TaskBudgetRequestAPI request)
        {
            Response result = new Response();
            request.ActionType = "7";

            try
            {
                using (var db = new DBconnect())
                {
                    var res = db.ProcedureRead(request, ProcedureName);
                    result.StatusCode = res.ResultStatusCode == "1" ? 200 : 500;
                    result.Result = res.Result;
                }
            }
            catch
            {
                result.StatusCode = 500;
                result.Result = "Exception while updating item.";
            }

            return result;
        }

        // 8 - DELETE TASK ITEM
        public Response DeleteTaskItem(TaskBudgetRequestAPI request)
        {
            Response result = new Response();
            request.ActionType = "8";

            try
            {
                using (var db = new DBconnect())
                {
                    var res = db.ProcedureRead(request, ProcedureName);
                    result.StatusCode = res.ResultStatusCode == "1" ? 200 : 500;
                    result.Result = res.Result;
                }
            }
            catch
            {
                result.StatusCode = 500;
                result.Result = "Exception while deleting item.";
            }

            return result;
        }

        // 9 - GET TASK ITEMS
        public Response GetTaskItems(TaskBudgetRequestAPI request)
        {
            Response result = new Response();
            request.ActionType = "9";

            try
            {
                using (var db = new DBconnect())
                {
                    var res = db.ProcedureRead(request, ProcedureName);

                    if (res.ResultStatusCode == "1")
                    {
                        List<TaskBudgetItemModel> items = new List<TaskBudgetItemModel>();

                        foreach (DataRow row in res.ResultDataTable.Rows)
                        {
                            items.Add(new TaskBudgetItemModel
                            {
                                ItemID = Convert.ToInt32(row["ItemID"]),
                                TaskID = Convert.ToInt32(row["TaskID"]),
                                ItemName = row["ItemName"].ToString(),
                                Category = row["Category"].ToString(),
                                EstimatedCost = Convert.ToDecimal(row["EstimatedCost"]),
                                Note = row["Note"].ToString(),
                                Status = row["Status"].ToString(),
                                CreatedAt = row["CreatedAt"].ToString(),
                                UpdatedAt = row["UpdatedAt"].ToString()
                            });
                        }

                        result.StatusCode = 200;
                        result.ResultSet = items;
                    }
                    else
                    {
                        result.StatusCode = 500;
                        result.Result = res.Result;
                    }
                }
            }
            catch
            {
                result.StatusCode = 500;
                result.Result = "Exception while fetching items.";
            }

            return result;
        }

        // 10 - RECALCULATE TOTAL
        public Response RecalculateTaskTotal(TaskBudgetRequestAPI request)
        {
            Response result = new Response();
            request.ActionType = "10";

            try
            {
                using (var db = new DBconnect())
                {
                    var res = db.ProcedureRead(request, ProcedureName);
                    result.StatusCode = res.ResultStatusCode == "1" ? 200 : 500;
                    result.Result = res.Result;
                }
            }
            catch
            {
                result.StatusCode = 500;
                result.Result = "Exception while recalculating task total.";
            }

            return result;
        }
    }
}



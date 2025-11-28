using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using WebApplication1.Interfaces;
using WebApplication1.Models.RequestApiModels;

namespace WebApplication1.Controllers
{
    public class TaskBudgetController : Controller
    {
        private readonly ITaskBudget _taskBudget;

        public TaskBudgetController(ITaskBudget taskBudget)
        {
            _taskBudget = taskBudget;
        }

        [HttpPost]
        public ActionResult AddTask(TaskBudgetRequestAPI request)
        {
            var result = _taskBudget.AddTask(request);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult UpdateTask(TaskBudgetRequestAPI request)
        {
            var result = _taskBudget.UpdateTask(request);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult DeleteTask(TaskBudgetRequestAPI request)
        {
            var result = _taskBudget.DeleteTask(request);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetAllTasks(TaskBudgetRequestAPI request)
        {
            var result = _taskBudget.GetAllTasks(request);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        //[HttpGet]
        //public ActionResult GetAllTasks(int userId)
        //{
        //    TaskBudgetRequestAPI req = new TaskBudgetRequestAPI
        //    {
        //        UserID = userId
        //    };

        //    var result = _taskBudget.GetAllTasks(req);
        //    return Json(result, JsonRequestBehavior.AllowGet);
        //}

        [HttpGet]
        public ActionResult GetTaskById(int taskId)
        {
            TaskBudgetRequestAPI req = new TaskBudgetRequestAPI
            {
                TaskID = taskId
            };

            var result = _taskBudget.GetTaskById(req);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult AddTaskItem(TaskBudgetRequestAPI request)
        {
            var result = _taskBudget.AddTaskItem(request);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult UpdateTaskItem(TaskBudgetRequestAPI request)
        {
            var result = _taskBudget.UpdateTaskItem(request);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult DeleteTaskItem(TaskBudgetRequestAPI request)
        {
            var result = _taskBudget.DeleteTaskItem(request);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetTaskItems(int taskId)
        {
            TaskBudgetRequestAPI req = new TaskBudgetRequestAPI
            {
                TaskID = taskId
            };

            var result = _taskBudget.GetTaskItems(req);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult RecalculateTaskTotal(TaskBudgetRequestAPI request)
        {
            var result = _taskBudget.RecalculateTaskTotal(request);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}

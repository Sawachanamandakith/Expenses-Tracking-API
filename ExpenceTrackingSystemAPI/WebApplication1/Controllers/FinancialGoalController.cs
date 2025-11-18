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
    public class FinancialGoalController : Controller
    {
        private readonly IFinancialGoal _financialGoal;

        public FinancialGoalController(IFinancialGoal financialGoal)
        {
            _financialGoal = financialGoal;
        }

        [HttpPost]
        public ActionResult AddFinancialGoal(FinancialGoalRequestAPI request)
        {
            var result = _financialGoal.AddFinancialGoal(request);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult UpdateFinancialGoal(FinancialGoalRequestAPI request)
        {
            var result = _financialGoal.UpdateFinancialGoal(request);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetAllFinancialGoals(int userId)
        {
            FinancialGoalRequestAPI request = new FinancialGoalRequestAPI
            {
                UserID = userId
            };

            var result = _financialGoal.GetAllFinancialGoals(request);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using WebApplication1.Interfaces;
using WebApplication1.Models;
using WebApplication1.Models.RequestApiModels;

namespace WebApplication1.Controllers
{
    public class TransactionController : Controller
    {
        private readonly ITransaction _transaction;

        public TransactionController(ITransaction transaction)
        {
            _transaction = transaction;
        }
        [HttpPost]
        public ActionResult AddTransaction(TransactionRequestAPI transaction)
        {
            var result = _transaction.AddTransaction(transaction);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult UpdateTransaction(TransactionRequestAPI request)
        {
            var result = _transaction.UpdateTransaction(request);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult DeleteTransaction(TransactionRequestAPI request)
        {
            var result = _transaction.DeleteTransaction(request);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult GetAllTransactions(int userId)
        {
            var result = _transaction.GetAllTransactions(userId);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult GetAllInactiveTransactions(TransactionRequestAPI request)
        {
            var result = _transaction.GetAllInactiveTransactions(request);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult GetTotalIncomeExpense(int userId, DateTime? startDate = null, DateTime? endDate = null)
        {
            var result = _transaction.GetTotalIncomeExpense(userId, startDate, endDate);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult GetCategoryTotals(int userId, DateTime? startDate = null, DateTime? endDate = null)
        {
            var result = _transaction.GetCategoryTotals(userId, startDate, endDate);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult GetDailyTotals(int userId)
        {
            TransactionRequestAPI requestAPI = new TransactionRequestAPI

            {UserID = userId };

            var result = _transaction.GetDailyTotals(requestAPI);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult GetRangeTotals(int userId, DateTime? startDate = null, DateTime? endDate = null)
        {
            TransactionRequestAPI requestAPI = new TransactionRequestAPI
            
            {   UserID = userId,
                StartDate = startDate,
                EndDate = endDate   };

            var result = _transaction.GetRangeTotals(requestAPI);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}

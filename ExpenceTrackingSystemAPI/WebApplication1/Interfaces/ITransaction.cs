using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using WebApplication1.Models;
using WebApplication1.Models.RequestApiModels;

namespace WebApplication1.Interfaces
{
    public interface ITransaction
    {
        Response AddTransaction(TransactionRequestAPI request);

        Response UpdateTransaction(TransactionRequestAPI requestAPI);
        Response DeleteTransaction(TransactionRequestAPI requestAPI);
        Response GetAllTransactions(int userId);
        Response GetTotalIncomeExpense(int userId, DateTime? startDate, DateTime? endDate);
        Response GetCategoryTotals(int userId, DateTime? startDate, DateTime? endDate);
        Response GetDailyTotals(TransactionRequestAPI requestAPI);
        Response GetRangeTotals(TransactionRequestAPI requestAPI);
    }
}
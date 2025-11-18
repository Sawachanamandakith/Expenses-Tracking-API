using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1.Models.RequestApiModels;

namespace WebApplication1.Interfaces
{
    public interface IFinancialGoal
    {
        Response AddFinancialGoal(FinancialGoalRequestAPI request);
        Response UpdateFinancialGoal(FinancialGoalRequestAPI request);
        Response GetAllFinancialGoals(FinancialGoalRequestAPI request);
    }
}

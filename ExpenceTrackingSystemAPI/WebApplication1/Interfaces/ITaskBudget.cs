using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1.Models.RequestApiModels;

namespace WebApplication1.Interfaces
{
    public interface ITaskBudget
    {
        Response AddTask(TaskBudgetRequestAPI request);
        Response UpdateTask(TaskBudgetRequestAPI request);
        Response DeleteTask(TaskBudgetRequestAPI request);

        Response GetAllTasks(TaskBudgetRequestAPI request);
        Response GetTaskById(TaskBudgetRequestAPI request);

        Response AddTaskItem(TaskBudgetRequestAPI request);
        Response UpdateTaskItem(TaskBudgetRequestAPI request);
        Response DeleteTaskItem(TaskBudgetRequestAPI request);

        Response GetTaskItems(TaskBudgetRequestAPI request);
        Response RecalculateTaskTotal(TaskBudgetRequestAPI request);
    }
}

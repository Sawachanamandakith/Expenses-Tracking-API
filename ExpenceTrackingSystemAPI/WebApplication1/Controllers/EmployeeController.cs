using System.Web.Mvc;
using WebApplication1.Interfaces;
using WebApplication1.Models;
using WebApplication1.Models.RequestApiModels;

namespace WebApplication1.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployee _employee;

        public EmployeeController(IEmployee employee)
        {
            _employee = employee;
        }

        [HttpGet]
        public ActionResult GetAllEmployees(UserRequestAPI requestAPI)
        {
            var result = _employee.GetAllEmployees(requestAPI);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetEmployeeById(UserRequestAPI requestAPI)
        {
            var result = _employee.GetEmployeeById(requestAPI);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult AddEmployee(EmployeeModel employee)
        {
            var result = _employee.AddEmployee(employee);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPut]
        public ActionResult UpdateEmployee(EmployeeModel employee)
        {
            var result = _employee.UpdateEmployee(employee);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpDelete]
        public ActionResult DeleteEmployee(UserRequestAPI requestAPI)
        {
            var result = _employee.DeleteEmployee(requestAPI);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}

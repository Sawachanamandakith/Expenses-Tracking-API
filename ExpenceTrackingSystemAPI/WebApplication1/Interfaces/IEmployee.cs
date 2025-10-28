using WebApplication1.Models;
using WebApplication1.Models.RequestApiModels;

namespace WebApplication1.Interfaces
{
    public interface IEmployee
    {
        Response GetAllEmployees(UserRequestAPI requestAPI);
        Response GetEmployeeById(UserRequestAPI requestAPI);
        Response AddEmployee(EmployeeModel employee);
        Response UpdateEmployee(EmployeeModel employee);
        Response DeleteEmployee(UserRequestAPI requestAPI);
    }
}

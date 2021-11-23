using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestingApplication.Models;

namespace TestingApplication.WebApi.Repository
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetEmployees();
        Employee GetEmployee(int employeeId);
        Employee UpdateEmployee(Employee updatedEmployee);
    }
}

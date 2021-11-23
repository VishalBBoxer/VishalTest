using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestingApplication.Models;

namespace TestingApplication.Service
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetEmployees();
        Task<Employee> GetEmployee(int id);
        Task<Employee> UpdateEmployee(Employee updatedEmployee);
    }
}

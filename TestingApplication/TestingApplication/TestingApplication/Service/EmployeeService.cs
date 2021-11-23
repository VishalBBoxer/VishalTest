using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using TestingApplication.Models;
using System.Net.Http.Json;

namespace TestingApplication.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly HttpClient httpClient;

        public EmployeeService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await httpClient.GetFromJsonAsync<Employee[]>("api/employee");            
        }
        public async Task<Employee> GetEmployee(int id)
        {
            return await httpClient.GetFromJsonAsync<Employee>($"api/employee/{id}");
        }

        public async Task<Employee> UpdateEmployee(Employee updatedEmployee)
        {
            var result = await httpClient.PutAsJsonAsync<Employee>("api/employee", updatedEmployee);
            Employee employee = result.Content.ReadFromJsonAsync<Employee>().Result;
            return employee;
        }
    }
}

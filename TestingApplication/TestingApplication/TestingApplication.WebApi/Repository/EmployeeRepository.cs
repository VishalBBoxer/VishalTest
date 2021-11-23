using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using TestingApplication.Models;

namespace TestingApplication.WebApi.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public IEnumerable<Employee> Employees { get; set; }
        private string jsonFile = @"D:\TestingApplication\TestingApplication\TestingApplication.WebApi\Employee.json";
        public EmployeeRepository(IEnumerable<Employee> Employees)
        {
            this.Employees = Employees;
        }
        public IEnumerable<Employee> GetEmployees()
        {
            var json = File.ReadAllText(jsonFile);
            var jObject = JObject.Parse(json);
            try
            {
                if (json != null)
                {
                    var experienceArrary = jObject.GetValue("Employees") as JArray;
                    Employees = (List<Employee>)Newtonsoft.Json.JsonConvert.DeserializeObject(experienceArrary.ToString(), typeof(List<Employee>));                    
                }
                
                return Employees;
            }
            catch(Exception ex)
            {
                throw;
            }
            //return LoadEmployees();
        }
        private IEnumerable<Employee> LoadEmployees()
        {
            Employee e1 = new Employee
            {
                EmployeeId = 1,
                FirstName = "John",
                LastName = "Hastings",
                Email = "David@pragimtech.com",
                DateOfBirth = new DateTime(1980, 10, 5),
                //Gender = Gender.Male,
                //Department = new Department { DepartmentId = 1, DepartmentName = "IT" },
                //PhotoPath = "images/john.png"
            };

            Employee e2 = new Employee
            {
                EmployeeId = 2,
                FirstName = "Sam",
                LastName = "Galloway",
                Email = "Sam@pragimtech.com",
                DateOfBirth = new DateTime(1981, 12, 22),
                //Gender = Gender.Male,
                //Department = new Department { DepartmentId = 2, DepartmentName = "HR" },
                //PhotoPath = "images/sam.jpg"
            };

            Employee e3 = new Employee
            {
                EmployeeId = 3,
                FirstName = "Mary",
                LastName = "Smith",
                Email = "mary@pragimtech.com",
                DateOfBirth = new DateTime(1979, 11, 11),
                //Gender = Gender.Female,
                //Department = new Department { DepartmentId = 1, DepartmentName = "IT" },
                //PhotoPath = "images/mary.png"
            };

            Employee e4 = new Employee
            {
                EmployeeId = 4,
                FirstName = "Sara",
                LastName = "Longway",
                Email = "sara@pragimtech.com",
                DateOfBirth = new DateTime(1982, 9, 23),
                //Gender = Gender.Female,
                //Department = new Department { DepartmentId = 3, DepartmentName = "Payroll" },
                //PhotoPath = "images/sara.png"
            };

            return Employees = new List<Employee> { e1, e2, e3, e4 };
        }

        public Employee GetEmployee(int employeeId)
        {
            var json = File.ReadAllText(jsonFile);
            var jObject = JObject.Parse(json);
            try
            {
                if (json != null)
                {
                    var experienceArrary = jObject.GetValue("Employees") as JArray;
                    Employees = (List<Employee>)Newtonsoft.Json.JsonConvert.DeserializeObject(experienceArrary.ToString(), typeof(List<Employee>));
                }

                return Employees.FirstOrDefault(e => e.EmployeeId == employeeId);
            }
            catch (Exception ex)
            {
                throw;
            }
            //var emp = LoadEmployees();
            // return LoadEmployees().FirstOrDefault(e => e.EmployeeId == employeeId);
        }

        public Employee UpdateEmployee(Employee employee)
        {
            var json = File.ReadAllText(jsonFile);
            var jObject = JObject.Parse(json);
            try
            {
                var experienceArrary = jObject.GetValue("Employees") as JArray;
                if (json != null)
                {                    
                    Employees = (List<Employee>)Newtonsoft.Json.JsonConvert.DeserializeObject(experienceArrary.ToString(), typeof(List<Employee>));
                }


                foreach (Employee result in Employees)
                {

                    if (result.EmployeeId == employee.EmployeeId)
                    {
                        result.FirstName = employee.FirstName;
                        result.LastName = employee.LastName;
                        result.Email = employee.Email;
                        result.DateOfBirth = employee.DateOfBirth;

                    }
                
                }
                var result = Employees.FirstOrDefault(e => e.EmployeeId == employee.EmployeeId);
                if (result != null)
                {
                    result.FirstName = employee.FirstName;
                    result.LastName = employee.LastName;
                    result.Email = employee.Email;
                    result.DateOfBirth = employee.DateOfBirth;
                    //result.Gender = employee.Gender;
                    //result.DepartmentId = employee.DepartmentId;
                    //result.PhotoPath = employee.PhotoPath;
                    //string output = Newtonsoft.Json.JsonConvert.SerializeObject(ex);
                    //await appDbContext.SaveChangesAsync();                   
                   
                    var resp = experienceArrary.Where(obj => obj["EmployeeId"].Value<int>() == employee.EmployeeId);

                    JObject jObject1 = JObject.Parse(resp.ToString());

                    //   var myDetails = JsonConvert.DeserializeObject<Employee>(resp.ToString());
                    //   resp<JToken>["FirstName"] = employee.FirstName; 
                    //   myDetails.FirstName = employee.FirstName;
                    //Employees = (List<Employee>)Newtonsoft.Json.JsonConvert.DeserializeObject(resp.ToString(), typeof(List<Employee>));

                    //var jChild = JObject.str(resp.ToString());
                    //File.WriteAllText(jsonFile, result);
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw;
            }           

            return null;
        }
    }
}

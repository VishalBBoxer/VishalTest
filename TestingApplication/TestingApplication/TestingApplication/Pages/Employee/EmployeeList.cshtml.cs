using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TestingApplication.Service;


namespace TestingApplication.Pages.Employee
{
    public class EmployeeListModel : PageModel
    {        
        public IEmployeeService EmployeeService { get; set; }
        [BindProperty]
        public IEnumerable<TestingApplication.Models.Employee> Employees { get; set; }
        public EmployeeListModel(IEmployeeService EmployeeService)
        {
            this.EmployeeService = EmployeeService;
        }
        public async Task<ActionResult> OnGet()
        {
            Employees = await EmployeeService.GetEmployees();
            return Page();
        }
    }
}

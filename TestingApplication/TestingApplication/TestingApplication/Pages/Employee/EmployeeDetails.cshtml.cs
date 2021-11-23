using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TestingApplication.Service;

namespace TestingApplication.Pages.Employee
{
    public class EmployeeDetailsModel : PageModel
    {
        public IEmployeeService EmployeeService { get; set; }
        [BindProperty]
        public TestingApplication.Models.Employee Employees { get; set; }
        public EmployeeDetailsModel(IEmployeeService EmployeeService)
        {
            this.EmployeeService = EmployeeService;
        }
        public async Task<ActionResult> OnGet(int id)
        {
            Employees = await EmployeeService.GetEmployee(id);
            return Page();
        }
    }
}

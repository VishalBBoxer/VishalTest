using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TestingApplication.Service;


namespace TestingApplication.Pages.Employee
{
    public class AddOrEditModel : PageModel
    {
        public IEmployeeService EmployeeService { get; set; }
        [BindProperty]
        public TestingApplication.Models.Employee Employees { get; set; }
        public AddOrEditModel(IEmployeeService EmployeeService)
        {
            this.EmployeeService = EmployeeService;
        }
        public async Task<ActionResult> OnGet(int id)
        {
            Employees = await EmployeeService.GetEmployee(id);
            return Page();
        }       
        public async Task<IActionResult> OnPost(TestingApplication.Models.Employee employees)
        {
            Employees = await EmployeeService.UpdateEmployee(employees); ;
            //var result = await EmployeeService.UpdateEmployee(employees);
            //if (!string.IsNullOrEmpty(result.ToString()))
            //{
            //    Employees = result;
                return RedirectToPage("/Employee/EmployeeList");
            //}
            //else
            //{
            //    return Page();
            //}
        }
    }
}

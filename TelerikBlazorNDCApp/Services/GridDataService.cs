using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TelerikBlazorNDCApp.Models;

namespace TelerikBlazorNDCApp.Services
{
    public class GridDataService
    {
        public async Task<List<Employee>> GetEmployeesAsync()
        {
            return await Task.FromResult(GetEmployees());
        }

        public List<Employee> GetEmployees()
        {
            return new List<Employee>()
            {
                new Employee()
                {
                    EmployeeId = 1,
                    FirstName = "Yoana",
                    LastName = "Ivanova",
                    Title = "Software Engineer",
                    BirthDate = new DateTime(1992, 12, 10),
                    HireDate = new DateTime(2012, 11, 19)
                }
            };
        }
    }
}

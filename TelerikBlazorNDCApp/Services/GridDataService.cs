using System.Collections.Generic;
using System.Threading.Tasks;
using TelerikBlazorNDCApp.Models;

namespace TelerikBlazorNDCApp.Services
{
    public class GridDataService
    {
        public async Task<List<Customer>> GetCustomersAsync()
        {
            return await Task.FromResult(GetCustomers());
        }

        public List<Customer> GetCustomers()
        {
            return new List<Customer>()
            {
                new Customer()
                {
                    Id = 1,
                    Address = "Test1",
                    CompanyName = "test",
                    ContactName = "test",
                    ContactTitle = "test",
                    Country = "test",
                    Phone = "test"
                }
            };
        }
    }
}

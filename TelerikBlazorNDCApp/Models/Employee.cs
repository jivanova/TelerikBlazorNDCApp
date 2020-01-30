using System;
using System.ComponentModel.DataAnnotations;

namespace TelerikBlazorNDCApp.Models
{
    public class Employee
    {
        public Employee()
        {
        }

        public int EmployeeId { get; set; }

        [Required]
        [StringLength(20)]
        public string LastName { get; set; }

        [Required]
        [StringLength(10)]
        public string FirstName { get; set; }

        [StringLength(30)]
        public string Title { get; set; }

        public DateTime? BirthDate { get; set; }

        public DateTime? HireDate { get; set; }
    }
}

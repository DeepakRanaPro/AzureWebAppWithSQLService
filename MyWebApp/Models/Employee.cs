using System.ComponentModel.DataAnnotations;

namespace MyWebApp.Models
{
    public class Employee
    {
        public int EmpId { get; set; }
        public string? Name { get; set; }
        public decimal Salary { get; set; }
    }
}

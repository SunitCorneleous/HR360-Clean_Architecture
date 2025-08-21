using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; } = String.Empty;
        public string Department { get; set; } = String.Empty;
        public decimal Salary { get; set; }
    }
}

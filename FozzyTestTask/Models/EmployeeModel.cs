using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace FozzyTestTask.Models
{
    class EmployeeModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int SalaryType { get; set; }
        public float Salary { get; set; }
    }
}

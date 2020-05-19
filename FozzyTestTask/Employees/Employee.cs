using FozzyTestTask.Models;

namespace FozzyTestTask.Employees
{
    abstract class Employee
    {
        public EmployeeModel Specialist { get; set; }
        public abstract double Salary();
    }
}

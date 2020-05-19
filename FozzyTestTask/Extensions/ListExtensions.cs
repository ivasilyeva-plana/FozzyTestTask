using FozzyTestTask.Models;
using System;
using System.Collections.Generic;
using FozzyTestTask.Employees;

namespace FozzyTestTask.Extensions
{
    static class ListExtensions
    {

        public static List<Employee> ToEmployee(this IList<EmployeeModel> employeeStringList)
        {
            var result = new List<Employee>();
            foreach(var employee in employeeStringList)
            {
                
                switch (employee.SalaryType)
                {
                    case 1:
                        result.Add(new FixedPaymentEmployee {Specialist = employee });
                        break;
                    case 2:
                        result.Add(new HourlyPaymentEmployee {Specialist = employee});
                        break;
                    default:
                        throw new Exception("Salary Type should be 1 or 2 ");
                }
            }
            return result;

        }
    }

}

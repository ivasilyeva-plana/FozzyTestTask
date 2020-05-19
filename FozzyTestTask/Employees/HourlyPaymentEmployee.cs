namespace FozzyTestTask.Employees
{
    class HourlyPaymentEmployee : Employee
    {
        public override double Salary() => 20.8 * 8 * Specialist.Salary;
    }
}

namespace FozzyTestTask.Employees
{
    class FixedPaymentEmployee : Employee
    {
        public override double Salary() => Specialist.Salary;
    }
}

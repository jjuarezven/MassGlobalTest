namespace MassGlobalTest.Models
{
	public class MonthlyEmployee : EmployeeCalculated
	{
		public override double CalculateAnnualSalary(double salary)
		{
			return salary * 12;
		}
	}
}

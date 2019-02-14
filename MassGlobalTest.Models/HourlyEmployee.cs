namespace MassGlobalTest.Models
{
	public class HourlyEmployee : EmployeeCalculated
	{
		public override double CalculateAnnualSalary(double salary)
		{
			return 120 * salary * 12;
		}
	}
}

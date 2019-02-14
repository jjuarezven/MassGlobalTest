namespace MassGlobalTest.Models
{
	public class HourlyEmployee : EmployeeCalculated
	{
		public override decimal CalculateAnnualSalary(decimal salary)
		{
			return 120 * salary * 12;
		}
	}
}

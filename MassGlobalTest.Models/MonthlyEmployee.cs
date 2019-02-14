namespace MassGlobalTest.Models
{
	public class MonthlyEmployee : EmployeeCalculated
	{
		public override decimal CalculateAnnualSalary(decimal salary)
		{
			return salary * 12;
		}
	}
}

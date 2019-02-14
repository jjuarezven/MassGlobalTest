namespace MassGlobalTest.Models
{
	public abstract class EmployeeCalculated : Employee
	{
		public abstract decimal CalculateAnnualSalary(decimal salary);
	}
}

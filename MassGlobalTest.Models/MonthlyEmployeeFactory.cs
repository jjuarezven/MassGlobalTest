namespace MassGlobalTest.Models
{
	public class MonthlyEmployeeFactory : IEmployeeFactory
	{
		public EmployeeCalculated GetEmployee()
		{
			return new MonthlyEmployee();
		}
	}
}

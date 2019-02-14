namespace MassGlobalTest.Models
{
	public class HourlyEmployeeFactory : IEmployeeFactory
	{
		public EmployeeCalculated GetEmployee()
		{
			return new HourlyEmployee();
		}
	}
}

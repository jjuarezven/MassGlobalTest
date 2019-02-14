using MassGlobalTest.Models;
using System.Collections.Generic;

// Should implement DI Unity
namespace MassGlobalTest.BLL
{
	public interface IRules
	{
		IEnumerable<Employee> GetEmployees(int employeeId = 0);
	}
}

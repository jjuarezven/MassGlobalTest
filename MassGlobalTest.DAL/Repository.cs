using MassGlobalTest.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Linq;

namespace MassGlobalTest.DAL
{
	public static class Repository
    {
		public static IEnumerable<Employee> GetEmployees(int employeeId = 0)
		{
			IEnumerable<Employee> employeesList = null;
			var client = new HttpClient();
			var result = client.GetAsync("http://masglobaltestapi.azurewebsites.net/api/Employees").Result;
			if (result.IsSuccessStatusCode)
			{
				if (employeeId == 0)
				{
					employeesList = result.Content.ReadAsAsync<List<Employee>>().Result; 
				}
				else
				{
					employeesList = result.Content.ReadAsAsync<List<Employee>>().Result.Where(emp => emp.Id == employeeId);
				}
			}
			return employeesList;
		}

	}
}
